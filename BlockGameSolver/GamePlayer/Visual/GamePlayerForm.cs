using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using BlockGameSolver.ImageAnalyzer.Core;
using BlockGameSolver.ImageAnalyzer.Utility;
using BlockGameSolver.ImageAnalyzer.Visual;
using BlockGameSolver.Simulation.Core;
using BlockGameSolver.Simulation.Visual;
using DataFormats = System.Windows.DataFormats;
using Point = System.Drawing.Point;

namespace BlockGameSolver.GamePlayer.Visual
{
    public partial class GamePlayerForm : Form
    {
        private Analyzer analyzer;
        private Genome bestGenome;
        private string boardDataPath = "boardData.xml";
        private int currentIndex = 0;
        private GamePlayerNextPieceForm nextPieceForm;
        private Timer timer;

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

            Population population = new Population();
            bestGenome = population.DetermineBestGenome();
            timer = new Timer {Interval = 2000};
            timer.Tick += timer_Tick;
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (bestGenome.Moves[currentIndex] == null)
            {
                timer.Stop();
                return;
            }
            Simulation.Core.Point locationFromNumber = Board.GetLocationFromNumber(bestGenome.Moves[currentIndex++].Value);
            Point location = analyzer.GetPointFromLocation(locationFromNumber.RowInc, locationFromNumber.ColInc, analyzer.Settings.DoubleOffset);
            Visual.MouseClick.SendClick(location);

        }

        private void GamePlayerForm_Load(object sender, EventArgs e)
        {
            if (File.Exists(boardDataPath))
            {
                ImageSettings settings = ImageSettings.LoadDataFromXML(boardDataPath);
                analyzer = new Analyzer(settings);
            }
        }

        private void btnPlayBoard_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] strings = (string[])e.Data.GetData(DataFormats.FileDrop);
                string path = strings[0];

                analyzer.SetScreenshot(path);
                Board.SetInstance(Board.FromIBoardSource(analyzer));
            }
        }

        private void btnPlayBoard_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }
    }
}