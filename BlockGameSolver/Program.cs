using System;
using System.Windows.Forms;
using BlockGameSolver.GamePlayer.Visual;
using BlockGameSolver.Simulation.Core;
using BlockGameSolver.StatisticalAnalysis.Visual;
using BlockGameSolver.Utility.CommandLine;

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
            CommandLineParser parser = new CommandLineParser(args);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            int seed = (int) DateTime.Now.Ticks;
            
            if (parser["seed"]!=null)
            {
                seed = Convert.ToInt32(parser["seed"]);
            }

            switch (parser["mode"])
            {
                case "profile":
                {
                    Population population = new Population(Board.FromIBoardSource(new StatisticalAnalysis.Core.BoardSourceStatistical(10, 10, seed)));
                    population.DetermineBestGenome();
                
                    return;
                }
                case "stats":
                {
                    Application.Run(new StatBootstrapForm());


                    return;
                }
            }
            
            
            Application.Run(new GamePlayerForm());
        }
    }
}