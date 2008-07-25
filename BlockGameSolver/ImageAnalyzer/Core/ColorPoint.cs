namespace BlockGameSolver.ImageAnalyzer.Core
{
    public class ColorPoint
    {
        public ColorPoint(int imageColor, int boardColor, bool isBomb)
        {
            ImageColor = imageColor;
            BoardColor = boardColor;
            IsBomb = isBomb;
        }

        public ColorPoint(int imageColor)
        {
            ImageColor = imageColor;
            IsBomb = false;
        }

        public int ImageColor { get; private set; }
        public int BoardColor { get; private set; }
        public bool IsBomb { get; private set; }
        public string Name { get; set; }
        public string Source { get; set; }

        public override string ToString()
        {
            return string.Format("{0}: {1}", ImageColor, Name);
        }
    }
}