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

        public static RowColumnPoint GetLocationFromNumber(int number)
        {
            return new RowColumnPoint(number/Columns, number%Columns);
        }

        public static bool IsColumnValid(int nextColumn)
        {
            return 0 <= nextColumn && nextColumn < Columns;
        }

        public static bool IsRowValid(int nextRow)
        {
            return 0 <= nextRow && nextRow < Rows;
        }
    }
}