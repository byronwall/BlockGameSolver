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
            this.btnShowSim = new System.Windows.Forms.Button();
            this.btnShowAnalyzer = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnShowStats = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnPlayBoard);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(94, 54);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "round";
            // 
            // btnPlayBoard
            // 
            this.btnPlayBoard.AllowDrop = true;
            this.btnPlayBoard.Location = new System.Drawing.Point(6, 19);
            this.btnPlayBoard.Name = "btnPlayBoard";
            this.btnPlayBoard.Size = new System.Drawing.Size(75, 23);
            this.btnPlayBoard.TabIndex = 1;
            this.btnPlayBoard.Text = "play board";
            this.btnPlayBoard.UseVisualStyleBackColor = true;
            this.btnPlayBoard.Click += new System.EventHandler(this.btnPlayBoard_Click);
            this.btnPlayBoard.DragDrop += new System.Windows.Forms.DragEventHandler(this.btnPlayBoard_DragDrop);
            this.btnPlayBoard.DragEnter += new System.Windows.Forms.DragEventHandler(this.btnPlayBoard_DragEnter);
            // 
            // btnShowSim
            // 
            this.btnShowSim.Location = new System.Drawing.Point(6, 19);
            this.btnShowSim.Name = "btnShowSim";
            this.btnShowSim.Size = new System.Drawing.Size(75, 23);
            this.btnShowSim.TabIndex = 2;
            this.btnShowSim.Text = "show sim";
            this.btnShowSim.UseVisualStyleBackColor = true;
            this.btnShowSim.Click += new System.EventHandler(this.btnShowSim_Click);
            // 
            // btnShowAnalyzer
            // 
            this.btnShowAnalyzer.Location = new System.Drawing.Point(6, 48);
            this.btnShowAnalyzer.Name = "btnShowAnalyzer";
            this.btnShowAnalyzer.Size = new System.Drawing.Size(75, 45);
            this.btnShowAnalyzer.TabIndex = 2;
            this.btnShowAnalyzer.Text = "show analyzer";
            this.btnShowAnalyzer.UseVisualStyleBackColor = true;
            this.btnShowAnalyzer.Click += new System.EventHandler(this.btnShowAnalyzer_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnShowSim);
            this.groupBox2.Controls.Add(this.btnShowAnalyzer);
            this.groupBox2.Location = new System.Drawing.Point(12, 72);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(91, 100);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "testing";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnShowStats);
            this.groupBox3.Location = new System.Drawing.Point(13, 179);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(90, 78);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "stats";
            // 
            // btnShowStats
            // 
            this.btnShowStats.Location = new System.Drawing.Point(5, 19);
            this.btnShowStats.Name = "btnShowStats";
            this.btnShowStats.Size = new System.Drawing.Size(75, 45);
            this.btnShowStats.TabIndex = 2;
            this.btnShowStats.Text = "stats";
            this.btnShowStats.UseVisualStyleBackColor = true;
            this.btnShowStats.Click += new System.EventHandler(this.btnShowStats_Click);
            // 
            // GamePlayerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(119, 266);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "GamePlayerForm";
            this.Text = "GamePlayerForm";
            this.Load += new System.EventHandler(this.GamePlayerForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GamePlayerForm_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnPlayBoard;
        private System.Windows.Forms.Button btnShowSim;
        private System.Windows.Forms.Button btnShowAnalyzer;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnShowStats;
    }
}