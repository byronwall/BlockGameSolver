using System.Collections.Generic;
using BlockGameSolver.Simulation.Core;

namespace BlockGameSolver.StatisticalAnalysis.Core
{
    internal class BoardSourceStatistical : IBoardSource
    {
        public BoardSourceStatistical(int rows, int columns, int seed)
        {
            Rows = rows;
            Columns = columns;
            Seed = seed;
        }

        public BoardSourceStatistical(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            Seed = RandomSource.Instance.Next();
        }

        #region Implementation of IBoardSource

        public List<Piece> GetPiecesForBoard()
        {
            RandomSource.Reseed(Seed);
            List<Piece> pieces = new List<Piece>();

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    bool isDouble = (RandomSource.Instance.NextDoublePositive() < 0.05) ? true : false;
                    bool isBomb = (!isDouble && RandomSource.Instance.NextDoublePositive() < 0.05) ? true : false;
                    pieces.Add(new Piece(i, j, RandomSource.Instance.Next(1, 6), isBomb, isDouble));
                }
            }
            return pieces;
        }

        public int Rows { get; private set; }
        public int Columns { get; private set; }

        #endregion

        public int Seed { get; set; }
    }
}