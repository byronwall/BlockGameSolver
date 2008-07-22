using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace BlockGameSolver.Core
{
    public class Population
    {
        private readonly Results populationResults = new Results();
        private readonly Queue<Genome> upcomingMoves = new Queue<Genome>();
        private List<Genome> currentPopulation = new List<Genome>();
        private int generationNum;
        private List<Genome> newPopulation = new List<Genome>();

        private PopulationSettings settings;

        public Population(PopulationSettings settings)
        {
            this.settings = settings;
        }

        public Results PopulationResults
        {
            get { return populationResults; }
        }

        public Genome GenomeBest
        {
            get { return currentPopulation.OrderByDescending(c => c.Fitness).Take(1).Single(); }
        }

        private void GenerateInitialPopulation()
        {
            currentPopulation.Clear();
            for (int i = 0; i < settings.InitialPopulationSize; i++)
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
                PopulationResults.AddEvaluationResult(generationNum, genome, genome.Fitness);
            }
            stopwatch.Stop();
            populationResults.AddMessage(string.Format("The run took {0} milliseconds.", stopwatch.ElapsedMilliseconds));
        }

        /// <summary>
        /// Selects a random genome using the roulette wheel method.
        /// </summary>
        /// <returns></returns>
        private Genome SelectGenome()
        {
            if (upcomingMoves.Count == 0)
            {
                double totalFitness = 0;
                foreach (Genome genome in currentPopulation)
                {
                    totalFitness += genome.Fitness;
                }
                for (int i = 0; i < settings.MoveCache; i++)
                {
                    double runningTotal = 0;
                    double stopPoint = RandomSource.Instance.Next(0, (int) totalFitness);

                    foreach (Genome genome in currentPopulation)
                    {
                        runningTotal += genome.Fitness;
                        if (runningTotal > stopPoint)
                        {
                            upcomingMoves.Enqueue(genome);
                            break;
                        }
                    }
                }
            }
            return upcomingMoves.Dequeue();
        }

        private void CreateNextGeneration()
        {
            PopulationResults.AddMessage("Creating the next generation.");
            MersenneTwister rng = RandomSource.Instance;
            newPopulation.Clear();
            //Elite selection
            newPopulation.AddRange(currentPopulation.OrderByDescending(c => c.Fitness).Take(settings.FilterSize));
            ////Add in the ones that were kept.
            //foreach (Genome genome in newPopulation)
            //{
            //    currentPopulation.Add(genome);
            //}

            for (int i = 0; i < settings.PopulationSize - settings.FilterSize; i++)
            {
                //Determine if a cross-over should occur
                if (rng.NextDoublePositive() < settings.CrossoverRatio)
                {
                    //This indicates a cross over should occur

                    Genome genome1 = SelectGenome();
                    Genome genome2 = SelectGenome();

                    Genome frontChild = Genome.FromGenome(genome1);
                    Genome endChild = Genome.FromGenome(genome2);

                    int swapPoint = frontChild.Crossover(endChild);

                    newPopulation.Add(frontChild);
                    newPopulation.Add(endChild);

                    PopulationResults.AddMessage(
                        string.Format("Crossover occurred from genome {0} to {1} at point {2} and got {3} and {4}",
                                      genome1, genome2, swapPoint, frontChild, endChild));

                    //Determine if the results should be mutated

                    //Mutate the last crossover result
                    frontChild.Mutate(settings.MutateRatio);
                    endChild.Mutate(settings.MutateRatio);
                }
                else
                {
                    //This indicates that a direct replication should occur.
                    Genome directCopy = Genome.FromGenome(SelectGenome());
                    directCopy.Mutate(settings.MutateRatio);
                    currentPopulation.Add(directCopy);
                }
            }
            currentPopulation.Clear();
            foreach (Genome genome in newPopulation)
            {
                currentPopulation.Add(genome);
            }
        }

        private void FilterCurrentGeneration()
        {
            PopulationResults.AddMessage("Filtering the current generation.");

            newPopulation.AddRange(currentPopulation.OrderByDescending(c => c.Fitness).Take(settings.FilterSize));
            // newPopulation = currentPopulation.OrderByDescending(c => c.Fitness).Take(keepers).ToList();

            //foreach (Genome genome in newPopulation)
            //{
            //    populationResults.AddMessage(string.Format("Genome with fitness {0} survived.", genome.Fitness));
            //}

            //   currentPopulation.Clear();
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

        public void BeginGeneticProcess()
        {
            PopulationResults.AddHeader("Beginning the process");

            GenerateInitialPopulation();
            for (int i = 0; i < settings.MaxGenerations; i++)
            {
                generationNum = i + 1;
                ContinueEvaluation();
            }
            populationResults.AddHeader(string.Format("Best plays had a score of {0}",
                                                      currentPopulation.OrderByDescending(c => c.Fitness).Take(1).Single
                                                          ().Fitness));

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