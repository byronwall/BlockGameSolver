using System;
using System.Threading;
using System.Windows.Forms;
using BlockGameSolver.GamePlayer.Visual;
using BlockGameSolver.Simulation.Core;
using BlockGameSolver.Simulation.Strategy;
using BlockGameSolver.StatisticalAnalysis.Core;
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
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.Automatic);
            Application.ThreadException += Application_ThreadException;

            int seed = (int) DateTime.Now.Ticks;

            if (parser["seed"] != null) seed = Convert.ToInt32(parser["seed"]);

            switch (parser["mode"])
            {
                case "profile":
                {
                    PopulationSingleRun populationSingleRun = new PopulationSingleRun(Board.FromIBoardSource(new BoardSourceStatistical(10, 10, seed)));
                    populationSingleRun.GetBestGenome();

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

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            MessageBox.Show(e.ToString());
        }
    }
}