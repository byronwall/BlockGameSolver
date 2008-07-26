using System.Drawing;
using System.Drawing.Imaging;
using System.Threading;
using System.Windows.Forms;

namespace BlockGameSolver.ImageAnalyzer.Utility
{
    public static class BitmapUtility
    {
        public static Bitmap CropBitmap(Bitmap source, int pixelX, int pixelY, int width, int height)
        {
            Bitmap cropped = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(cropped))
            {
                g.DrawImage(source, new Rectangle(0, 0, width, height), pixelX, pixelY, width, height, GraphicsUnit.Pixel);
            }

            return cropped;
        }

        /// <summary>
        /// Takes a screenshot of the primary display.
        /// </summary>
        /// <returns>A Bitmap of the primary display.</returns>
        public static Bitmap BitmapFromScreenshot()
        {
            Size screenSize = new Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
            Bitmap screenshot = new Bitmap(screenSize.Width, screenSize.Height, PixelFormat.Format32bppRgb);
            Graphics g = Graphics.FromImage(screenshot);
            g.CopyFromScreen(0, 0, 0, 0, screenSize);

            return screenshot;
        }

        /// <summary>
        /// Calls BitmapFromScreenshot and also hides the form that is calling the method so that it does not appear in the screenshot.
        /// </summary>
        /// <param name="form">The calling form that should be hidden.</param>
        /// <returns>A Bitmap that is the screenshot.</returns>
        public static Bitmap BitmapFromScreenshot(Form form)
        {
            form.Hide();
            Thread.Sleep(200);
            Bitmap output = BitmapFromScreenshot();
            form.Show();

            return output;
        }
    }
}