using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BlockGameSolver.Core
{
    public class Results : IDisposable
    {
        private readonly FileStream fs;
        private readonly StreamWriter sw;
        private static Results instance;

        private Results()
        {
            string filename = string.Format("{0} - Results.log", DateTime.Now.Ticks);

            fs = new FileStream(filename, FileMode.Create);
            sw = new StreamWriter(fs);
        }

        public static Results Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Results();
                }
                return instance;
            }
        }

        #region IDisposable Members

        public void Dispose()
        {
            fs.Dispose();
            sw.Dispose();
        }

        #endregion

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

        public void AddEvaluationResult(int generationNum, List<int> moves, double fitness)
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
}