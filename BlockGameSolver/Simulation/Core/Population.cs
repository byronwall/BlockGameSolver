using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using BlockGameSolver.Simulation.Utility;

namespace BlockGameSolver.Simulation.Core
{
    public class Population
    {
        private readonly Board board;
        private readonly List<Genome> currentPopulation = new List<Genome>();
        private readonly List<Genome> newPopulation = new List<Genome>();
        private readonly MersenneTwister rng = new MersenneTwister();
        private readonly Queue<Genome> upcomingMoves = new Queue<Genome>();
        private int generationNum;

        private bool isWritingToDisk;
        private PopulationSettings settings;

        public Population(PopulationSettings settings, Board board)
        {
            this.settings = settings;
            this.board = board;
        }

        public Population(Board board) : this(PopulationSettings.Default, board)
        {
        }

        public Genome GenomeBest
        {
            get { return currentPopulation.OrderByDescending(c => c.Fitness).Take(1).Single(); }
        }

        public bool IsWritingToDisk
        {
            get { return isWritingToDisk; }
            set { isWritingToDisk = value; }
        }

        public Board PopulationBoard
        {
            get { return board; }
        }

        public bool IsReseedRequired { get; set; }

        private void GenerateInitialPopulation()
        {
            currentPopulation.Clear();
            for (int i = 0; i < settings.InitialPopulationSize; i++)
            {
                currentPopulation.Add(new Genome(PopulationBoard));
            }
        }

        private void RunCurrentGeneration()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            foreach (Genome genome in currentPopulation)
            {
                genome.Evaluate();
            }
            stopwatch.Stop();
        }

        /// <summary>
        /// Selects a random genome using the roulette wheel method.
        /// </summary>
        /// <returns></returns>
        private Genome SelectGenome()
        {
            if (upcomingMoves.Count == 0) CreateUpcomingMoveQueue();
            return upcomingMoves.Dequeue();
        }

        private void CreateUpcomingMoveQueue()
        {
            double totalFitness = 0;
            foreach (Genome genome in currentPopulation)
            {
                totalFitness += genome.Fitness;
            }
            for (int i = 0; i < settings.MoveCache; i++)
            {
                double runningTotal = 0;
                double stopPoint = rng.Next(0, (int) totalFitness);

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

        private void CreateNextGeneration()
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

                    Genome frontChild = Genome.FromGenome(genome1);
                    Genome endChild = Genome.FromGenome(genome2);
                    
                    frontChild.Crossover(endChild);

                    newPopulation.Add(frontChild);
                    newPopulation.Add(endChild);


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
            if (IsReseedRequired) RandomSource.Reseed((int) DateTime.Now.Ticks);


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
            if (populationFinishedHandler != null) populationFinishedHandler(this, e);
        }

        public event EventHandler<GenerationEventArgs> GenerationCompleted;

        private void InvokeGenerationCompleted(GenerationEventArgs e)
        {
            EventHandler<GenerationEventArgs> generationCompletedHandler = GenerationCompleted;
            if (generationCompletedHandler != null) generationCompletedHandler(this, e);
        }

        public Genome DetermineBestGenome()
        {
            BeginGeneticProcess();
            return GenomeBest;
        }
    }
}