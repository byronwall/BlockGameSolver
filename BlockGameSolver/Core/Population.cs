using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            Stopwatch stopwatch = Stopwatch.StartNew();

            PopulationResults.AddMessage("Running the current generation.");
            List<double> round = new List<double>(settings.PopulationSize);
            populationResults.ScoreData.Add(round);
            foreach (Genome genome in currentPopulation)
            {
                genome.Evaluate();
                round.Add(genome.Fitness);
                PopulationResults.AddEvaluationResult(generationNum, genome.Moves, genome.Fitness);
            } stopwatch.Stop();
            populationResults.AddMessage(string.Format("The run took {0} milliseconds.", stopwatch.ElapsedMilliseconds));
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

                    genome.Moves.CopyTo(afterMutate.Moves, 0);

                    int mutatePoint = afterMutate.Mutate();
                    currentPopulation.Add(afterMutate);

                    PopulationResults.AddMessage(string.Format("Mutation occurred for genome {0} at point {1} and produced {2}", genome, mutatePoint, afterMutate));

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

                    genome1.Moves.CopyTo(frontChild.Moves, 0);
                    genome2.Moves.CopyTo(endChild.Moves, 0);

                    int swapPoint = frontChild.Crossover(endChild);

                    currentPopulation.Add(frontChild);
                    currentPopulation.Add(endChild);

                    PopulationResults.AddMessage(string.Format("Crossover occurred from genome {0} to {1} at point {2} and got {3} and {4}", genome1, genome2, swapPoint, frontChild, endChild));

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
            populationResults.AddHeader(string.Format("Best plays had a score of {0}", currentPopulation.OrderByDescending(c => c.Fitness).Take(1).Single().Fitness));


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