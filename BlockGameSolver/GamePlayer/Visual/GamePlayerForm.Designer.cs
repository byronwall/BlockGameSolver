namespace BlockGameSolver.GamePlayer.Visual
{
    partial class GamePlayerForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnPlayBoard = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "round";
            // 
            // btnPlayBoard
            // 
            this.btnPlayBoard.Location = new System.Drawing.Point(13, 119);
            this.btnPlayBoard.Name = "btnPlayBoard";
            this.btnPlayBoard.Size = new System.Drawing.Size(75, 23);
            this.btnPlayBoard.TabIndex = 1;
            this.btnPlayBoard.Text = "play board";
            this.btnPlayBoard.UseVisualStyleBackColor = true;
            // 
            // GamePlayerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.btnPlayBoard);
            this.Controls.Add(this.groupBox1);
            this.Name = "GamePlayerForm";
            this.Text = "GamePlayerForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnPlayBoard;
    }
}