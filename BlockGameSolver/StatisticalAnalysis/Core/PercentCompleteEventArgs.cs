using System;

namespace BlockGameSolver.StatisticalAnalysis.Core
{
    public class PercentCompleteEventArgs : EventArgs
    {
        private readonly double percentComplete;

        public PercentCompleteEventArgs(double percentComplete)
        {
            if (percentComplete < 0 || percentComplete > 1)
            {
                throw new ArgumentException("Must be between 0 and 1");
            }
            this.percentComplete = percentComplete;
        }

        public double PercentComplete
        {
            get { return percentComplete; }
        }
    }
}