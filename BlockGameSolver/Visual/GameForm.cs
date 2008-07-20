using System;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using BlockGameSolver.Core;

namespace BlockGameSolver.Visual
{
    public partial class GameForm : Form
    {
        private readonly Color[] colors = new[] {Color.Blue, Color.Red, Color.Green, Color.Orange, Color.Purple};
        private Genome Best;
        private BoardMode boardMode = BoardMode.FreePlay;
        private int currentMove;
        private Population population;

        public GameForm()
        {
            InitializeComponent();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            int popSize = (int) numPopSize.Value;
            int initSize = (int) numInitialSize.Value;

            int generations = (int) numGenerations.Value;
            double filterRate = (double) numFilterRate.Value;
            double mutateRatio = (double) numMutateRatio.Value;
            double crossRatio = (double) numCrossRate.Value;

            PopulationSettings settings = new PopulationSettings(generations, popSize, mutateRatio, filterRate, initSize,
                                                                 crossRatio);

            population = new Population(settings);
            population.PopulationFinished += population_PopulationFinished;
            population.GenerationCompleted += population_GenerationCompleted;

            btnRun.Enabled = false;
            btnViewResults.Enabled = false;

            progCompleted.Minimum = 0;
            progCompleted.Maximum = generations;

            Board.Instance.LoadOldBoard();

            Thread t = new Thread(population.BeginGeneticProcess) {IsBackground = true};
            t.Start();
        }

        private void population_GenerationCompleted(object sender, GenerationEventArgs e)
        {
            UpdateProgress(e.GenerationNumber);
        }

        private void population_PopulationFinished(object sender, EventArgs e)
        {
            EnableButton();
        }

        private void UpdateProgress(int generation)
        {
            if (!InvokeRequired)
            {
                progCompleted.Value = generation;
            }
            else
            {
                Invoke(new Action<int>(UpdateProgress), generation);
            }
        }

        private void EnableButton()
        {
            if (!InvokeRequired)
            {
                btnRun.Enabled = true;
                btnViewResults.Enabled = true;
                btnPlayBest.Enabled = true;
                Best = population.GenomeBest;
                txtBestResult.Text = Best.ToString();
                txtBestFitness.Text = Best.Fitness.ToString();
            }
            else
            {
                Invoke(new Action(EnableButton));
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            population.PopulationResults.OpenWithExecutable();
        }

        private void GameForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (population != null && population.PopulationResults != null)
            {
                population.PopulationResults.Dispose();
                if (chkDelete.Checked)
                {
                    if (population.PopulationResults.ResultsFilename != null &&
                        File.Exists(population.PopulationResults.ResultsFilename))
                    {
                        File.Delete(population.PopulationResults.ResultsFilename);
                    }
                    if (population.PopulationResults.ScoreFilename != null &&
                        File.Exists(population.PopulationResults.ScoreFilename))
                    {
                        File.Delete(population.PopulationResults.ScoreFilename);
                    }
                }
            }
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            currentMove = 0;
            boardMode = BoardMode.FreePlay;
            Board.Instance.LoadOldBoard();
            tableBoard.ColumnCount = GameSettings.Columns;
            tableBoard.RowCount = GameSettings.Rows;

            RedrawBoard();
        }

        private void back_MouseClick(object sender, MouseEventArgs e)
        {
            Panel send = (Panel) sender;
            Piece piece = (Piece) send.Tag;

            Board.Instance.RemoveGroup(piece.Row, piece.Col);
            RedrawBoard();
        }

        private void RedrawBoard()
        {
            tableBoard.Visible = false;
            tableBoard.Controls.Clear();

            foreach (Piece piece in Board.Instance.Pieces)
            {
                if (piece == null) continue;
                Panel back = new Panel {Tag = piece, Size = new Size(15, 15)};

                if (chkBoardLabels.Checked)
                {
                    Label lblPieceNum = new Label {Text = piece.ToString(), Enabled = false};
                    back.Controls.Add(lblPieceNum);
                }
                if (Board.Instance.HasMoves && boardMode == BoardMode.FreePlay)
                {
                    back.MouseClick += back_MouseClick;
                }
                back.BackColor = colors[piece.Color - 1];
                tableBoard.Controls.Add(back, piece.Col, piece.Row);
            }


            tableBoard.Visible = true;
            txtScore.Text = Board.Instance.Score.ToString();
        }

        private void btnPlayBest_Click(object sender, EventArgs e)
        {
            //Move the best result over to the board to see it played.
            currentMove = 0;
            boardMode = BoardMode.GuidedPlay;
            Board.Instance.LoadOldBoard();
            RedrawBoard();
            btnNextMove.Enabled = true;
            lblPlayingMode.Text = string.Format("Board: {0}", boardMode);
            btnNextMove.Text = string.Format("next: {0}", Best.Moves[currentMove]);
        }

        private void chkBoardLabels_CheckedChanged(object sender, EventArgs e)
        {
            RedrawBoard();
        }

        private void btnNextMove_Click(object sender, EventArgs e)
        {
            Board.Instance.RemoveGroup(Best.Moves[currentMove++].Value);

            btnNextMove.Text = string.Format("next: {0}", Best.Moves[currentMove]);

            RedrawBoard();
            if (currentMove == Best.MoveCount)
            {
                Board.Instance.RemoveGroup(0);
                RedrawBoard();
                btnNextMove.Enabled = false;
            }
        }
    }

    internal enum BoardMode
    {
        FreePlay,
        GuidedPlay
    }
}