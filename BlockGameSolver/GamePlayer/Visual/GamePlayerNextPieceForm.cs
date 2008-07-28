using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using BlockGameSolver.Properties;
using BlockGameSolver.Simulation.Core;
using BlockGameSolver.Simulation.Visual;

namespace BlockGameSolver.GamePlayer.Visual
{
    public partial class GamePlayerNextPieceForm : Form
    {
        public GamePlayerNextPieceForm()
        {
            InitializeComponent();
        }

        public GamePlayerNextPieceForm(List<Piece> pieces) : this()
        {
            tableBoard.Visible = false;
            tableBoard.Controls.Clear();

            foreach (Piece piece in pieces)
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

                back.BackColor = BoardSettings.Colors[piece.Color - 1];
                tableBoard.Controls.Add(back, piece.Column, piece.Row);
            }

            tableBoard.Visible = true;
        }
    }
}