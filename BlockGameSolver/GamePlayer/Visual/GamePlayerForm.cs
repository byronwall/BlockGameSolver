using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using BlockGameSolver.GamePlayer.Core;
using BlockGameSolver.ImageAnalyzer.Core;
using BlockGameSolver.ImageAnalyzer.Utility;
using BlockGameSolver.ImageAnalyzer.Visual;
using BlockGameSolver.Simulation.Core;
using BlockGameSolver.Simulation.Visual;
using BlockGameSolver.StatisticalAnalysis.Visual;
using DataFormats = System.Windows.DataFormats;
using Point = BlockGameSolver.Simulation.Core.Point;

namespace BlockGameSolver.GamePlayer.Visual
{
    public partial class GamePlayerForm : Form
    {
        private readonly GamePlayerNextPieceForm nextPieceForm = new GamePlayerNextPieceForm();
        private Analyzer analyzer;
        private Genome bestGenome;
        private string boardDataPath = "boardData.xml";
        private int currentIndex;
        private Population population;
        private Timer timer;

        public GamePlayerForm()
        {
            InitializeComponent();
        }

        private void btnShowSim_Click(object sender, EventArgs e)
        {
            new GameForm(population).Show();
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
                Bitmap screenshot = BitmapUtility.BitmapFromScreenshot(this);
                analyzer.SetScreenshot(screenshot);

                Board board = Board.FromIBoardSource(analyzer);

                population = new Population(board);
                bestGenome = population.DetermineBestGenome();
                timer = new Timer { Interval = 1500 };
                timer.Tick += timer_Tick;
                timer.Start();
            }
            catch (Exception)
            {
                MessageBox.Show("Board was not found on the screen.  No harm.  Try again.");
            }
        }

        void hook_KeyPressed(object sender, KeyPressedEventArgs e)
        {
            if (timer != null && timer.Enabled)
            {
                timer.Start();
                ShowNextMove();
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            ShowNextMove();
        }

        private void ShowNextMove()
        {
            if (bestGenome.Moves[currentIndex] == null)
            {
                timer.Stop();
                nextPieceForm.Hide();
                return;
            }
            Point locationFromNumber = GameSettings.GetLocationFromNumber(bestGenome.Moves[currentIndex].Value);
            System.Drawing.Point location = analyzer.GetPointFromLocation(locationFromNumber.RowInc, locationFromNumber.ColInc, new System.Drawing.Point(0, 0));

            nextPieceForm.Hide();
            nextPieceForm.Location = location;
            nextPieceForm.UpdateMoveNum(currentIndex);

            nextPieceForm.Show();
            currentIndex++;
        }

        private void GamePlayerForm_Load(object sender, EventArgs e)
        {
            if (File.Exists(boardDataPath))
            {
                analyzer = new Analyzer(ImageSettings.LoadDataFromXML(boardDataPath));
            }
            hook = new KeyboardHook();
            hook.KeyPressed += hook_KeyPressed;
            hook.RegisterHotKey(Core.ModifierKeys.Control|Core.ModifierKeys.Alt, Keys.F3);

        }
        KeyboardHook hook;

        private void btnPlayBoard_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] strings = (string[])e.Data.GetData(DataFormats.FileDrop);
                string path = strings[0];

                analyzer.SetScreenshot(path);
                population = new Population(Board.FromIBoardSource(analyzer));
            }
        }

        private void btnPlayBoard_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void btnShowStats_Click(object sender, EventArgs e)
        {
            new StatBootstrapForm().Show();
        }

        private void GamePlayerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            hook.Dispose();
        }
    }
}