using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using BlockGameSolver.Simulation.Core;
using BlockGameSolver.StatisticalAnalysis.Visual;

namespace BlockGameSolver.StatisticalAnalysis.Core
{
    internal class SimulationStats
    {
        private int boardSeed;
        private IBoardSource boardSource;
        private string pathToResults;
        private Population population;
        private PopulationSettings populationSettings;

        private List<Genome> results = new List<Genome>();
        private int runCount;

        public SimulationStats(int runCount, int boardSeed) : this(runCount, boardSeed, PopulationSettings.Default)
        {
        }

        public SimulationStats(int runCount, int boardSeed, string populationSettingsPath) : this(runCount, boardSeed, PopulationSettings.LoadFromXML(populationSettingsPath))

        {
        }

        public SimulationStats(int runCount, int boardSeed, PopulationSettings populationSettings)
        {
            this.runCount = runCount;
            this.boardSeed = boardSeed;
            this.populationSettings = populationSettings;

            boardSource = new BoardSourceStatistical(10, 10, this.boardSeed);
        }

        public string PathToResults
        {
            get { return pathToResults; }
        }

        public void RunAnalysis()
        {
            for (int i = 0; i < runCount; i++)
            {
                population = new Population(populationSettings, Board.FromIBoardSource(boardSource));
                Genome genome = population.DetermineBestGenome();

                results.Add(genome);
                InvokeRunFinished(new RunEventArgs(i + 1));
            }
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
            pathToResults = string.Format("stat_analysis_{0}_{1}", boardSeed, DateTime.Now.ToFileTime());
            Directory.CreateDirectory(PathToResults);

            WriteResults();
            WriteInformationFile();
            return PathToResults;
        }

        private void WriteInformationFile()
        {
            using (FileStream fs = new FileStream(string.Format("{0}\\info.txt", pathToResults), FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine("***ANALYSIS INFORMATION***");
                    sw.WriteLine(population.PopulationBoard);
                    sw.WriteLine(this);
                    sw.WriteLine(populationSettings);
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
                    //Write the output
                    //3.Write out the results
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