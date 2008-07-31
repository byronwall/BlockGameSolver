namespace BlockGameSolver.Simulation.Core
{
    public static class GameSettings
    {
        public static int Columns = 10;
        public static int GroupSize = 2;
        public static int Rows = 10;

        public static int PieceCount
        {
            get { return Columns*Rows; }
        }

        public static int MaxMoves
        {
            get { return PieceCount/GroupSize; }
        }

        public static int GetNumberFromLocation(int row, int col)
        {
            return row*Columns + col;
        }

        public static Point GetLocationFromNumber(int number)
        {
            return new Point(number/Columns, number%Columns);
        }
    }
}