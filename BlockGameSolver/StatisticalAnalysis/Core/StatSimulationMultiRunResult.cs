using BlockGameSolver.Simulation.Core;

namespace BlockGameSolver.StatisticalAnalysis.Core
{
    public class StatSimulationMultiRunResult
    {
        private readonly PopulationSettings settings;

        public StatSimulationMultiRunResult(PopulationSettings settings, string settingsString)
        {
            this.settings = settings;
            SettingsString = settingsString;
        }

        public PopulationSettings Settings
        {
            get { return settings; }
        }

        public string SettingsString { get; private set; }

        public double AverageScore { get; set; }

        public double StandardDeviation { get; set; }

        public override string ToString()
        {
            return string.Format("{0},{1},{2}", SettingsString, AverageScore, StandardDeviation);
        }
    }
}