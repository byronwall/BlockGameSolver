using System;
using System.Drawing;
using System.Text;

namespace ImageAnalyzer
{
    internal class ImageSettings
    {
        private Bitmap thumbnailImage;
        public Bitmap FullImage { get; set; }

        public int ThumbnailHeight { get; set; }

        public Point ThumbnailCorner { get; set; }

        public int ThumbnailWidth { get; set; }

        public Bitmap ThumbnailImage
        {
            get
            {
                Bitmap smaller = new Bitmap(ThumbnailWidth, ThumbnailHeight);

                using (Graphics graphics = Graphics.FromImage(smaller))
                {
                    graphics.DrawImage(FullImage, new Rectangle(0, 0, ThumbnailWidth, ThumbnailHeight), ThumbnailCorner.X, ThumbnailCorner.Y, ThumbnailWidth, ThumbnailHeight, GraphicsUnit.Pixel);
                }
                return smaller;
            }
        }

        public int PieceWidth { get; set; }
        public int PieceHeight { get; set; }

        public Bitmap PieceThumbnail
        {
            get { return BitmapUtility.CropBitmap(FullImage, PieceCorner.X, PieceCorner.Y, PieceWidth, PieceHeight); }
        }

        public Point PieceCorner { get; set; }

        public string SaveThumbnailData()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < ThumbnailWidth; i++)
            {
                for (int j = 0; j < ThumbnailHeight; j++)
                {
                    sb.Append(String.Format("[{0},{1}]: {2}", i, j, thumbnailImage.GetPixel(i, j).ToArgb()));
                }
            }
            return sb.ToString();
        }

        public void UpdateThumbnail()
        {
            thumbnailImage = ThumbnailImage;
        }
    }
}