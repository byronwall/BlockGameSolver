using System;
using System.Collections.Generic;
using System.Linq;

namespace BlockGameSolver.Core
{
    public struct Genome
    {
        private double fitness;
        private List<int> moves;

        public Genome(bool isRandom)
        {
            moves = new List<int>(GameSettings.MaxMoves);
            if (isRandom)
            {
                Random rng = RandomSource.Instance;
                for (int i = 0; i < GameSettings.MaxMoves; i++)
                {
                    moves.Add(rng.Next(0, GameSettings.PieceCount));
                }
            }
            fitness = 0d;
        }

        public List<int> Moves
        {
            get { return moves; }
            set { moves = value; }
        }

        public double Fitness
        {
            get { return fitness; }
            set { fitness = value; }
        }

        public int Crossover(ref Genome partner)
        {
            int swapPoint = RandomSource.Instance.Next(0, moves.Count);

            var originalStart = moves.Where((item, index) => index < swapPoint);
            var originalEnd = moves.Where((item, index) => index >= swapPoint);
            var targetStart = partner.moves.Where((item, index) => index < swapPoint);
            var targetEnd = partner.moves.Where((item, index) => index >= swapPoint);

            moves = originalStart.Concat(targetEnd).ToList();
            partner.moves = targetStart.Concat(originalEnd).ToList();

            return swapPoint;
        }

        public int Mutate()
        {
            Random rng = RandomSource.Instance;

            int mutatePoint = rng.Next(0, Moves.Count);
            int value = rng.Next(0, GameSettings.PieceCount);

            moves[mutatePoint] = value;

            return mutatePoint;
        }

        public void Evaluate()
        {
            Board.Instance.SaveBoard();
            Fitness = Board.Instance.RemoveGroups(Moves);
            Board.Instance.LoadOldBoard();
        }
    }
}