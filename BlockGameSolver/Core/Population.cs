using System;
using System.Collections.Generic;
using System.Linq;

namespace BlockGameSolver.Core
{
    public class Population
    {
        private readonly List<Genome> currentPopulation = new List<Genome>();
        private int generationNum;
        private List<Genome> newPopulation = new List<Genome>();

        private readonly Results populationResults = new Results();

        private PopulationSettings settings;

        public Population(PopulationSettings settings)
        {
            this.settings = settings;
        }

        public Results PopulationResults
        {
            get { return populationResults; }
        }

        private void GenerateInitialPopulation()
        {
            currentPopulation.Clear();
            for (int i = 0; i < settings.PopulationSize; i++)
            {
                currentPopulation.Add(new Genome(true));
            }
        }

        private void RunCurrentGeneration()
        {
            PopulationResults.AddMessage("Running the current generation.");
            foreach (Genome genome in currentPopulation)
            {
                genome.Evaluate();
                PopulationResults.AddEvaluationResult(generationNum, genome.Moves, genome.Fitness);
            }
        }

        private void CreateNextGeneration()
        {
            PopulationResults.AddMessage("Creating the next generation.");
            MersenneTwister rng = RandomSource.Instance;
            currentPopulation.Clear();
            //Add in the ones that were kept.
            foreach (Genome genome in newPopulation)
            {
                currentPopulation.Add(genome);
            }
            int crossovers = 0;
            int mutations = 0;
            for (int i = 0; i < settings.PopulationSize - settings.FilterSize; i++)
            {
                if (rng.NextDouble() < settings.MutateCrossRatio)
                {
                    //Mutate
                    mutations++;
                    int genomeNum = rng.Next(0, settings.FilterSize);
                    Genome genome = newPopulation[genomeNum];

                    Genome afterMutate = new Genome(false);

                    int mutatePoint = afterMutate.Mutate(genome);
                    currentPopulation.Add(afterMutate);

                    PopulationResults.AddMessage(string.Format("Mutation occurred for genome {0} at point {1}", genomeNum, mutatePoint));

                }
                else
                {
                    //Crossover
                    crossovers++;
                    int genomeNum1 = rng.Next(0, settings.FilterSize);
                    int genomeNum2 = rng.Next(0, settings.FilterSize);

                    Genome genome1 = newPopulation[genomeNum1];
                    Genome genome2 = newPopulation[genomeNum2];

                    Genome frontChild = new Genome(false);
                    Genome endChild = new Genome(false);

                    int swapPoint = frontChild.Crossover(genome1, genome2, ref endChild);

                    currentPopulation.Add(frontChild);
                    currentPopulation.Add(endChild);

                    PopulationResults.AddMessage(string.Format("Crossover occurred from genome {0} to {1} at point {2}", genomeNum1, genomeNum2, swapPoint));

                }
            }
            PopulationResults.AddMessage(string.Format("Mutations: {0}\tCrosses: {1}", mutations, crossovers));
        }

        private void FilterCurrentGeneration()
        {
            PopulationResults.AddMessage("Filtering the current generation.");
            int keepers = settings.FilterSize;

            newPopulation = currentPopulation.OrderByDescending(c => c.Fitness).Take(keepers).ToList();

            foreach (Genome genome in newPopulation)
            {
                populationResults.AddMessage(string.Format("Genome with fitness {0} survived.", genome.Fitness));

            }

            currentPopulation.Clear();
        }

        private void ContinueEvaluation()
        {
            RunCurrentGeneration();
            InvokeGenerationCompleted(new GenerationEventArgs(generationNum));

            if (generationNum < settings.MaxGenerations)
            {
                FilterCurrentGeneration();
                CreateNextGeneration();
            }
        }

        public void BeginGeneticProcess()
        {
            PopulationResults.AddHeader("Beginning the process");

            GenerateInitialPopulation();
            for (int i = 0; i < settings.MaxGenerations; i++)
            {
                generationNum = i + 1;
                ContinueEvaluation();
            }
            PopulationResults.FinishOutput();
            InvokePopulationFinished(EventArgs.Empty);
        }

        public event EventHandler PopulationFinished;

        private void InvokePopulationFinished(EventArgs e)
        {
            EventHandler populationFinishedHandler = PopulationFinished;
            if (populationFinishedHandler != null)
            {
                populationFinishedHandler(this, e);
            }
        }

        public event EventHandler<GenerationEventArgs> GenerationCompleted;

        private void InvokeGenerationCompleted(GenerationEventArgs e)
        {
            EventHandler<GenerationEventArgs> generationCompletedHandler = GenerationCompleted;
            if (generationCompletedHandler != null)
            {
                generationCompletedHandler(this, e);
            }
        }
    }

    public class GenerationEventArgs : EventArgs
    {
        public GenerationEventArgs(int generationNumber)
        {
            GenerationNumber = generationNumber;
        }

        public int GenerationNumber { get; private set; }
    }
}