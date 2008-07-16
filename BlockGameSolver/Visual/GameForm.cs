using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using BlockGameSolver.Core;

namespace BlockGameSolver.Visual
{
    public partial class GameForm : Form
    {
        private Population population;

        public GameForm()
        {
            InitializeComponent();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            int popSize = (int)numPopSize.Value;
            int initSize = (int)numInitialSize.Value;

            int generations = (int)numGenerations.Value;
            double filterRate = (double)numFilterRate.Value;
            double crossMutate = (double)numCrossMutate.Value;


            PopulationSettings settings = new PopulationSettings(generations, popSize, crossMutate, filterRate, initSize);

            population = new Population(settings);
            population.PopulationFinished += population_PopulationFinished;
            population.GenerationCompleted += population_GenerationCompleted;

            btnRun.Enabled = false;
            btnViewResults.Enabled = false;

            progCompleted.Minimum = 0;
            progCompleted.Maximum = generations;

            Board.Instance.LoadOldBoard();

            new Thread(population.BeginGeneticProcess).Start();
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
                Invoke(new UpdatedProgress(UpdateProgress), generation);
            }
        }

        private void EnableButton()
        {
            if (!InvokeRequired)
            {
                btnRun.Enabled = true;
                btnViewResults.Enabled = true;
            }
            else
            {
                Invoke(new EnabledButton(EnableButton));
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
                if (chkDelete.Checked && population.PopulationResults.ResultsFilename != null && File.Exists(population.PopulationResults.ResultsFilename))
                {
                    File.Delete(population.PopulationResults.ResultsFilename);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string filename = population.PopulationResults.DumpScoreData();
            Process.Start("explorer", filename);
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            Board.Instance.LoadOldBoard();
            tableBoard.ColumnCount = GameSettings.Columns;
            tableBoard.RowCount = GameSettings.Rows;

            RedrawBoard();
        }

        private void back_MouseClick(object sender, MouseEventArgs e)
        {
            Panel send = (Panel)sender;
            Piece piece = (Piece)send.Tag;

            Board.Instance.RemoveGroup(piece.Row, piece.Col);
            RedrawBoard();
        }

        private void RedrawBoard()
        {
            tableBoard.Visible = false;
            tableBoard.Controls.Clear();

            for (int i = 0; i < GameSettings.Rows; i++)
            {
                for (int j = 0; j < GameSettings.Columns; j++)
                {
                    Piece piece = Board.Instance[i, j];
                    Panel back = new Panel();
                    Panel back2 = new Panel();
                    back.Tag = piece;

                    back.Size = new Size(15, 15);
                    back2.Size = new Size(15, 15);
                    if (piece != null)
                    {
                        if (Board.Instance.HasMoves)
                        {
                            back.MouseClick += back_MouseClick;
                        }
                        back.BackColor = colors[piece.Color - 1];
                        back2.BackColor = colors[piece.Color - 1];

                    }
                    else
                    {
                        back.BackColor = Color.Transparent;
                        back2.BackColor = Color.Transparent;
                    }
                    tableBoard.Controls.Add(back, j, i);

                }
            }
            tableBoard.Visible = true;
            txtScore.Text = Board.Instance.Score.ToString();

        }

        private readonly Color[] colors = new[] { Color.Blue, Color.Red, Color.Green, Color.Orange, Color.Purple };

        #region Nested type: EnabledButton

        private delegate void EnabledButton();

        #endregion

        #region Nested type: UpdatedProgress

        private delegate void UpdatedProgress(int a);

        #endregion

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RedrawBoard();
        }
    }
}

