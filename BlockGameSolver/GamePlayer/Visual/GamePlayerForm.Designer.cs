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
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton3);
            this.groupBox1.Controls.Add(this.btnPlayBoard);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(94, 130);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "round";
            // 
            // btnPlayBoard
            // 
            this.btnPlayBoard.Location = new System.Drawing.Point(6, 101);
            this.btnPlayBoard.Name = "btnPlayBoard";
            this.btnPlayBoard.Size = new System.Drawing.Size(75, 23);
            this.btnPlayBoard.TabIndex = 1;
            this.btnPlayBoard.Text = "play board";
            this.btnPlayBoard.UseVisualStyleBackColor = true;
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
            this.groupBox2.Location = new System.Drawing.Point(12, 154);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(91, 100);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "testing";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(7, 20);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(61, 17);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "round 1";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(7, 43);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(61, 17);
            this.radioButton2.TabIndex = 0;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "round 2";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(7, 66);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(61, 17);
            this.radioButton3.TabIndex = 0;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "round 3";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // GamePlayerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(119, 266);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "GamePlayerForm";
            this.Text = "GamePlayerForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnPlayBoard;
        private System.Windows.Forms.Button btnShowSim;
        private System.Windows.Forms.Button btnShowAnalyzer;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}