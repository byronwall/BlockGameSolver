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

        public int Col { get; set; }

        public int Color { get; set; }

        public int GroupId { get; set; }

        public int Row { get; set; }

        public bool Checked { get; set; }
    }
}