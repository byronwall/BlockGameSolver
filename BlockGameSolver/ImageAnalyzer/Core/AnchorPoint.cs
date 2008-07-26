using System.Drawing;

namespace BlockGameSolver.ImageAnalyzer.Core
{
    public struct AnchorPoint
    {
        public AnchorPoint(int xOffset, int yOffset, int color) : this()
        {
            XOffset = xOffset;
            YOffset = yOffset;
            Color = color;
        }

        public int XOffset { get; set; }
        public int YOffset { get; set; }
        public int Color { get; set; }

    }
}