using System;
using System.Collections.Generic;
using System.Text;

namespace BlockGameSolver.Core
{
    public class Genome
    {
        private double fitness;
        private int[] moves = new int[GameSettings.MaxMoves];

        public Genome(bool isRandom)
        {
            if (isRandom)
            {
                Random rng = RandomSource.Instance;
                for (int i = 0; i < GameSettings.MaxMoves; i++)
                {
                    moves[i] = rng.Next(0, GameSettings.PieceCount);
                }
            }
            fitness = 0d;
        }

        public int[] Moves
        {
            get { return moves; }
            set { moves = value; }
        }

        public double Fitness
        {
            get { return fitness; }
            set { fitness = value; }
        }

        public int Crossover(Genome partner)
        {
            int swapPoint = RandomSource.Instance.Next(0, partner.moves.Length);

            int[] temp = new int[moves.Length];

            moves.CopyTo(temp, 0);

            Array.Copy(partner.Moves, swapPoint, moves, swapPoint, moves.Length - swapPoint);
            Array.Copy(temp, swapPoint, partner.moves, swapPoint, moves.Length - swapPoint);

            return swapPoint;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < moves.Length; i++)
            {
                sb.Append(moves[i]);
                sb.Append(",");
            }
            return sb.ToString();
        }

        public int Mutate()
        {
            Random rng = RandomSource.Instance;

            int mutatePoint = rng.Next(0, moves.Length);
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