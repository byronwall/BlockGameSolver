using System;
using System.Drawing;
using Microsoft.DirectX.DirectDraw;

namespace BlockGameSolver.GamePlayer.Visual
{
    /// <summary>
    /// The supported bit-depths for overlay surfaces.
    /// </summary>
    /// <remarks>
    /// Video cards do not necessarily support both. There is no 24-bit enumerator because 24-bit overlays
    /// fails with E_NOTIMPL.
    /// </remarks>
    public enum BitsPerPixel
    {
        Bpp16,
        Bpp32
    }

    /// <summary>
    /// A rendering callback used by the overlay manager to draw to the overlay.
    /// </summary>
    public delegate void OverlayRenderCallback(Device device, Surface overalySurface);

    /// <summary>
    /// This class is responsible for managing and rendering the DirectDraw overlay.
    /// </summary>
    public class OverlayManager : IDisposable
    {
        #region Private data

        private readonly Device device;
        private readonly OverlayEffects overlayEffects;
        private Caps caps;
        private Surface overlayBackSurface;

        /// <summary>
        /// Bit-depth of the overlay surface.
        /// </summary>
        /// <seealso cref="BitsPerPixel"/>
        private BitsPerPixel overlayBpp;

        private OverlayFlags overlayFlags;

        /// <summary>
        /// Overlay surface height. Different video cards have different restrictions on this.
        /// </summary>
        /// <seealso cref="Resize"/>
        /// <seealso cref="OverlayHeight"/>
        private int overlayHeight;

        private Surface overlaySurface;

        /// <summary>
        /// Overlay surface width. Different video cards have different restrictions on this.
        /// </summary>
        /// <seealso cref="Resize"/>
        /// <seealso cref="OverlayWidth"/>
        private int overlayWidth;

        private Surface primarySurface;

        /// <summary>
        /// The rendering callback - we call this in <see cref="Update"/> to draw to the overlay before flipping
        /// it.
        /// </summary>
        private OverlayRenderCallback renderCallback;

        /// <summary>
        /// When a full-screen application launches, we lose all our surfaces - this flag will be set to true
        /// then.
        /// </summary>
        /// <remarks>
        /// When the device is available and this flag is true, we restore all surfaces.
        /// </remarks>
        private bool surfacesLost;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructs an overlay manager with no callback. The callback can be set using
        /// <see cref="RenderCallback"/> later.
        /// </summary>
        /// <remarks>
        /// It is not necessary to set a rendering callback. If none is set, an empty black overlay will
        /// be displayed.
        /// </remarks>
        public OverlayManager()
        {
            device = new Device();
            caps = device.GetCaps().HardwareCaps;
        }

        /// <summary>
        /// Constructs an overlay manager with the given callback.
        /// </summary>
        /// <param name="overlayRenderCallback">The rendering callback.</param>
        public OverlayManager(OverlayRenderCallback overlayRenderCallback)
            : this()
        {
            renderCallback = overlayRenderCallback;
        }

        #endregion

        #region Public properties

        /// <summary>
        /// Checks whether the hardware supports the creation of an additional overlay.
        /// </summary>
        /// <remarks>
        /// The function can fail for one of 2 reasons:
        /// 1. The hardware does not support overlays at all.
        /// 2. The maximum number of visible overlays has been reached.
        /// </remarks>
        public bool IsHardwareSupportAvailable
        {
            get
            {
                // If we've created an overlay surface, don't take it into consideration when checking the number
                // of visible overlays
                int numVisibleOverlays = overlaySurface != null ? caps.CurrentVisibleOverlays - 1 : 0;

                return caps.Overlay && caps.MaxVisibleOverlays > numVisibleOverlays;
            }
        }

        /// <summary>
        /// Retrieves the width of the overlay surface.
        /// </summary>
        public int OverlayWidth
        {
            get { return overlayWidth; }
        }

        /// <summary>
        /// Retrieves the height of the overlay surface.
        /// </summary>
        public int OverlayHeight
        {
            get { return overlayHeight; }
        }

        /// <summary>
        /// Gets or sets the overlay bit-depth. Recreates the overlay automatically if the new bit-depth is
        /// different from the old one.
        /// </summary>
        public BitsPerPixel OverlayBpp
        {
            get { return overlayBpp; }
            set
            {
                if (value != overlayBpp)
                {
                    overlayBpp = value;
                    DestroyOverlay();
                    RecreateOverlay();
                }
            }
        }

        /// <summary>
        /// Sets or gets the rendering callback.
        /// </summary>
        public OverlayRenderCallback RenderCallback
        {
            get { return renderCallback; }
            set { renderCallback = value; }
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Initializes the overlay manager and creates the necessary surfaces. Call <see cref="Update"/>
        /// afterwards to start rendering.
        /// </summary>
        /// <param name="width">Width of the overlay surface</param>
        /// <param name="height">Height of the overlay surface</param>
        /// <param name="bpp">Bit-depth of the overlay surface</param>
        public void Initialize(int width, int height, BitsPerPixel bpp)
        {
            overlayBpp = bpp;

            // Request normal cooperative level to put us in windowed mode
            device.SetCooperativeLevel(null, CooperativeLevelFlags.Normal);

            // Create the primary surface
            SurfaceCaps surfaceCaps = new SurfaceCaps();
            surfaceCaps.PrimarySurface = true;
            SurfaceDescription surfaceDesc = new SurfaceDescription(surfaceCaps);
            primarySurface = new Surface(surfaceDesc, device);

            // Create overlay surfaces
            Resize(width, height);
        }

        /// <summary>
        /// Recreates the overlay surfaces with the given dimensions.
        /// </summary>
        /// <param name="width">Width of the overlay surface</param>
        /// <param name="height">Height of the overlay surface</param>
        public void Resize(int width, int height)
        {
            overlayWidth = width;
            overlayHeight = height;

            DestroyOverlay();
            RecreateOverlay();
        }

        /// <summary>
        /// Updates the contents of the overlay surface and flips it.
        /// </summary>
        public void Update()
        {
            // Check the cooperative level before rendering
            if (!device.TestCooperativeLevel())
            {
                surfacesLost = true;

                // Do nothing because some app has exclusive mode
                return;
            }

            // If we have the device and our surfaces are lost, restore them
            if (surfacesLost)
            {
                device.RestoreAllSurfaces();
                surfacesLost = false;
            }

            renderCallback(device, overlayBackSurface);
            overlaySurface.Flip(null, FlipFlags.Wait);

            // Setup overlay flags for presentation
            overlayFlags = OverlayFlags.Show;

            // The following can be used for a transparent overlay background.
#if false
    // Check for source color keying capability
			if(caps.ColorKeyCaps.SourceOverlay)
			{
				DirectDraw.ColorKey key = new DirectDraw.ColorKey();
				key.ColorSpaceHighValue = 0;
				key.ColorSpaceLowValue = 0;
				overlayEffects.DestinationColorKey = key;
				overlayFlags |= DirectDraw.OverlayFlags.Effects | DirectDraw.OverlayFlags.KeySourceOverride;
			}
#endif
            System.Drawing.Rectangle destRectangle = new System.Drawing.Rectangle(OverlayPosition.X, OverlayPosition.Y, overlayWidth, overlayHeight); overlaySurface.UpdateOverlay(primarySurface, destRectangle, overlayFlags, overlayEffects);
        }

        public Point OverlayPosition { get; set; }

        #endregion

        #region Private methods

        /// <summary>
        /// Recreates overlay surfaces using <see cref="overlayWidth"/>, <see cref="overlayHeight"/> and
        /// <see cref="overlayBpp"/>.
        /// </summary>
        private void RecreateOverlay()
        {
            // Setup the overlay surface attributes
            SurfaceCaps surfaceCaps = new SurfaceCaps();
            surfaceCaps.Overlay = true;
            surfaceCaps.Flip = true;
            surfaceCaps.Complex = true;
            surfaceCaps.VideoMemory = true;

            SurfaceDescription surfaceDesc = new SurfaceDescription(surfaceCaps);
            surfaceDesc.BackBufferCount = 1;
            surfaceDesc.Width = overlayWidth;
            surfaceDesc.Height = overlayHeight;
            surfaceDesc.PixelFormatStructure = GetPixelFormat(BitsPerPixel.Bpp32);

            // Attempt to create the surface with these settings
            overlaySurface = new Surface(surfaceDesc, device);

            // Get the overlay back surface
            SurfaceCaps backSurfaceCaps = new SurfaceCaps();
            backSurfaceCaps.BackBuffer = true;
            overlayBackSurface = overlaySurface.GetAttachedSurface(backSurfaceCaps);
        }

        /// <summary>
        /// Destroys the overlay surfaces.
        /// </summary>
        private void DestroyOverlay()
        {
            if (overlaySurface != null)
            {
                overlaySurface.Dispose();
                overlaySurface = null;
            }

            overlayBackSurface = null;
        }

        /// <summary>
        /// Retrieves a <see cref="PixelFormat"/> that satisfies the given bit-depth.
        /// </summary>
        /// <param name="bpp">Required bit-depth.</param>
        /// <returns>A <see cref="PixelFormat"/></returns>
        private PixelFormat GetPixelFormat(BitsPerPixel bpp)
        {
            PixelFormat pixelFormat = new PixelFormat();
            pixelFormat.Rgb = true;

            switch (bpp)
            {
                case BitsPerPixel.Bpp16:
                    pixelFormat.RgbBitCount = 16;
                    pixelFormat.RBitMask = 0xF800;
                    pixelFormat.GBitMask = 0x07E0;
                    pixelFormat.BBitMask = 0x001F;
                    break;

                case BitsPerPixel.Bpp32:
                    pixelFormat.RgbBitCount = 32;
                    pixelFormat.RBitMask = 0x00FF0000;
                    pixelFormat.GBitMask = 0x0000FF00;
                    pixelFormat.BBitMask = 0x000000FF;
                    break;

                default:
                    throw new ArgumentOutOfRangeException("bpp", bpp, "Unexpected bit depth - neither 16 nor 32");
            }

            return pixelFormat;
        }

        #endregion

        #region IDisposable pattern

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                DestroyOverlay();

                if (primarySurface != null)
                {
                    primarySurface.Dispose();
                    primarySurface = null;
                }

                surfacesLost = false;
            }
        }

        #endregion
    }
}