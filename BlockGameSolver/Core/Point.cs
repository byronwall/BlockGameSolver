namespace BlockGameSolver.Core
{
    internal struct Point
    {
        private readonly int colInc;
        private readonly Direction dir;
        private readonly int rowInc;

        public Point(int rowInc, int colInc, Direction dir)
        {
            this.rowInc = rowInc;
            this.dir = dir;
            this.colInc = colInc;
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
            switch (direction)
            {
                case Direction.Bottom:
                    return Direction.Top;
                case Direction.Left:
                    return Direction.Right;
                case Direction.Top:
                    return Direction.Bottom;
                case Direction.Right:
                    return Direction.Left;
            }
            return Direction.None;
        }
    }
}