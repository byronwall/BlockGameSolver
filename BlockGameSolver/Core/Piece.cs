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

        public Piece(int col, int color, int row, bool isBomb)
        {
            Col = col;
            Color = color;
            Row = row;
            IsBomb = isBomb;
        }

        public int Col { get; set; }

        public int Color { get; set; }

        public int Row { get; set; }
        public bool IsBomb { get; set; }

        public override string ToString()
        {
            return (Row*GameSettings.Columns + Col).ToString();
        }
    }
}