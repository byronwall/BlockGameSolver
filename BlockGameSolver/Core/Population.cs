using System;
using System.Collections.Generic;
using System.Linq;

namespace BlockGameSolver.Core
{
    public class Population
    {
        private readonly List<Genome> currentPopulation = new List<Genome>();
        private List<Genome> newPopulation = new List<Genome>();

        private PopulationSettings settings;
        private int generationNum;

        public Population(PopulationSettings settings)
        {
            this.settings = settings;
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
            Results.Instance.AddMessage("Running the current generation.");
            foreach (Genome genome in currentPopulation)
            {
                genome.Evaluate();
                Results.Instance.AddEvaluationResult(generationNum, genome.Moves, genome.Fitness);
            }
        }

        private void CreateNextGeneration()
        {
            Results.Instance.AddMessage("Creating the next generation.");
            MersenneTwister rng = RandomSource.Instance;
            currentPopulation.Clear();
            foreach (Genome genome in newPopulation)
            {
                currentPopulation.Add(genome);
            }
            for (int i = 0; i < settings.PopulationSize - settings.FilterSize; i++)
            {
                if (rng.NextDouble() < settings.MutateCrossRatio)
                {
                    //Mutate
                    Genome genome = newPopulation[rng.Next(0, settings.FilterSize)];
                    genome.Mutate();
                    currentPopulation.Add(genome);
                }
                else
                {
                    //Crossover
                    Genome genome1 = newPopulation[rng.Next(0, settings.FilterSize)];
                    Genome genome2 = newPopulation[rng.Next(0, settings.FilterSize)];

                    genome1.Crossover(ref genome2);

                    currentPopulation.Add(genome2);
                    currentPopulation.Add(genome1);
                }
            }
        }

        private void FilterCurrentGeneration()
        {
            Results.Instance.AddMessage("Filtering the current generation.");
            int keepers = settings.PopulationSize * settings.FilterSize;

            newPopulation = currentPopulation.OrderBy(c => c.Fitness).Take(keepers).ToList();
            currentPopulation.Clear();
        }

        private void ContinueEvaluation()
        {
            RunCurrentGeneration();
            FilterCurrentGeneration();
            CreateNextGeneration();
        }

        public void BeginGeneticProcess()
        {
            Results.Instance.AddHeader("Beginning the process");

            GenerateInitialPopulation();
            for (int i = 0; i < settings.MaxGenerations; i++)
            {
                generationNum = i + 1;
                ContinueEvaluation();
            }
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
    }
}