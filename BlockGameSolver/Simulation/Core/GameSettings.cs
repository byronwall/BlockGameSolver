namespace BlockGameSolver.Simulation.Core
{
    public static class GameSettings
    {
        public static readonly int Columns = 10;
        public static readonly int GroupSize = 2;
        public static readonly int Rows = 10;

        public static int PieceCount
        {
            get { return Columns * Rows; }
        }

        public static int MaxMoves
        {
            get { return PieceCount / GroupSize ; }
        }
    }
}