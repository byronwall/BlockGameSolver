using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using BlockGameSolver.GamePlayer.Core;
using BlockGameSolver.ImageAnalyzer.Core;
using BlockGameSolver.ImageAnalyzer.Visual;
using BlockGameSolver.Simulation.Core;
using BlockGameSolver.Simulation.Strategy;
using BlockGameSolver.Simulation.Visual;
using BlockGameSolver.StatisticalAnalysis.Visual;
using DataFormats = System.Windows.DataFormats;
using Timer = System.Windows.Forms.Timer;

namespace BlockGameSolver.GamePlayer.Visual
{
    public partial class GamePlayerForm : Form
    {
        private readonly GamePlayerNextPieceForm nextPieceForm = new GamePlayerNextPieceForm();
        private Analyzer analyzer;
        private Genome bestGenome;
        private string boardDataPath = "boardData.xml";
        private int currentIndex;
        private PopulationBase populationSingleRun;
        private Timer timer;

        public GamePlayerForm()
        {
            InitializeComponent();
        }

        private void btnShowSim_Click(object sender, EventArgs e)
        {
            new GameForm(populationSingleRun).Show();
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
            try
            {
                Hide();
                using (GameManager manager = new GameManager())
                {
                    manager.Start();
                    manager.ReadyToReturn.WaitOne();
                }

                Show();
            }
            catch (Exception)
            {
                MessageBox.Show("Board was not found on the screen.  No harm.  Try again.");
                Show();
            }
        }

        private void GamePlayerForm_Load(object sender, EventArgs e)
        {
            analyzer = new Analyzer(ImageSettings.LoadDataFromResource());
        }

        private void btnPlayBoard_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] strings = (string[])e.Data.GetData(DataFormats.FileDrop);
                string path = strings[0];

                analyzer.SetScreenshot(path);
                populationSingleRun = new PopulationSingleRun(Board.FromIBoardSource(analyzer));
            }
        }

        private void btnPlayBoard_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        private void btnShowStats_Click(object sender, EventArgs e)
        {
            new StatBootstrapForm().Show();
        }

        private void GamePlayerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
    }
}