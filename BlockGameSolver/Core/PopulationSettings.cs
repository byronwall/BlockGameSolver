namespace BlockGameSolver.Core
{
    public struct PopulationSettings
    {
        private readonly double filterRate;
        private readonly int maxGenerations;
        private readonly double mutateRatio;
        private readonly double crossoverRatio;
        private readonly int populationSize;
        private readonly int initialPopulationSize;
        private readonly int moveCache;

        public PopulationSettings(int maxGenerations, int populationSize, double mutateRatio, double filterRate, int initialPopulationSize, double crossoverRatio)
        {
            moveCache = 50;
            this.maxGenerations = maxGenerations;
            this.crossoverRatio = crossoverRatio;
            this.initialPopulationSize = initialPopulationSize;
            this.filterRate = filterRate;
            this.mutateRatio = mutateRatio;
            this.populationSize = populationSize;
        }

        public int FilterSize
        {
            get { return (int) (populationSize * filterRate); }
        }

        public double MutateRatio
        {
            get { return mutateRatio; }
        }

        public int MaxGenerations
        {
            get { return maxGenerations; }
        }

        public int PopulationSize
        {
            get { return populationSize; }
        }

        public int InitialPopulationSize
        {
            get { return initialPopulationSize; }
        }

        public double CrossoverRatio
        {
            get { return crossoverRatio; }
        }

        public int MoveCache
        {
            get { return moveCache; }
        }
    }
}