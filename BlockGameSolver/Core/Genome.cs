using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlockGameSolver.Core
{
    public class Genome
    {
        private List<int> moves = new List<int>(GameSettings.MaxMoves);

        public Genome(bool isRandom)
        {
            if (isRandom)
            {
                Random rng = RandomSource.Instance;
                for (int i = 0; i < GameSettings.MaxMoves; i++)
                {
                    moves.Add(rng.Next(0, GameSettings.PieceCount));
                }
            }
        }

        public List<int> Moves
        {
            get { return moves; }
            set { moves = value; }
        }
        public double Fitness { get; set; }

        public void Crossover(ref Genome partner)
        {
            int swapPoint = RandomSource.Instance.Next(0, moves.Count);

            var originalStart = moves.Where((item, index) => index < swapPoint);
            var originalEnd = moves.Where((item, index) => index >= swapPoint);
            var targetStart = partner.moves.Where((item, index) => index < swapPoint);
            var targetEnd = partner.moves.Where((item, index) => index >= swapPoint);

            moves = originalStart.Concat(targetEnd).ToList();
            partner.moves = targetStart.Concat(originalEnd).ToList();
        }

        public void Mutate()
        {
            Random rng = RandomSource.Instance;

            int mutatePoint = rng.Next(0, Moves.Count);
            int value = rng.Next(0, GameSettings.PieceCount);

            moves[mutatePoint] = value;
        }

        public void Evaluate()
        {
            Board.Instance.SaveBoard();
            Fitness = Board.Instance.RemoveGroups(Moves);
            Board.Instance.LoadOldBoard();
        }
    }
}