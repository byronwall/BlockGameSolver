using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using BlockGameSolver.ImageAnalyzer.Utility;
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
        /// <summary>
        /// This is the method that is called when the user wishes to play a board on the screen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPlayBoard_Click(object sender, EventArgs e)
        {
            Bitmap screenshot = BitmapUtility.BitmapFromScreenshot(this);
            screenshot.Save("screenshot.jpg", ImageFormat.Png);
        }
    }
}
