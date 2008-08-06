using System;
using System.Text;
using BlockGameSolver.Simulation.Utility;

namespace BlockGameSolver.Simulation.Core
{
    public class Genome
    {
        private static readonly MersenneTwister rngStatic = new MersenneTwister();
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

        private static MersenneTwister RngStatic
        {
            get
            {
                lock (rngStatic)
                {
                    return rngStatic;
                }
            }
        }

        public static Genome Crossover(Genome genomeStart, Genome genomeEnd)
        {
            Genome genomeOutput = new Genome(genomeStart.board, false);
            double crossMethod = RngStatic.NextDoublePositive();
            if (crossMethod < 0.5)
            {
                //Single point CO
                int limit = (genomeStart.MoveCount > genomeEnd.MoveCount) ? genomeEnd.MoveCount : genomeStart.MoveCount;
                int swapPoint = RngStatic.Next(0, limit);

                for (int i = 0; i < limit; i++)
                {
                    if (i < swapPoint) genomeOutput.Moves[i] = genomeStart.Moves[i];
                    else genomeOutput.Moves[i] = genomeEnd.Moves[i];
                }
                genomeOutput.MoveCount = genomeEnd.MoveCount;
            }
            if (crossMethod < 0.8)
            {
                //Double point CO
                int limit = (genomeStart.MoveCount > genomeEnd.MoveCount) ? genomeEnd.MoveCount : genomeStart.MoveCount;
                int swapPoint1 = RngStatic.Next(0, limit);
                int swapPoint2 = RngStatic.Next(0, limit);

                if (swapPoint2 < swapPoint1)
                {
                    int tempPoint = swapPoint1;
                    swapPoint1 = swapPoint2;
                    swapPoint2 = tempPoint;
                }
                for (int i = 0; i < limit; i++)
                {
                    if (i < swapPoint1 || i > swapPoint2) genomeOutput.Moves[i] = genomeStart.Moves[i];
                    else genomeOutput.Moves[i] = genomeEnd.Moves[i];
                }
                genomeOutput.MoveCount = limit;
            }
            else
            {
                //Random mix
                int limit = (genomeStart.MoveCount > genomeEnd.MoveCount) ? genomeEnd.MoveCount : genomeStart.MoveCount;

                for (int i = 0; i < limit; i++)
                {
                    if (RngStatic.NextDoublePositive() < 0.5) genomeOutput.Moves[i] = genomeStart.Moves[i];
                    else genomeOutput.Moves[i] = genomeEnd.Moves[i];
                }
                genomeOutput.MoveCount = limit;
            }
            return genomeOutput;
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
                if (Moves[i] == null) break;

                sb.Append(Moves[i]);
                sb.Append(",");
            }
            return sb.ToString();
        }

        public static Genome Mutate(Genome genomeSource,double mutateRate)
        {
            Genome genomeOutput = new Genome(genomeSource.board, false);
            for (int i = 0; i < genomeSource.Moves.Length; i++)
            {
                if (RngStatic.NextDoublePositive() < mutateRate)
                {
                    //Select the mutation type

                    genomeOutput.Moves[i] = RngStatic.Next(0, GameSettings.PieceCount);
                }
                else
                {
                    genomeOutput.Moves[i] = genomeSource.Moves[i];
                }
            }
            return genomeOutput;
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