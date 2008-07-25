using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BlockGameSolver.ImageAnalyzer.Visual;
using BlockGameSolver.Simulation.Visual;

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

        private void btnShowAnalyzer_Click(object sender, EventArgs e)
        {
            new ImageForm().Show();

        }
    }
}
