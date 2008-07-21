using System;
using System.Windows.Forms;
using BlockGameSolver.Core;
using BlockGameSolver.Visual;

namespace BlockGameSolver
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main(string[] args)
        {
            int seed;
            if (args.Length == 0 || args[0] == null)
            {
                seed = (int)DateTime.Now.Ticks;
            }
            else
            {
                seed = Convert.ToInt32(args[0]);
            }
            RandomSource.Reseed(seed);


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new GameForm());
        }
    }
}