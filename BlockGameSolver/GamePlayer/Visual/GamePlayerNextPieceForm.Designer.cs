using System.Drawing;

namespace BlockGameSolver.GamePlayer.Visual
{
    partial class GamePlayerNextPieceForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblMoveNum = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblMoveNum
            // 
            this.lblMoveNum.AutoSize = true;
            this.lblMoveNum.BackColor = System.Drawing.Color.Transparent;
            this.lblMoveNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMoveNum.Location = new System.Drawing.Point(0, 0);
            this.lblMoveNum.Margin = new System.Windows.Forms.Padding(0);
            this.lblMoveNum.Name = "lblMoveNum";
            this.lblMoveNum.Size = new System.Drawing.Size(34, 25);
            this.lblMoveNum.TabIndex = 0;
            this.lblMoveNum.Text = "35";
            // 
            // GamePlayerNextPieceForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(30, 30);
            this.Controls.Add(this.lblMoveNum);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GamePlayerNextPieceForm";
            this.Opacity = 0.5;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.GamePlayerNextPieceForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMoveNum;

    }
}