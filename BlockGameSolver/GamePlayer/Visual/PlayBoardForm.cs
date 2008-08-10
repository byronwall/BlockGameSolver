using System;
using System.Windows.Forms;
using BlockGameSolver.GamePlayer.Core;

namespace BlockGameSolver.GamePlayer.Visual
{
    public partial class PlayBoardForm : Form
    {
        public PlayBoardForm()
        {
            InitializeComponent();
        }

        private void btnPlayBoard_Click(object sender, EventArgs e)
        {
            try
            {
                Hide();
                using (GameManager manager = new GameManager())
                {
                    manager.Start();
                    manager.ReadyToReturn.WaitOne();
                }

                Show();
            }
            catch (Exception)
            {
                MessageBox.Show("Board was not found on the screen.  No harm.  Try again.");
                Show();
            }
        }
    }
}