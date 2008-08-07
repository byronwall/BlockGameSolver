using System;
using System.Collections.Generic;
using System.Linq;
using BlockGameSolver.Simulation.Utility;

namespace BlockGameSolver.Simulation.Core
{
    public abstract class PopulationBase
    {
        private Board board;
        protected readonly List<Genome> currentPopulation = new List<Genome>();
        protected readonly List<Genome> newPopulation = new List<Genome>();
        protected readonly MersenneTwister rng = new MersenneTwister();
        protected readonly Queue<Genome> upcomingMoves = new Queue<Genome>();
        protected GenomeOperations genomeOperations;
        protected int generationNum;
        protected PopulationSettings settings;

        public PopulationBase(PopulationSettings settings, Board board)
        {
            this.settings = settings;
            this.board = board;

            genomeOperations = GenomeOperations.Instance;
        }

        public PopulationBase(Board board) : this(PopulationSettings.Default, board)
        {
        }

        public Genome GenomeBest
        {
            get { return currentPopulation.OrderByDescending(c => c.Fitness).Take(1).Single(); }
        }

        public Board PopulationBoard
        {
            get { return board; }
        }

        public bool IsReseedRequired { get; set; }
        public virtual event EventHandler PopulationFinished;

        protected virtual void InvokePopulationFinished(EventArgs e)
        {
            if (PopulationFinished != null) PopulationFinished(this, e);
        }

        public virtual event EventHandler<GenerationEventArgs> GenerationCompleted;

        protected virtual void InvokeGenerationCompleted(GenerationEventArgs e)
        {
            if (GenerationCompleted != null) GenerationCompleted(this, e);
        }

        /// <summary>
        /// Selects a random genome using the roulette wheel method.
        /// </summary>
        /// <returns></returns>
        protected Genome SelectGenome()
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

        public abstract void BeginGeneticProcess();

        public virtual Genome GetBestGenome()
        {
            BeginGeneticProcess();
            return GenomeBest;
        }
    }
}