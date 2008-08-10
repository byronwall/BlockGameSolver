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
        private StatSimulation stats;

        private Stopwatch stopwatch;

        public StatBootstrapForm()
        {
            InitializeComponent();

            txtGeneticSettings.EnableDragDropFilename();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            if (!isRunning)
            {
                isRunning = true;
                runCount = Convert.ToInt32(txtRuns.Text);
                int seed = Convert.ToInt32(txtBoardNum.Text);

                Thread runner = null;

                if (radioSingleRun.Checked)
                {
                    stats = !chkGeneticSettings.Checked ? new StatSimulation(runCount, seed, txtGeneticSettings.Text) : new StatSimulation(runCount, seed);

                    stats.RunFinished += stats_RunFinished;
                    stats.AnalysisFinished += stats_AnalysisFinished;

                    runner = new Thread(stats.RunAnalysis);
                }
                else if (radioMultiRun.Checked)
                {
                    StatSimulationMultiRun multiRun;

                    if (!txtGeneticSettings.Text.IsNullOrEmpty())
                    {
                        multiRun = new StatSimulationMultiRun(runCount, seed, txtGeneticSettings.Text);
                    }
                    else
                    {
                        multiRun = new StatSimulationMultiRun(runCount, seed);
                        multiRun.CreateRandomPopulation(2);
                    }
                    multiRun.ParallelExecution = radioParallel.Checked;
                    multiRun.PercentCompleteChanged += simulationMultiRun_PercentCompleteChanged;
                    multiRun.MultiRunAnalysisComplete += simulationMultiRun_MultiRunAnalysisComplete;
                    runner = new Thread(multiRun.DoMultiRun);
                }
                if (runner != null)
                {
                    stopwatch = Stopwatch.StartNew();
                    runner.Start();
                }
            }
        }

        private void simulationMultiRun_MultiRunAnalysisComplete(object sender, EventArgs e)
        {
            stopwatch.Stop();
            MessageBox.Show(string.Format("Analysis complete in {0} ms.", stopwatch.ElapsedMilliseconds));
            isRunning = false;
        }

        private void simulationMultiRun_PercentCompleteChanged(object sender, PercentCompleteEventArgs e)
        {
            UpdateProgress((int) (e.PercentComplete*100));
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
    }
}