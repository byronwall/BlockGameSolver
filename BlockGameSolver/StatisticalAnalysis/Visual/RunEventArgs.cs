using System;

namespace BlockGameSolver.StatisticalAnalysis.Visual
{
    internal class RunEventArgs : EventArgs
    {
        public RunEventArgs(int runNumber)
        {
            this.runNumber = runNumber;
        }

        public int runNumber { get; set; }
    }
}