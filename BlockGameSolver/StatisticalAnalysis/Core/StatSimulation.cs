using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using BlockGameSolver.Simulation.Core;
using BlockGameSolver.Simulation.Strategy;
using BlockGameSolver.StatisticalAnalysis.Visual;

namespace BlockGameSolver.StatisticalAnalysis.Core
{
    internal class StatSimulation
    {
        private readonly int boardSeed;
        private readonly IBoardSource boardSource;
        private readonly PopulationSettings populationSettings;

        private readonly List<Genome> results = new List<Genome>();

        private readonly int runCount;
        private string pathToResults;
        private PopulationSingleRun populationSingleRun;

        public StatSimulation(int runCount, int boardSeed) : this(runCount, boardSeed, PopulationSettings.Default)
        {
        }

        public StatSimulation(int runCount, int boardSeed, string populationSettingsPath) : this(runCount, boardSeed, PopulationSettings.LoadFromXML(populationSettingsPath))
        {
        }

        public StatSimulation(int runCount, int boardSeed, PopulationSettings populationSettings)
        {
            this.runCount = runCount;
            this.boardSeed = boardSeed;
            this.populationSettings = populationSettings;

            boardSource = new BoardSourceStatistical(10, 10, this.boardSeed);
        }

        public List<Genome> Results
        {
            get { return results; }
        }

        public string PathToResults
        {
            get { return pathToResults; }
        }

        public long RunTimeElapsed { get; set; }

        public void RunAnalysis()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            for (int i = 0; i < runCount; i++)
            {
                populationSingleRun = new PopulationSingleRun(populationSettings, Board.FromIBoardSource(boardSource)) {IsReseedRequired = true};
                Genome genome = populationSingleRun.GetBestGenome();

                results.Add(genome);
                InvokeRunFinished(new RunEventArgs(i + 1));
            }
            stopwatch.Stop();
            RunTimeElapsed = stopwatch.ElapsedMilliseconds;
            InvokeAnalysisFinished(EventArgs.Empty);
        }

        public event EventHandler<RunEventArgs> RunFinished;

        private void InvokeRunFinished(RunEventArgs e)
        {
            EventHandler<RunEventArgs> runFinishedHandler = RunFinished;
            if (runFinishedHandler != null)
            {
                runFinishedHandler(this, e);
            }
        }

        public event EventHandler AnalysisFinished;

        private void InvokeAnalysisFinished(EventArgs e)
        {
            EventHandler analysisFinishedHandler = AnalysisFinished;
            if (analysisFinishedHandler != null)
            {
                analysisFinishedHandler(this, e);
            }
        }

        /// <summary>
        /// Writes the results to a file.
        /// </summary>
        /// <returns>The path to the results directory.</returns>
        public string WriteAnalysis()
        {
            WriteAnalysis(string.Format("stat_analysis_{0}_{1}", boardSeed, DateTime.Now.ToFileTime()));

            return PathToResults;
        }

        /// <summary>
        /// Writes the resutls to a directory.
        /// </summary>
        /// <param name="path">The directory which should be created and the results added to.</param>
        public void WriteAnalysis(string path)
        {
            pathToResults = path;
            Directory.CreateDirectory(PathToResults);

            WriteResults();
            WriteInformationFile();
        }

        private void WriteInformationFile()
        {
            using (FileStream fs = new FileStream(string.Format(@"{0}\info.txt", pathToResults), FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine("***ANALYSIS INFORMATION***");
                    sw.WriteLine(pathToResults);
                    sw.WriteLine(populationSingleRun.PopulationBoard);
                    sw.WriteLine(this);
                    sw.WriteLine(populationSettings);
                    sw.WriteLine(string.Format("{0}\t{1}\r\n", "run time:", RunTimeElapsed));
                }
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0}\t{1}\r\n", "board number", boardSeed);
            sb.AppendFormat("{0}\t{1}\r\n", "run count", runCount);

            return sb.ToString();
        }

        private void WriteResults()
        {
            using (FileStream fs = new FileStream(string.Format("{0}\\results.txt", pathToResults), FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine("score\tid");

                    foreach (Genome result in results)
                    {
                        sw.WriteLine(string.Format("{0}\t{1}", result.Fitness, result.GetMoveList()));
                    }
                }
            }
        }
    }
}