﻿using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using BlockGameSolver.Properties;
using BlockGameSolver.Simulation.Core;
using BlockGameSolver.Simulation.Strategy;

namespace BlockGameSolver.Simulation.Visual
{
    public partial class GameForm : Form
    {
        private Genome Best;
        private BoardMode boardMode = BoardMode.FreePlay;
        private int currentMove;
        private PopulationBase populationBase;

        public GameForm()
        {
            InitializeComponent();
        }

        public GameForm(PopulationBase populationBase) : this()
        {
            this.populationBase = populationBase;
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

            if (populationBase == null)
            {
                //populationBase = new PopulationSingleRun(settings, Board.CreateRandomBoard());
                populationBase = new PopulationMultiRunSuperPopulation(settings, Board.CreateRandomBoard()) {IsReseedRequired = true};
            }
            populationBase.PopulationFinished += population_PopulationFinished;
            populationBase.GenerationCompleted += population_GenerationCompleted;

            btnRun.Enabled = false;

            progCompleted.Minimum = 0;
            progCompleted.Maximum = generations;

            populationBase.PopulationBoard.LoadOldBoard();

            Thread t = new Thread(populationBase.BeginGeneticProcess) {IsBackground = true};
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
                Best = populationBase.GenomeBest;
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
            populationBase.PopulationBoard.LoadOldBoard();

            RedrawBoard();
        }

        private void back_MouseClick(object sender, MouseEventArgs e)
        {
            Panel send = (Panel) sender;
            Piece piece = (Piece) send.Tag;

            populationBase.PopulationBoard.RemoveGroup(piece.Row, piece.Column);
            RedrawBoard();
        }

        private void RedrawBoard()
        {
            tableBoard.Visible = false;
            tableBoard.Controls.Clear();

            foreach (Piece piece in populationBase.PopulationBoard.Pieces)
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
                if (populationBase.PopulationBoard.HasMoves && boardMode == BoardMode.FreePlay)
                {
                    back.MouseClick += back_MouseClick;
                }
                back.BackColor = BoardSettings.Colors[piece.Color - 1];
                tableBoard.Controls.Add(back, piece.Column, piece.Row);
            }

            tableBoard.Visible = true;
            txtScore.Text = populationBase.PopulationBoard.Score.ToString();
        }

        private void btnPlayBest_Click(object sender, EventArgs e)
        {
            //Move the best result over to the board to see it played.
            currentMove = 0;
            boardMode = BoardMode.GuidedPlay;
            populationBase.PopulationBoard.LoadOldBoard();
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
            populationBase.PopulationBoard.RemoveGroup(Best.Moves[currentMove++].Value);
            UpdateNextButton();

            RedrawBoard();
            if (currentMove == Best.MoveCount)
            {
                populationBase.PopulationBoard.RemoveGroup(0);
                RedrawBoard();
                btnNextMove.Enabled = false;
            }
        }

        private void UpdateNextButton()
        {
            int move = Best.Moves[currentMove] ?? 0;
            RowColumnPoint location = GameSettings.GetLocationFromNumber(move);

            btnNextMove.Text = string.Format("next: {0}- {1},{2}", move, location.Row, location.Column);
        }
    }

    internal enum BoardMode
    {
        FreePlay,
        GuidedPlay
    }
}