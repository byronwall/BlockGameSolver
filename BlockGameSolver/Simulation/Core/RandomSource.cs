using BlockGameSolver.Simulation.Utility;

namespace BlockGameSolver.Simulation.Core
{
    public class RandomSource
    {
        private static readonly object locker = new object();
        private static MersenneTwister instance;

        public static MersenneTwister Instance
        {
            get
            {
                lock (locker)
                {
                    if (instance == null)
                    {
                        instance = new MersenneTwister();
                    }
                    return instance;
                }
            }
        }

        public static void Reseed(int seed)
        {
            lock (locker)
            {
                instance = new MersenneTwister(seed);
            }
        }
    }
}