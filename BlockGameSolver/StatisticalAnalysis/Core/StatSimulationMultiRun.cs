using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using BlockGameSolver.Simulation.Core;

namespace BlockGameSolver.StatisticalAnalysis.Core
{
    public class StatSimulationMultiRun
    {
        private int boardSeed;

        private string outputPath;
        private string paramHeader;
        private Dictionary<string, int> paramOrder = new Dictionary<string, int>();
        private int runCount;
        private List<StatSimulationMultiRunResult> Settingses = new List<StatSimulationMultiRunResult>();

        public StatSimulationMultiRun(int runCount, int boardSeed)
        {
            this.runCount = runCount;
            this.boardSeed = boardSeed;
        }

        public StatSimulationMultiRun(int runCount, int boardSeed, string path)
            : this(runCount, boardSeed)
        {
            LoadPopulationSettingsFromCSV(path);
        }

        private string outputHeader
        {
            get { return string.Format("{0},{1},{2}", paramHeader, "average", "standardDev"); }
        }

        public void LoadPopulationSettingsFromCSV(string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                using (StreamReader reader = new StreamReader(fs))
                {
                    paramHeader = reader.ReadLine();
                    var splits = paramHeader.Split(new string[] { "," }, StringSplitOptions.None);
                    for (int i = 0; i < splits.Length; i++)
                    {
                        paramOrder.Add(splits[i], i);
                    }

                    while (!reader.EndOfStream)
                    {
                        //filterRate,crossRate,mutateRate,populationSize,generations
                        string param = reader.ReadLine();
                        var paramSplits = param.Split(new string[] { "," }, StringSplitOptions.None);

                        double crossRate = Convert.ToDouble(paramSplits[paramOrder["crossRate"]]);
                        double filterRate = Convert.ToDouble(paramSplits[paramOrder["filterRate"]]);
                        double mutateRate = Convert.ToDouble(paramSplits[paramOrder["mutateRate"]]);
                        int populationSize = (int)Convert.ToDouble(paramSplits[paramOrder["populationSize"]]);
                        int generations = (int)Convert.ToDouble(paramSplits[paramOrder["generations"]]);

                        PopulationSettings settings = new PopulationSettings(generations, populationSize, mutateRate, filterRate, populationSize, crossRate);

                        StatSimulationMultiRunResult result = new StatSimulationMultiRunResult(settings, param);

                        Settingses.Add(result);
                    }
                }
            }
        }

        public void DoMultiRun()
        {
            double count = 0;
            foreach (StatSimulationMultiRunResult result in Settingses)
            {
                StatSimulation simulation = new StatSimulation(runCount, boardSeed, result.Settings);

                simulation.RunAnalysis();
                result.AverageScore = simulation.Results.Average(c => c.Fitness);
                result.StandardDeviation = simulation.Results.StandardDeviation(c => c.Fitness);

                InvokePercentCompleteChanged(new PercentCompleteEventArgs(++count / Settingses.Count));
            }
            WriteToFile("stat_results.csv");
            InvokeMultiRunAnalysisComplete(EventArgs.Empty);
        }

        public void WriteToFile(string path)
        {
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.WriteLine(outputHeader);
                    foreach (StatSimulationMultiRunResult result in Settingses)
                    {
                        writer.WriteLine(result);
                    }
                }
            }
        }

        public event EventHandler<PercentCompleteEventArgs> PercentCompleteChanged;

        private void InvokePercentCompleteChanged(PercentCompleteEventArgs e)
        {
            EventHandler<PercentCompleteEventArgs> percentCompleteChangedHandler = PercentCompleteChanged;
            if (percentCompleteChangedHandler != null)
            {
                percentCompleteChangedHandler(this, e);
            }
        }

        public event EventHandler MultiRunAnalysisComplete;

        private void InvokeMultiRunAnalysisComplete(EventArgs e)
        {
            EventHandler multiRunAnalysisCompleteHandler = MultiRunAnalysisComplete;
            if (multiRunAnalysisCompleteHandler != null)
            {
                multiRunAnalysisCompleteHandler(this, e);
            }
        }
    }

    public class PercentCompleteEventArgs : EventArgs
    {
        private double percentComplete;

        public double PercentComplete
        {
            get { return percentComplete; }
        }

        public PercentCompleteEventArgs(double percentComplete)
        {
            if (percentComplete < 0 || percentComplete > 1)
            {
                throw new ArgumentException("Must be between 0 and 1");

            }
            this.percentComplete = percentComplete;
        }
    }
}