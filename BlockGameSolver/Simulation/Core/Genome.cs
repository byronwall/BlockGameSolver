using System;
using System.Text;
using BlockGameSolver.Simulation.Utility;

namespace BlockGameSolver.Simulation.Core
{
    public class Genome
    {
        private static int nextID;
        private readonly Board board;
        private readonly MersenneTwister rng = new MersenneTwister();

        public Genome(Board board) : this(board, true)
        {
        }

        public Genome(Board board, bool random)
        {
            this.board = board;
            Moves = new int?[GameSettings.MaxMoves];
            Fitness = 0d;
            ID = ++nextID;

            if (random)
            {
                for (int i = 0; i < GameSettings.MaxMoves; i++)
                {
                    Moves[i] = rng.Next(0, GameSettings.PieceCount);
                }
            }
        }

        public int ID { get; set; }

        public int?[] Moves { get; set; }

        public double Fitness { get; set; }

        public int MoveCount { get; set; }

        public int Crossover(Genome partner)
        {
            double crossMethod = rng.NextDoublePositive();
            if (crossMethod < 0.5)
            {
                //Single point CO
                int limit = (MoveCount > partner.MoveCount) ? partner.MoveCount : MoveCount;
                int swapPoint = rng.Next(0, limit);

                int?[] temp = new int?[Moves.Length];

                Moves.CopyTo(temp, 0);

                Array.Copy(partner.Moves, swapPoint, Moves, swapPoint, Moves.Length - swapPoint);
                Array.Copy(temp, swapPoint, partner.Moves, swapPoint, Moves.Length - swapPoint);

                return swapPoint;
            }
            if (crossMethod < 0.8)
            {
                //Double point CO
                int limit = (MoveCount > partner.MoveCount) ? partner.MoveCount : MoveCount;
                int swapPoint1 = rng.Next(0, limit);
                int swapPoint2 = rng.Next(0, limit);

                if (swapPoint2 < swapPoint1)
                {
                    int tempPoint = swapPoint1;
                    swapPoint1 = swapPoint2;
                    swapPoint2 = tempPoint;
                }
                int?[] temp = new int?[Moves.Length];

                Moves.CopyTo(temp, 0);

                Array.Copy(partner.Moves, swapPoint1, Moves, swapPoint1, swapPoint2 - swapPoint1);
                Array.Copy(temp, swapPoint1, partner.Moves, swapPoint1, swapPoint2 - swapPoint1);

                return swapPoint1;
            }
            //Random CO
            for (int i = 0; i < Moves.Length; i++)
            {
                if (rng.NextDoublePositive() < 0.5)
                {
                    int? temp = Moves[i];
                    Moves[i] = partner.Moves[i];
                    partner.Moves[i] = temp;
                }
            }
            return 0;
        }

        public override string ToString()
        {
            

            return ID.ToString();
        }
        public string GetMoveList()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < Moves.Length; i++)
            {
                if (Moves[i] == null)
                {
                    break;
                }

                sb.Append(Moves[i]);
                sb.Append(",");
            }
            return sb.ToString();
        }

        public int Mutate(double mutateRate)
        {
            int mutations = 0;
            for (int i = 0; i < Moves.Length; i++)
            {
                if (rng.NextDoublePositive() < mutateRate)
                {
                    //Select the mutation type
                    double mutationProb = rng.NextDoublePositive();

                    Moves[i] = mutationProb < 0.80 ? rng.Next(0, GameSettings.PieceCount) : Moves[rng.Next(0, Moves.Length)];

                    mutations++;
                }
            }
            return mutations;
        }

        public void Evaluate()
        {
            board.SaveBoard();
            MoveCount = board.RemoveGroups(Moves);
            Fitness = board.Score;
            board.LoadOldBoard();
        }

        public static Genome FromGenome(Genome source)
        {
            Genome output = new Genome(source.board);
            source.Moves.CopyTo(output.Moves, 0);
            output.MoveCount = source.MoveCount;

            return output;
        }
    }
}