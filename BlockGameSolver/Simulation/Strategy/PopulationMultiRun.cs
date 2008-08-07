using System.Collections.Generic;
using BlockGameSolver.Simulation.Core;

namespace BlockGameSolver.Simulation.Strategy
{
    internal class PopulationMultiRun : PopulationSingleRun
    {
        private readonly List<Genome> bestGenomes = new List<Genome>();

        public PopulationMultiRun(PopulationSettings settings, Board board) : base(settings, board)
        {
        }

        public PopulationMultiRun(Board board) : base(board)
        {
        }

        public override void InitializeAndRun()
        {
            for (int i = 0; i < 15; i++)
            {
                base.InitializeAndRun();
                bestGenomes.Add(GenomeBest);
            }
            currentPopulation.Clear();
            foreach (Genome genome in bestGenomes)
            {
                currentPopulation.Add(genome);
            }
        }
    }
}