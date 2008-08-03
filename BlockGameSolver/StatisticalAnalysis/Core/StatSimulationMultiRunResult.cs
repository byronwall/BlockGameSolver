using BlockGameSolver.Simulation.Core;

namespace BlockGameSolver.StatisticalAnalysis.Core
{
    public class StatSimulationMultiRunResult
    {
        private PopulationSettings settings;

        public PopulationSettings Settings
        {
            get { return settings; }
        }

        public string SettingsString
        {
            get { return settingsString; }
        }

        private double averageScore;
        private double standardDeviation;
        private string settingsString;

        public double AverageScore
        {
            get { return averageScore; }
            set { averageScore = value; }
        }

        public double StandardDeviation
        {
            get { return standardDeviation; }
            set { standardDeviation = value; }
        }

        public override string ToString()
        {
            return string.Format("{0},{1},{2}", settingsString, averageScore, standardDeviation);
        }

        public StatSimulationMultiRunResult(PopulationSettings settings, string settingsString)
        {
            this.settings = settings;
            this.settingsString = settingsString;
        }
    }
}