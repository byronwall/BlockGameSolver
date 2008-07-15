using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using BlockGameSolver.Core;

namespace BlockGameSolver.Visual
{
    public partial class GameForm : Form
    {
        private Board gameBoard;
        private Population population;
        private int removed;

        public GameForm()
        {
            InitializeComponent();
        }

        private void btnNewBoard_Click(object sender, EventArgs e)
        {
            gameBoard = Board.CreateRandomBoard(null, null);
            txtBoard.Text = gameBoard.ToString();
        }

        private void btnGetGroup_Click(object sender, EventArgs e)
        {
            int row = Convert.ToInt32(txtRow.Text);
            int col = Convert.ToInt32(txtCol.Text);

            txtCount.Text = gameBoard.DetermineGroup(row, col, Direction.None).ToString();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            txtBefore.Text = gameBoard.ToString();

            int row = Convert.ToInt32(txtRow.Text);
            int col = Convert.ToInt32(txtCol.Text);

            removed += gameBoard.RemoveGroup(row, col);
            txtBoard.Text = gameBoard.ToString();
            txtCount.Text = gameBoard.PieceCount.ToString();
            txtRemoveTotal.Text = removed.ToString();
        }

        private void btnGapTest_Click(object sender, EventArgs e)
        {
            gameBoard = Board.CreateRandomBoard(null, 2);
            txtBefore.Text = gameBoard.ToString();

            gameBoard.FillEmptySpaces();

            txtBoard.Text = gameBoard.ToString();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            PopulationSettings settings = new PopulationSettings(3, 100, 0.1d, 0.15d);

            population = new Population(settings);
            population.PopulationFinished += population_PopulationFinished;

            btnRun.Enabled = false;
            btnViewResults.Enabled = false;

            new Thread(population.BeginGeneticProcess).Start();
        }

        private void population_PopulationFinished(object sender, EventArgs e)
        {
            EnableButton();
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
            if (chkDelete.Checked)
            {
                population.PopulationResults.Dispose();
                if (population.PopulationResults.Filename != null)
                {
                    if (File.Exists(population.PopulationResults.Filename))
                    {
                        File.Delete(population.PopulationResults.Filename);
                    }
                }
            }
        }

        #region Nested type: EnabledButton

        private delegate void EnabledButton();

        #endregion
    }
}