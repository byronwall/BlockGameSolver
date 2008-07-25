using System.Drawing;

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
    }
}