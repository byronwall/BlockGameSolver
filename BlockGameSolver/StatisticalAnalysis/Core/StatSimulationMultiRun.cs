using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using BlockGameSolver.Simulation.Core;
using BlockGameSolver.StatisticalAnalysis.Visual;

namespace BlockGameSolver.StatisticalAnalysis.Core
{
    public class StatSimulationMultiRun
    {
        private readonly int boardSeed;
        private readonly int id;
        private readonly object locker = new object();

        private readonly Dictionary<string, int> paramOrder = new Dictionary<string, int>();
        private readonly int runCount;
        private readonly List<StatSimulationMultiRunResult> Settingses = new List<StatSimulationMultiRunResult>();
        private double count;
        private string paramHeader;

        public StatSimulationMultiRun(int runCount, int boardSeed)
        {
            this.runCount = runCount;
            this.boardSeed = boardSeed;
            id = RandomSource.Instance.Next();
        }

        public StatSimulationMultiRun(int runCount, int boardSeed, string path) : this(runCount, boardSeed)
        {
            LoadPopulationSettingsFromCSV(path);
        }

        private string TopFolder
        {
            get { return string.Format("multi_run_results_{0}", id); }
        }

        private string outputHeader
        {
            get { return string.Format("{0},{1},{2},{3}", ParamHeader, "average", "standardDev", "runTimeElapsed"); }
        }

        public string ParamHeader
        {
            get
            {
                if (paramHeader.IsNullOrEmpty()) paramHeader = PopulationSettings.DefaultParamHeader;
                return paramHeader;
            }
        }

        private double Count
        {
            get
            {
                lock (locker)
                {
                    return count;
                }
            }
            set
            {
                lock (locker)
                {
                    count = value;
                }
            }
        }

        public bool ParallelExecution { get; set; }

        public void CreateRandomPopulation(int paramSetCount)
        {
            for (int i = 0; i < paramSetCount; i++)
            {
                double crossRate = RandomSource.Instance.NextDoublePositive();
                double filterRate = RandomSource.Instance.NextDoublePositive();
                double mutateRate = RandomSource.Instance.NextDoublePositive();
                int populationSize = RandomSource.Instance.Next(20, 100);
                int generations = RandomSource.Instance.Next(1, 50);

                PopulationSettings settings = new PopulationSettings(generations, populationSize, mutateRate, filterRate, populationSize, crossRate);

                StatSimulationMultiRunResult result = new StatSimulationMultiRunResult(settings, settings.DefaultParamString);

                Settingses.Add(result);
            }
        }

        public void LoadPopulationSettingsFromCSV(string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                using (StreamReader reader = new StreamReader(fs))
                {
                    paramHeader = reader.ReadLine();

                    string[] splits = ParamHeader.Split(new[] {","}, StringSplitOptions.None);
                    for (int i = 0; i < splits.Length; i++)
                    {
                        paramOrder.Add(splits[i], i);
                    }

                    while (!reader.EndOfStream)
                    {
                        //filterRate,crossRate,mutateRate,populationSize,generations
                        string param = reader.ReadLine();
                        string[] paramSplits = param.Split(new[] {","}, StringSplitOptions.None);

                        double crossRate = Convert.ToDouble(paramSplits[paramOrder["crossRate"]]);
                        double filterRate = Convert.ToDouble(paramSplits[paramOrder["filterRate"]]);
                        double mutateRate = Convert.ToDouble(paramSplits[paramOrder["mutateRate"]]);
                        int populationSize = Convert.ToInt32(paramSplits[paramOrder["populationSize"]]);
                        int generations = Convert.ToInt32(paramSplits[paramOrder["generations"]]);

                        PopulationSettings settings = new PopulationSettings(generations, populationSize, mutateRate, filterRate, populationSize, crossRate);

                        StatSimulationMultiRunResult result = new StatSimulationMultiRunResult(settings, param);

                        Settingses.Add(result);
                    }
                }
            }
        }

        public void DoMultiRun()
        {
            count = 0;

            if (ParallelExecution) Parallel.ForEach(Settingses, GetResultParallel);
            else
            {
                foreach (StatSimulationMultiRunResult result in Settingses)
                {
                    GetResultParallel(result);
                }
            }
            WriteToFile(string.Format(@"{0}\stat_results.csv", TopFolder));

            InvokeMultiRunAnalysisComplete(EventArgs.Empty);
        }

        private void GetResultParallel(StatSimulationMultiRunResult result)
        {
            StatSimulation simulation = new StatSimulation(runCount, boardSeed, result.Settings);

            simulation.RunAnalysis();
            result.AverageScore = simulation.Results.Average(c => c.Fitness);
            result.StandardDeviation = simulation.Results.StandardDeviation(c => c.Fitness);
            result.RunTimeElapsed = simulation.RunTimeElapsed;
            simulation.WriteAnalysis(string.Format(@"{0}\{1}", TopFolder, result.SettingsString));
            InvokePercentCompleteChanged(new PercentCompleteEventArgs(++Count/Settingses.Count));
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
            if (percentCompleteChangedHandler != null) percentCompleteChangedHandler(this, e);
        }

        public event EventHandler MultiRunAnalysisComplete;

        private void InvokeMultiRunAnalysisComplete(EventArgs e)
        {
            EventHandler multiRunAnalysisCompleteHandler = MultiRunAnalysisComplete;
            if (multiRunAnalysisCompleteHandler != null) multiRunAnalysisCompleteHandler(this, e);
        }
    }
}