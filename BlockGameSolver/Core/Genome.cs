using System;
using System.Diagnostics;
using System.Text;

namespace BlockGameSolver.Core
{
    public class Genome
    {
        private static int nextID;

        public Genome()
        {
            Moves = new int?[GameSettings.MaxMoves];
            Fitness = 0d;
            ID = ++nextID;
        }

        public Genome(bool isRandom)
            : this()
        {
            if (isRandom)
            {
                Random rng = RandomSource.Instance;
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
            double crossMethod = RandomSource.Instance.NextDoublePositive();
            if (crossMethod < 0.5)
            {
                //Single point CO
                int limit = (MoveCount > partner.MoveCount) ? partner.MoveCount : MoveCount;
                int swapPoint = RandomSource.Instance.Next(0, limit);

                int?[] temp = new int?[Moves.Length];

                Moves.CopyTo(temp, 0);

                Array.Copy(partner.Moves, swapPoint, Moves, swapPoint, Moves.Length - swapPoint);
                Array.Copy(temp, swapPoint, partner.Moves, swapPoint, Moves.Length - swapPoint);

                return swapPoint;
            }
            else if (crossMethod < 0.8)
            {
                //Double point CO
                int limit = (MoveCount > partner.MoveCount) ? partner.MoveCount : MoveCount;
                int swapPoint1 = RandomSource.Instance.Next(0, limit);
                int swapPoint2 = RandomSource.Instance.Next(0, limit);

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
            else
            {
                //Random CO
                for (int i = 0; i < Moves.Length; i++)
                {
                    if (RandomSource.Instance.NextDoublePositive() < 0.5)
                    {
                        int? temp = Moves[i];
                        Moves[i] = partner.Moves[i];
                        partner.Moves[i] = temp;
                    }
                }
                return 0;
            }
        }

        public override string ToString()
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
                if (RandomSource.Instance.NextDoublePositive() < mutateRate)
                {
                    //Select the mutation type
                    double mutationProb = RandomSource.Instance.NextDoublePositive();

                    if (mutationProb < 0.80)
                    {
                        //New value mutation

                        Moves[i] = RandomSource.Instance.Next(0, GameSettings.PieceCount);
                    }
                    else
                    {
                        //Interal switch mutation
                        Moves[i] = Moves[RandomSource.Instance.Next(0, Moves.Length)];
                    }

                    mutations++;
                }
            }
            return mutations;
        }

        public void Evaluate()
        {
            Board.Instance.SaveBoard();
            MoveCount = Board.Instance.RemoveGroups(Moves);
            Debug.Assert(MoveCount > 0, "Move count should not be 0.");
            Fitness = Board.Instance.Score;
            Board.Instance.LoadOldBoard();
        }

        public static Genome FromGenome(Genome source)
        {
            Genome output = new Genome();
            source.Moves.CopyTo(output.Moves, 0);
            output.MoveCount = source.MoveCount;

            return output;
        }
    }
}