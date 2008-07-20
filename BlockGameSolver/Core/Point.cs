namespace BlockGameSolver.Core
{
    public struct Point
    {
        private static readonly Direction[] opposite = new Direction[4];

        static Point()
        {
            opposite[(int) Direction.Bottom] = Direction.Top;
            opposite[(int) Direction.Left] = Direction.Right;
            opposite[(int) Direction.Right] = Direction.Left;
            opposite[(int) Direction.Top] = Direction.Bottom;
        }

        private readonly int colInc;
        private readonly Direction dir;
        private readonly int rowInc;

        public Point(int rowInc, int colInc, Direction dir)
        {
            this.rowInc = rowInc;
            this.dir = dir;
            this.colInc = colInc;
        }

        public Point(int row, int col)
        {
            rowInc = row;
            colInc = col;
            dir = Direction.None;
        }

        public Direction Dir
        {
            get { return dir; }
        }

        public int ColInc
        {
            get { return colInc; }
        }

        public int RowInc
        {
            get { return rowInc; }
        }

        public static Direction GetOppositeDirection(Direction direction)
        {
            return opposite[(int) direction];
        }
    }
}