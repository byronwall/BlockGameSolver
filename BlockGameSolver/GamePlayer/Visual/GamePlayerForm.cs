using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using BlockGameSolver.ImageAnalyzer.Core;
using BlockGameSolver.ImageAnalyzer.Utility;
using BlockGameSolver.ImageAnalyzer.Visual;
using BlockGameSolver.Simulation.Core;
using BlockGameSolver.Simulation.Visual;

namespace BlockGameSolver.GamePlayer.Visual
{
    public partial class GamePlayerForm : Form
    {
        private Analyzer analyzer;
        private string boardDataPath = "boardData.xml";

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
            analyzer.SetScreenshot(screenshot);

            Board board = Board.FromIBoardSource(analyzer);
            Board.SetInstance(board);
        }

        private void GamePlayerForm_Load(object sender, EventArgs e)
        {
            if (File.Exists(boardDataPath))
            {
                ImageSettings settings = ImageSettings.LoadDataFromXML(boardDataPath);
                analyzer = new Analyzer(settings);
            }
        }
    }
}