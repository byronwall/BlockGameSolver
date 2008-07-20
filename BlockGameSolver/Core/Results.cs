using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace BlockGameSolver.Core
{
    public class Results : IDisposable
    {
        private static readonly object locker = new object();
        private readonly FileStream fs;

        private readonly List<List<double>> scoreData = new List<List<double>>();
        private readonly StreamWriter sw;

        public Results()
        {
            ResultsFilename = string.Format("{0} - Results.log", DateTime.Now.Ticks);

            fs = new FileStream(ResultsFilename, FileMode.Create);
            sw = new StreamWriter(fs);
        }

        public string ResultsFilename { get; private set; }
        public string ScoreFilename { get; private set; }

        public List<List<double>> ScoreData
        {
            get { return scoreData; }
        }

        #region IDisposable Members

        public void Dispose()
        {
            fs.Dispose();
        }

        #endregion

        public void OpenWithExecutable()
        {
            OpenWithExecutable("notepad.exe");
        }

        public void OpenWithExecutable(string executable)
        {
            Process.Start(executable, ResultsFilename);
            Process.Start(executable, ScoreFilename);

        }

        public void AddHeader(string header)
        {
            sw.WriteLine(string.Format("*** {0} ***", header));
        }

        public void AddEvaluationResult(int generationNum, string moves, double fitness)
        {
            sw.WriteLine(string.Format("{0}\t{1}\t{2}\t{3}", DateTime.Now.Ticks, generationNum, fitness, moves));
        }

        public void AddMessage(string message)
        {
            sw.WriteLine(string.Format("{0}\t{1}", DateTime.Now.Ticks, message));
        }

        public void AddEvaluationResult(int generationNum, Genome genome, double fitness)
        {
            sw.WriteLine(string.Format("{0}\t{1}\t{2}\t{3}", DateTime.Now.Ticks, generationNum, fitness, genome));
        }

        public void FinishOutput()
        {
            sw.Flush();
            DumpScoreData();
        }

        public string DumpScoreData()
        {
            if (ScoreFilename != null)
            {
                return ScoreFilename;
            }
            ScoreFilename = string.Format("{0} - Scores.log", DateTime.Now.Ticks);
            using (FileStream dump = new FileStream(ScoreFilename, FileMode.Create))
            {
                using (StreamWriter dumpWriter = new StreamWriter(dump))
                {
                    for (int j = 0; j < scoreData[0].Count; j++)
                    {
                        for (int i = 0; i < scoreData.Count; i++)
                        {
                            dumpWriter.Write(scoreData[i][j]);
                            dumpWriter.Write("\t");
                        }
                        dumpWriter.WriteLine();
                    }
                }
            }
            return ScoreFilename;
        }
    }
}