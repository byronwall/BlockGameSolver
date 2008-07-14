namespace BlockGameSolver.Core
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
    }
}