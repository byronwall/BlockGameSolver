using BlockGameSolver.Simulation.Core;

namespace BlockGameSolver.Simulation.Strategy
{
    class PopulationMultiRunSuperPopulation : PopulationMultiRun
    {
        public PopulationMultiRunSuperPopulation(PopulationSettings settings, Board board) : base(settings, board)
        {
        }

        public PopulationMultiRunSuperPopulation(Board board) : base(board)
        {
        }

        public override void InitializeAndRun()
        {
            base.InitializeAndRun();

            CreateNextGeneration();
            RunCurrentGeneration();
        }
    }
}