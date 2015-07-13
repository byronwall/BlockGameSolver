using System;
using System.Windows.Forms;
using BlockGameSolver.Simulation.Core;
using BlockGameSolver.Simulation.Visual;
using BlockGameSolver.StatisticalAnalysis.Visual;

namespace BlockGameSolver.GamePlayer.Visual
{
    public partial class GamePlayerForm : Form
    {
        public GamePlayerForm()
        {
            InitializeComponent();
        }

        private void btnShowSim_Click(object sender, EventArgs e)
        {
            new GameForm().Show();
        }

        private void btnShowStats_Click(object sender, EventArgs e)
        {
            new StatBootstrapForm().Show();
        }
    }
}