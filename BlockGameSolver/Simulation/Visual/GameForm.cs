using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using BlockGameSolver.Properties;
using BlockGameSolver.Simulation.Core;
using Point=BlockGameSolver.Simulation.Core.Point;

namespace BlockGameSolver.Simulation.Visual
{
    public partial class GameForm : Form
    {
        private Genome Best;
        private BoardMode boardMode = BoardMode.FreePlay;
        private int currentMove;
        private Population population;

        public GameForm()
        {
            InitializeComponent();
        }

        public GameForm(Population population) : this()
        {
            this.population = population;
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            int popSize = (int) numPopSize.Value;
            int initSize = (int) numInitialSize.Value;

            int generations = (int) numGenerations.Value;
            double filterRate = (double) numFilterRate.Value;
            double mutateRatio = (double) numMutateRatio.Value;
            double crossRatio = (double) numCrossRate.Value;

            PopulationSettings settings = new PopulationSettings(generations, popSize, mutateRatio, filterRate, initSize, crossRatio);

            if (population == null)
            {
                population = new Population(settings, Board.CreateRandomBoard());
            }
            population.PopulationFinished += population_PopulationFinished;
            population.GenerationCompleted += population_GenerationCompleted;

            btnRun.Enabled = false;

            progCompleted.Minimum = 0;
            progCompleted.Maximum = generations;

            population.PopulationBoard.LoadOldBoard();

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

        private void btnRestart_Click(object sender, EventArgs e)
        {
            currentMove = 0;
            boardMode = BoardMode.FreePlay;
            population.PopulationBoard.LoadOldBoard();

            RedrawBoard();
        }

        private void back_MouseClick(object sender, MouseEventArgs e)
        {
            Panel send = (Panel) sender;
            Piece piece = (Piece) send.Tag;

            population.PopulationBoard.RemoveGroup(piece.Row, piece.Column);
            RedrawBoard();
        }

        private void RedrawBoard()
        {
            tableBoard.Visible = false;
            tableBoard.Controls.Clear();

            foreach (Piece piece in population.PopulationBoard.Pieces)
            {
                if (piece == null)
                {
                    continue;
                }
                Panel back = new Panel {Tag = piece, Size = new Size(15, 15)};

                if (piece.IsDouble)
                {
                    back.BackgroundImage = Resources.doubleBack;
                }

                if (chkBoardLabels.Checked)
                {
                    Label lblPieceNum = new Label {Text = piece.ToString(), Enabled = false};
                    back.Controls.Add(lblPieceNum);
                }
                if (population.PopulationBoard.HasMoves && boardMode == BoardMode.FreePlay)
                {
                    back.MouseClick += back_MouseClick;
                }
                back.BackColor = BoardSettings.Colors[piece.Color - 1];
                tableBoard.Controls.Add(back, piece.Column, piece.Row);
            }

            tableBoard.Visible = true;
            txtScore.Text = population.PopulationBoard.Score.ToString();
        }

        private void btnPlayBest_Click(object sender, EventArgs e)
        {
            //Move the best result over to the board to see it played.
            currentMove = 0;
            boardMode = BoardMode.GuidedPlay;
            population.PopulationBoard.LoadOldBoard();
            RedrawBoard();
            btnNextMove.Enabled = true;
            lblPlayingMode.Text = string.Format("Board: {0}", boardMode);
            UpdateNextButton();
        }

        private void chkBoardLabels_CheckedChanged(object sender, EventArgs e)
        {
            RedrawBoard();
        }

        private void btnNextMove_Click(object sender, EventArgs e)
        {
            population.PopulationBoard.RemoveGroup(Best.Moves[currentMove++].Value);
            UpdateNextButton();

            RedrawBoard();
            if (currentMove == Best.MoveCount)
            {
                population.PopulationBoard.RemoveGroup(0);
                RedrawBoard();
                btnNextMove.Enabled = false;
            }
        }

        private void UpdateNextButton()
        {
            int move = Best.Moves[currentMove] ?? 0;
            Point location = GameSettings.GetLocationFromNumber(move);

            btnNextMove.Text = string.Format("next: {0}- {1},{2}", move, location.RowInc, location.ColInc);
        }
    }

    internal enum BoardMode
    {
        FreePlay,
        GuidedPlay
    }
}