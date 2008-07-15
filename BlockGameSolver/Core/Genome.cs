using System;
using System.Collections.Generic;

namespace BlockGameSolver.Core
{
    public class Genome
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

        public int Crossover(Genome startPart, Genome endPart, ref Genome endChild)
        {
            int swapPoint = RandomSource.Instance.Next(0, startPart.moves.Count);

            for (int i = 0; i < startPart.moves.Count; i++)
            {
                moves.Add(i < swapPoint ? startPart.moves[i] : endPart.moves[i]);
                endChild.moves.Add(i >= swapPoint ? startPart.moves[i] : endPart.moves[i]);
            }
            return swapPoint;
        }

        public int Mutate(Genome source)
        {
            Random rng = RandomSource.Instance;

            int mutatePoint = rng.Next(0, source.moves.Count);
            int value = rng.Next(0, GameSettings.PieceCount);

            for (int i = 0; i < source.moves.Count; i++)
            {
                moves.Add((i == mutatePoint) ? value : source.moves[i]);
            }
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