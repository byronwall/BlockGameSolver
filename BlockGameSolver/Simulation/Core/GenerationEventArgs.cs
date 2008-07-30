using System;

namespace BlockGameSolver.Simulation.Core
{
    public class GenerationEventArgs : EventArgs
    {
        public GenerationEventArgs(int generationNumber)
        {
            GenerationNumber = generationNumber;
        }

        public int GenerationNumber { get; private set; }
    }
}