using BlockGameSolver.Simulation.Utility;

namespace BlockGameSolver.Simulation.Core
{
    public class RandomSource
    {
        private static MersenneTwister instance;

        public static MersenneTwister Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MersenneTwister();

                }
                return instance;
            }
        }

        public static void Reseed(int seed)
        {
            instance = new MersenneTwister(seed);
        }
    }
}