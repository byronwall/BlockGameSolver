using System;
using System.Linq;
using BlockGameSolver.Simulation.Core;

namespace BlockGameSolver.Simulation.Strategy
{
    public class PopulationSingleRun : PopulationBase
    {
        public PopulationSingleRun(PopulationSettings settings, Board board) : base(settings, board)
        {
        }

        public PopulationSingleRun(Board board) : base(board)
        {
        }

        private void GenerateInitialPopulation()
        {
            currentPopulation.Clear();
            for (int i = 0; i < settings.InitialPopulationSize; i++)
            {
                currentPopulation.Add(new Genome(PopulationBoard));
            }
        }

        protected void RunCurrentGeneration()
        {
            foreach (Genome genome in currentPopulation)
            {
                genome.Evaluate();
            }
        }

        protected void CreateNextGeneration()
        {
            newPopulation.Clear();
            //Elite selection
            newPopulation.AddRange(currentPopulation.OrderByDescending(c => c.Fitness).Take(settings.FilterSize));

            for (int i = 0; i < settings.PopulationSize - settings.FilterSize; i++)
            {
                //Determine if a cross-over should occur
                if (rng.NextDoublePositive() < settings.CrossoverRatio)
                {
                    //This indicates a cross over should occur

                    Genome genome1 = SelectGenome();
                    Genome genome2 = SelectGenome();

                    Genome frontChild = genomeOperations.CrossoverNew(genome1, genome2);
                    Genome endChild = genomeOperations.CrossoverNew(genome2, genome1);

                    newPopulation.Add(frontChild);
                    newPopulation.Add(endChild);

                    //Mutate the last crossover result
                    genomeOperations.Mutate(frontChild, settings.MutateRatio);
                    genomeOperations.Mutate(endChild, settings.MutateRatio);
                    //frontChild.Mutate(settings.MutateRatio);
                    //endChild.Mutate(settings.MutateRatio);
                }
                else
                {
                    //This indicates that a direct replication should occur.
                    Genome directCopy = genomeOperations.MutateNew(SelectGenome(), settings.MutateRatio);

                    //Genome.Mutate(SelectGenome(), settings.MutateRatio);
                    currentPopulation.Add(directCopy);
                }
            }
            currentPopulation.Clear();
            foreach (Genome genome in newPopulation)
            {
                currentPopulation.Add(genome);
            }
        }

        private void ContinueEvaluation()
        {
            RunCurrentGeneration();
            InvokeGenerationCompleted(new GenerationEventArgs(generationNum));

            if (generationNum < settings.MaxGenerations)
            {
                //FilterCurrentGeneration();
                CreateNextGeneration();
            }
        }

        public override void BeginGeneticProcess()
        {
            if (IsReseedRequired) RandomSource.Reseed((int) DateTime.Now.Ticks);

            InitializeAndRun();
            InvokePopulationFinished(EventArgs.Empty);
        }

        public virtual void InitializeAndRun()
        {
            generationNum = 0;
            GenerateInitialPopulation();
            for (int i = 0; i < settings.MaxGenerations; i++)
            {
                generationNum = i + 1;
                ContinueEvaluation();
            }
        }
    }
}