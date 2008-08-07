using BlockGameSolver.Simulation.Utility;

namespace BlockGameSolver.Simulation.Core
{
    public class GenomeOperations
    {
        private static readonly MersenneTwister rngStatic = new MersenneTwister();

        private static GenomeOperations instance;

        private GenomeOperations()
        {
        }

        public static GenomeOperations Instance
        {
            get
            {
                if (instance == null) instance = new GenomeOperations();
                return instance;
            }
        }

        private static MersenneTwister RngStatic
        {
            get { return rngStatic; }
        }

        public virtual Genome CrossoverNew(Genome genomeStart, Genome genomeEnd)
        {
            Genome genomeOutput = new Genome(genomeStart);
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

        public virtual Genome MutateNew(Genome genomeSource, double mutateRate)
        {
            Genome genomeOutput = new Genome(genomeSource);
            for (int i = 0; i < genomeSource.Moves.Length; i++)
            {
                if (RngStatic.NextDoublePositive() < mutateRate) genomeOutput.Moves[i] = RngStatic.Next(0, GameSettings.PieceCount);
                else genomeOutput.Moves[i] = genomeSource.Moves[i];
            }
            return genomeOutput;
        }

        public virtual void Mutate(Genome genome, double mutateRate)
        {
            for (int i = 0; i < genome.Moves.Length; i++)
            {
                if (RngStatic.NextDoublePositive() < mutateRate) genome.Moves[i] = RngStatic.Next(0, GameSettings.PieceCount);
            }
        }
    }
}