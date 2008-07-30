using System.Collections.Generic;

namespace BlockGameSolver.Simulation.Core
{
    public interface IBoardSource
    {
        int Rows { get; }
        int Columns { get; }
        List<Piece> GetPiecesForBoard();
    }
}