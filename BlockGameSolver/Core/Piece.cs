namespace BlockGameSolver.Core
{
    public class Piece
    {
        public Piece(int row, int col, int color)
        {
            Col = col;
            Color = color;
            Row = row;
        }

        public Piece(int row, int col, int color, bool isBomb, bool isDouble)
        {
            Col = col;
            Color = (isBomb) ? 6 : color;
            Row = row;
            IsBomb = isBomb;
            IsDouble = isDouble;
        }
        public int Row { get; set; }
        public int Col { get; set; }

        public int Color { get; set; }


        public bool IsBomb { get; set; }
        public bool IsDouble { get; set; }

        public override string ToString()
        {
            return (Row * GameSettings.Columns + Col).ToString();
        }
    }
}