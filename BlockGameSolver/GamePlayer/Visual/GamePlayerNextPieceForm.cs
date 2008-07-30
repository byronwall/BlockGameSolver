using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace BlockGameSolver.GamePlayer.Visual
{
    public partial class GamePlayerNextPieceForm : Form
    {
        private const int GWL_EXSTYLE = -20;
        private const int WS_EX_TRANSPARENT = 0x20;

        public GamePlayerNextPieceForm()
        {
            InitializeComponent();
        }

        [DllImport("user32.dll", SetLastError = true)]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        private void GamePlayerNextPieceForm_Load(object sender, EventArgs e)
        {
            // Add WS_EX_TRANSPARENT style so that mouse, keyboard etc. events pass through.

            int exstyle = GetWindowLong(Handle, GWL_EXSTYLE);
            exstyle |= WS_EX_TRANSPARENT;
            SetWindowLong(Handle, GWL_EXSTYLE, exstyle);
            Size = new Size(30, 30);
            Timer timer = new Timer();
            timer.Interval = 200;
            timer.Start();
            timer.Tick += new EventHandler(timer_Tick);
        }

        private bool whiteBack;
        void timer_Tick(object sender, EventArgs e)
        {
            whiteBack = !whiteBack;
            if (whiteBack)
            {
                lblMoveNum.ForeColor = Color.Black;
                BackColor = Color.White;
            }
            else
            {
                lblMoveNum.ForeColor = Color.White;
                BackColor = Color.Black;
            }

        }

        public void UpdateMoveNum(int moveNum)
        {
            if (!InvokeRequired)
            {
                lblMoveNum.Text = moveNum.ToString();

            }
            else
            {
                Invoke(new Action<int>(UpdateMoveNum), moveNum);
            }
        }
    }
}