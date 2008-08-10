namespace BlockGameSolver.Simulation.Core
{
    public class RowColumnPoint
    {
        private static readonly Direction[] opposite = new Direction[4];

        static RowColumnPoint()
        {
            opposite[(int) Direction.Bottom] = Direction.Top;
            opposite[(int) Direction.Left] = Direction.Right;
            opposite[(int) Direction.Right] = Direction.Left;
            opposite[(int) Direction.Top] = Direction.Bottom;
        }

        private readonly int column;
        private readonly Direction dir;
        private readonly int row;

        public RowColumnPoint(int rowInc, int colInc, Direction dir)
        {
            this.row = rowInc;
            this.dir = dir;
            this.column = colInc;
        }

        public RowColumnPoint(int row, int col)
        {
            this.row = row;
            column = col;
            dir = Direction.None;
        }

        public Direction Dir
        {
            get { return dir; }
        }

        public int Column
        {
            get { return column; }
        }

        public int Row
        {
            get { return row; }
        }

        public static Direction GetOppositeDirection(Direction direction)
        {
            return opposite[(int) direction];
        }
    }
}