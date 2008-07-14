namespace BlockGameSolver.Core
{
    public struct PopulationSettings
    {
        private readonly double filterRate;
        private readonly int maxGenerations;
        private readonly double mutateCrossRatio;
        private readonly int populationSize;

        public PopulationSettings(int maxGenerations, int populationSize, double mutateCrossRatio, double filterRate)
        {
            this.maxGenerations = maxGenerations;
            this.filterRate = filterRate;
            this.mutateCrossRatio = mutateCrossRatio;
            this.populationSize = populationSize;
        }

        public int FilterSize
        {
            get { return (int) (populationSize * filterRate); }
        }

        public double MutateCrossRatio
        {
            get { return mutateCrossRatio; }
        }

        public int MaxGenerations
        {
            get { return maxGenerations; }
        }

        public int PopulationSize
        {
            get { return populationSize; }
        }
    }
}