using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace BlockGameSolver.Core
{
    public class Results : IDisposable
    {
        private static readonly object locker = new object();
        private readonly FileStream fs;
        private readonly StreamWriter sw;

        public Results()
        {
            Filename = string.Format("{0} - Results.log", DateTime.Now.Ticks);

            fs = new FileStream(Filename, FileMode.Create);
            sw = new StreamWriter(fs);
        }

        public string Filename { get; private set; }

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
            Process.Start(executable, Filename);
        }

        public void AddHeader(string header)
        {
            lock (locker)
            {
                sw.WriteLine(string.Format("*** {0} ***", header));
            }
        }

        public void AddEvaluationResult(int generationNum, string moves, double fitness)
        {
            lock (locker)
            {
                sw.WriteLine(string.Format("{0}\t{1}\t{2}\t{3}", DateTime.Now.Ticks, generationNum, fitness, moves));
            }
        }

        public void AddMessage(string message)
        {
            lock (locker)
            {
                sw.WriteLine(string.Format("{0}\t{1}", DateTime.Now.Ticks, message));
            }
        }

        public void AddEvaluationResult(int generationNum, List<int> moves, double fitness)
        {
            lock (locker)
            {
                StringBuilder sb = new StringBuilder();

                foreach (int i in moves)
                {
                    sb.Append(i);
                    sb.Append(",");
                }
                AddEvaluationResult(generationNum, sb.ToString(), fitness);
            }
        }

        public void FinishOutput()
        {
            sw.Flush();
        }
    }
}