using System;
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
            int popSize = (int) numPopSize.Value;
            int generations = (int) numGenerations.Value;
            double filterRate = (double) numFilterRate.Value;
            double crossMutate = (double) numCrossMutate.Value;

            PopulationSettings settings = new PopulationSettings(generations, popSize, crossMutate, filterRate);

            population = new Population(settings);
            population.PopulationFinished += population_PopulationFinished;
            population.GenerationCompleted += population_GenerationCompleted;

            btnRun.Enabled = false;
            btnViewResults.Enabled = false;

            progCompleted.Minimum = 0;
            progCompleted.Maximum = generations;

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
                Invoke(new UpdatedProgress(UpdateProgress),generation);
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
            if (population.PopulationResults != null)
            {
                population.PopulationResults.Dispose();
                if (chkDelete.Checked && population.PopulationResults.Filename != null && File.Exists(population.PopulationResults.Filename))
                {
                    File.Delete(population.PopulationResults.Filename);
                }
            }
        }

        #region Nested type: EnabledButton

        private delegate void EnabledButton();

        private delegate void UpdatedProgress(int a);

        #endregion
    }
}