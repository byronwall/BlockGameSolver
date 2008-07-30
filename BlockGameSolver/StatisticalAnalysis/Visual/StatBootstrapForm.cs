using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using BlockGameSolver.StatisticalAnalysis.Core;

namespace BlockGameSolver.StatisticalAnalysis.Visual
{
    public partial class StatBootstrapForm : Form
    {
        private bool isRunning;

        private int runCount;
        private SimulationStats stats;

        public StatBootstrapForm()
        {
            InitializeComponent();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            if (!isRunning)
            {
                isRunning = true;
                runCount = Convert.ToInt32(txtRuns.Text);
                int seed = Convert.ToInt32(txtBoardNum.Text);
                stats = !chkGeneticSettings.Checked ? new SimulationStats(runCount, seed, txtGeneticSettings.Text) : new SimulationStats(runCount, seed);

                stats.RunFinished += stats_RunFinished;
                stats.AnalysisFinished += new EventHandler(stats_AnalysisFinished);

                new Thread(stats.RunAnalysis).Start();
            }
        }

        private void stats_AnalysisFinished(object sender, EventArgs e)
        {
            stats.WriteAnalysis();
            //MessageBox.Show("Run completed");
            Process.Start("explorer", stats.PathToResults);
            isRunning = false;
        }

        private void stats_RunFinished(object sender, RunEventArgs e)
        {
            UpdateProgress(e.runNumber*100/runCount);
        }

        private void UpdateProgress(int runNum)
        {
            if (!InvokeRequired)
            {
                progComplete.Value = runNum;
            }
            else
            {
                Invoke(new Action<int>(UpdateProgress), runNum);
            }
        }

        private void chkGeneticSettings_CheckedChanged(object sender, EventArgs e)
        {
            txtGeneticSettings.Enabled = !chkGeneticSettings.Checked;
        }
    }
}