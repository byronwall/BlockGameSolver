namespace BlockGameSolver.StatisticalAnalysis.Visual
{
    partial class StatBootstrapForm
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
            this.btnRun = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBoardNum = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRuns = new System.Windows.Forms.TextBox();
            this.progComplete = new System.Windows.Forms.ProgressBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.radioMultiRun = new System.Windows.Forms.RadioButton();
            this.radioSingleRun = new System.Windows.Forms.RadioButton();
            this.chkGeneticSettings = new System.Windows.Forms.CheckBox();
            this.txtGeneticSettings = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.radioParallel = new System.Windows.Forms.RadioButton();
            this.radioSerialExecution = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(200, 3);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(61, 47);
            this.btnRun.TabIndex = 2;
            this.btnRun.Text = "run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "board #";
            // 
            // txtBoardNum
            // 
            this.txtBoardNum.Location = new System.Drawing.Point(62, 6);
            this.txtBoardNum.Name = "txtBoardNum";
            this.txtBoardNum.Size = new System.Drawing.Size(100, 20);
            this.txtBoardNum.TabIndex = 0;
            this.txtBoardNum.Text = "100";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "runs";
            // 
            // txtRuns
            // 
            this.txtRuns.Location = new System.Drawing.Point(62, 32);
            this.txtRuns.Name = "txtRuns";
            this.txtRuns.Size = new System.Drawing.Size(100, 20);
            this.txtRuns.TabIndex = 1;
            this.txtRuns.Text = "50";
            // 
            // progComplete
            // 
            this.progComplete.Location = new System.Drawing.Point(3, 3);
            this.progComplete.Name = "progComplete";
            this.progComplete.Size = new System.Drawing.Size(191, 23);
            this.progComplete.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.progComplete);
            this.panel1.Controls.Add(this.btnRun);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 166);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(292, 55);
            this.panel1.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.radioMultiRun);
            this.panel2.Controls.Add(this.radioSingleRun);
            this.panel2.Controls.Add(this.chkGeneticSettings);
            this.panel2.Controls.Add(this.txtBoardNum);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txtGeneticSettings);
            this.panel2.Controls.Add(this.txtRuns);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(292, 166);
            this.panel2.TabIndex = 5;
            // 
            // radioMultiRun
            // 
            this.radioMultiRun.AutoSize = true;
            this.radioMultiRun.Checked = true;
            this.radioMultiRun.Location = new System.Drawing.Point(12, 121);
            this.radioMultiRun.Name = "radioMultiRun";
            this.radioMultiRun.Size = new System.Drawing.Size(64, 17);
            this.radioMultiRun.TabIndex = 5;
            this.radioMultiRun.TabStop = true;
            this.radioMultiRun.Text = "multi run";
            this.radioMultiRun.UseVisualStyleBackColor = true;
            // 
            // radioSingleRun
            // 
            this.radioSingleRun.AutoSize = true;
            this.radioSingleRun.Location = new System.Drawing.Point(12, 97);
            this.radioSingleRun.Name = "radioSingleRun";
            this.radioSingleRun.Size = new System.Drawing.Size(70, 17);
            this.radioSingleRun.TabIndex = 4;
            this.radioSingleRun.Text = "single run";
            this.radioSingleRun.UseVisualStyleBackColor = true;
            // 
            // chkGeneticSettings
            // 
            this.chkGeneticSettings.AutoSize = true;
            this.chkGeneticSettings.Checked = true;
            this.chkGeneticSettings.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkGeneticSettings.Location = new System.Drawing.Point(12, 58);
            this.chkGeneticSettings.Name = "chkGeneticSettings";
            this.chkGeneticSettings.Size = new System.Drawing.Size(58, 17);
            this.chkGeneticSettings.TabIndex = 2;
            this.chkGeneticSettings.Text = "default";
            this.chkGeneticSettings.UseVisualStyleBackColor = true;
            // 
            // txtGeneticSettings
            // 
            this.txtGeneticSettings.Location = new System.Drawing.Point(76, 58);
            this.txtGeneticSettings.Name = "txtGeneticSettings";
            this.txtGeneticSettings.Size = new System.Drawing.Size(204, 20);
            this.txtGeneticSettings.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.radioSerialExecution);
            this.panel3.Controls.Add(this.radioParallel);
            this.panel3.Location = new System.Drawing.Point(145, 83);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(135, 77);
            this.panel3.TabIndex = 6;
            // 
            // radioParallel
            // 
            this.radioParallel.AutoSize = true;
            this.radioParallel.Checked = true;
            this.radioParallel.Location = new System.Drawing.Point(12, 14);
            this.radioParallel.Name = "radioParallel";
            this.radioParallel.Size = new System.Drawing.Size(58, 17);
            this.radioParallel.TabIndex = 0;
            this.radioParallel.TabStop = true;
            this.radioParallel.Text = "parallel";
            this.radioParallel.UseVisualStyleBackColor = true;
            // 
            // radioSerialExecution
            // 
            this.radioSerialExecution.AutoSize = true;
            this.radioSerialExecution.Location = new System.Drawing.Point(12, 38);
            this.radioSerialExecution.Name = "radioSerialExecution";
            this.radioSerialExecution.Size = new System.Drawing.Size(98, 17);
            this.radioSerialExecution.TabIndex = 1;
            this.radioSerialExecution.Text = "serial execution";
            this.radioSerialExecution.UseVisualStyleBackColor = true;
            // 
            // StatBootstrapForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 221);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "StatBootstrapForm";
            this.Text = "statistical analysis";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBoardNum;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtRuns;
        private System.Windows.Forms.ProgressBar progComplete;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox chkGeneticSettings;
        private System.Windows.Forms.RadioButton radioMultiRun;
        private System.Windows.Forms.RadioButton radioSingleRun;
        private System.Windows.Forms.TextBox txtGeneticSettings;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton radioSerialExecution;
        private System.Windows.Forms.RadioButton radioParallel;
    }
}