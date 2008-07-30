namespace BlockGameSolver.Simulation.Visual
{
    partial class GameForm
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
            this.grpSimulation = new System.Windows.Forms.GroupBox();
            this.txtBestFitness = new System.Windows.Forms.TextBox();
            this.btnPlayBest = new System.Windows.Forms.Button();
            this.txtBestResult = new System.Windows.Forms.TextBox();
            this.progCompleted = new System.Windows.Forms.ProgressBar();
            this.grpSettings = new System.Windows.Forms.GroupBox();
            this.numGenerations = new System.Windows.Forms.NumericUpDown();
            this.numMutateRatio = new System.Windows.Forms.NumericUpDown();
            this.numCrossRate = new System.Windows.Forms.NumericUpDown();
            this.numFilterRate = new System.Windows.Forms.NumericUpDown();
            this.numInitialSize = new System.Windows.Forms.NumericUpDown();
            this.numPopSize = new System.Windows.Forms.NumericUpDown();
            this.lblGenerations = new System.Windows.Forms.Label();
            this.lblCross = new System.Windows.Forms.Label();
            this.lblMutate = new System.Windows.Forms.Label();
            this.lblFilterRate = new System.Windows.Forms.Label();
            this.lblInitSize = new System.Windows.Forms.Label();
            this.lblPopSize = new System.Windows.Forms.Label();
            this.chkDelete = new System.Windows.Forms.CheckBox();
            this.btnViewResults = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.txtScore = new System.Windows.Forms.TextBox();
            this.grpPlayingSurface = new System.Windows.Forms.GroupBox();
            this.btnNextMove = new System.Windows.Forms.Button();
            this.lblPlayingMode = new System.Windows.Forms.Label();
            this.tableBoard = new System.Windows.Forms.TableLayoutPanel();
            this.chkBoardLabels = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtBoardSeed = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCreateNewBoard = new System.Windows.Forms.Button();
            this.grpSimulation.SuspendLayout();
            this.grpSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numGenerations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMutateRatio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCrossRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFilterRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numInitialSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPopSize)).BeginInit();
            this.grpPlayingSurface.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpSimulation
            // 
            this.grpSimulation.Controls.Add(this.txtBestFitness);
            this.grpSimulation.Controls.Add(this.btnPlayBest);
            this.grpSimulation.Controls.Add(this.txtBestResult);
            this.grpSimulation.Controls.Add(this.progCompleted);
            this.grpSimulation.Controls.Add(this.grpSettings);
            this.grpSimulation.Controls.Add(this.chkDelete);
            this.grpSimulation.Controls.Add(this.btnViewResults);
            this.grpSimulation.Controls.Add(this.button1);
            this.grpSimulation.Controls.Add(this.btnRun);
            this.grpSimulation.Location = new System.Drawing.Point(12, 12);
            this.grpSimulation.Name = "grpSimulation";
            this.grpSimulation.Size = new System.Drawing.Size(294, 303);
            this.grpSimulation.TabIndex = 5;
            this.grpSimulation.TabStop = false;
            this.grpSimulation.Text = "simulation";
            // 
            // txtBestFitness
            // 
            this.txtBestFitness.Location = new System.Drawing.Point(255, 276);
            this.txtBestFitness.Name = "txtBestFitness";
            this.txtBestFitness.ReadOnly = true;
            this.txtBestFitness.Size = new System.Drawing.Size(31, 20);
            this.txtBestFitness.TabIndex = 6;
            // 
            // btnPlayBest
            // 
            this.btnPlayBest.Enabled = false;
            this.btnPlayBest.Location = new System.Drawing.Point(255, 242);
            this.btnPlayBest.Name = "btnPlayBest";
            this.btnPlayBest.Size = new System.Drawing.Size(31, 22);
            this.btnPlayBest.TabIndex = 5;
            this.btnPlayBest.Text = "-->";
            this.btnPlayBest.UseVisualStyleBackColor = true;
            this.btnPlayBest.Click += new System.EventHandler(this.btnPlayBest_Click);
            // 
            // txtBestResult
            // 
            this.txtBestResult.Location = new System.Drawing.Point(7, 242);
            this.txtBestResult.Multiline = true;
            this.txtBestResult.Name = "txtBestResult";
            this.txtBestResult.ReadOnly = true;
            this.txtBestResult.Size = new System.Drawing.Size(242, 55);
            this.txtBestResult.TabIndex = 4;
            // 
            // progCompleted
            // 
            this.progCompleted.Location = new System.Drawing.Point(5, 207);
            this.progCompleted.Name = "progCompleted";
            this.progCompleted.Size = new System.Drawing.Size(281, 28);
            this.progCompleted.TabIndex = 3;
            // 
            // grpSettings
            // 
            this.grpSettings.Controls.Add(this.numGenerations);
            this.grpSettings.Controls.Add(this.numMutateRatio);
            this.grpSettings.Controls.Add(this.numCrossRate);
            this.grpSettings.Controls.Add(this.numFilterRate);
            this.grpSettings.Controls.Add(this.numInitialSize);
            this.grpSettings.Controls.Add(this.numPopSize);
            this.grpSettings.Controls.Add(this.lblGenerations);
            this.grpSettings.Controls.Add(this.lblCross);
            this.grpSettings.Controls.Add(this.lblMutate);
            this.grpSettings.Controls.Add(this.lblFilterRate);
            this.grpSettings.Controls.Add(this.lblInitSize);
            this.grpSettings.Controls.Add(this.lblPopSize);
            this.grpSettings.Location = new System.Drawing.Point(89, 20);
            this.grpSettings.Name = "grpSettings";
            this.grpSettings.Size = new System.Drawing.Size(200, 181);
            this.grpSettings.TabIndex = 2;
            this.grpSettings.TabStop = false;
            this.grpSettings.Text = "settings";
            // 
            // numGenerations
            // 
            this.numGenerations.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numGenerations.Location = new System.Drawing.Point(90, 155);
            this.numGenerations.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numGenerations.Name = "numGenerations";
            this.numGenerations.Size = new System.Drawing.Size(104, 20);
            this.numGenerations.TabIndex = 6;
            this.numGenerations.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // numMutateRatio
            // 
            this.numMutateRatio.DecimalPlaces = 3;
            this.numMutateRatio.Increment = new decimal(new int[] {
            5,
            0,
            0,
            196608});
            this.numMutateRatio.Location = new System.Drawing.Point(90, 129);
            this.numMutateRatio.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMutateRatio.Name = "numMutateRatio";
            this.numMutateRatio.Size = new System.Drawing.Size(104, 20);
            this.numMutateRatio.TabIndex = 5;
            this.numMutateRatio.Value = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            // 
            // numCrossRate
            // 
            this.numCrossRate.DecimalPlaces = 2;
            this.numCrossRate.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numCrossRate.Location = new System.Drawing.Point(90, 101);
            this.numCrossRate.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numCrossRate.Name = "numCrossRate";
            this.numCrossRate.Size = new System.Drawing.Size(104, 20);
            this.numCrossRate.TabIndex = 4;
            this.numCrossRate.Value = new decimal(new int[] {
            85,
            0,
            0,
            131072});
            // 
            // numFilterRate
            // 
            this.numFilterRate.DecimalPlaces = 2;
            this.numFilterRate.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numFilterRate.Location = new System.Drawing.Point(90, 75);
            this.numFilterRate.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numFilterRate.Name = "numFilterRate";
            this.numFilterRate.Size = new System.Drawing.Size(104, 20);
            this.numFilterRate.TabIndex = 3;
            this.numFilterRate.Value = new decimal(new int[] {
            10,
            0,
            0,
            131072});
            // 
            // numInitialSize
            // 
            this.numInitialSize.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numInitialSize.Location = new System.Drawing.Point(90, 47);
            this.numInitialSize.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numInitialSize.Name = "numInitialSize";
            this.numInitialSize.Size = new System.Drawing.Size(104, 20);
            this.numInitialSize.TabIndex = 2;
            this.numInitialSize.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // numPopSize
            // 
            this.numPopSize.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numPopSize.Location = new System.Drawing.Point(90, 21);
            this.numPopSize.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numPopSize.Name = "numPopSize";
            this.numPopSize.Size = new System.Drawing.Size(104, 20);
            this.numPopSize.TabIndex = 1;
            this.numPopSize.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // lblGenerations
            // 
            this.lblGenerations.AutoSize = true;
            this.lblGenerations.Location = new System.Drawing.Point(7, 157);
            this.lblGenerations.Name = "lblGenerations";
            this.lblGenerations.Size = new System.Drawing.Size(62, 13);
            this.lblGenerations.TabIndex = 0;
            this.lblGenerations.Text = "generations";
            // 
            // lblCross
            // 
            this.lblCross.AutoSize = true;
            this.lblCross.Location = new System.Drawing.Point(7, 103);
            this.lblCross.Name = "lblCross";
            this.lblCross.Size = new System.Drawing.Size(55, 13);
            this.lblCross.TabIndex = 0;
            this.lblCross.Text = "cross ratio";
            // 
            // lblMutate
            // 
            this.lblMutate.AutoSize = true;
            this.lblMutate.Location = new System.Drawing.Point(7, 131);
            this.lblMutate.Name = "lblMutate";
            this.lblMutate.Size = new System.Drawing.Size(62, 13);
            this.lblMutate.TabIndex = 0;
            this.lblMutate.Text = "mutate ratio";
            // 
            // lblFilterRate
            // 
            this.lblFilterRate.AutoSize = true;
            this.lblFilterRate.Location = new System.Drawing.Point(7, 77);
            this.lblFilterRate.Name = "lblFilterRate";
            this.lblFilterRate.Size = new System.Drawing.Size(47, 13);
            this.lblFilterRate.TabIndex = 0;
            this.lblFilterRate.Text = "elite rate";
            // 
            // lblInitSize
            // 
            this.lblInitSize.AutoSize = true;
            this.lblInitSize.Location = new System.Drawing.Point(7, 49);
            this.lblInitSize.Name = "lblInitSize";
            this.lblInitSize.Size = new System.Drawing.Size(51, 13);
            this.lblInitSize.TabIndex = 0;
            this.lblInitSize.Text = "initial size";
            // 
            // lblPopSize
            // 
            this.lblPopSize.AutoSize = true;
            this.lblPopSize.Location = new System.Drawing.Point(7, 23);
            this.lblPopSize.Name = "lblPopSize";
            this.lblPopSize.Size = new System.Drawing.Size(77, 13);
            this.lblPopSize.TabIndex = 0;
            this.lblPopSize.Text = "population size";
            // 
            // chkDelete
            // 
            this.chkDelete.AutoSize = true;
            this.chkDelete.Checked = true;
            this.chkDelete.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDelete.Location = new System.Drawing.Point(5, 150);
            this.chkDelete.Name = "chkDelete";
            this.chkDelete.Size = new System.Drawing.Size(76, 17);
            this.chkDelete.TabIndex = 1;
            this.chkDelete.Text = "delete files";
            this.chkDelete.UseVisualStyleBackColor = true;
            // 
            // btnViewResults
            // 
            this.btnViewResults.Enabled = false;
            this.btnViewResults.Location = new System.Drawing.Point(7, 76);
            this.btnViewResults.Name = "btnViewResults";
            this.btnViewResults.Size = new System.Drawing.Size(75, 23);
            this.btnViewResults.TabIndex = 0;
            this.btnViewResults.Text = "view results";
            this.btnViewResults.UseVisualStyleBackColor = true;
            this.btnViewResults.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(8, 47);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 23);
            this.btnRun.TabIndex = 0;
            this.btnRun.Text = "run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(112, 16);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 23);
            this.btnCreate.TabIndex = 0;
            this.btnCreate.Text = "restart";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnRestart_Click);
            // 
            // txtScore
            // 
            this.txtScore.Location = new System.Drawing.Point(6, 19);
            this.txtScore.Name = "txtScore";
            this.txtScore.ReadOnly = true;
            this.txtScore.Size = new System.Drawing.Size(100, 20);
            this.txtScore.TabIndex = 8;
            // 
            // grpPlayingSurface
            // 
            this.grpPlayingSurface.AutoSize = true;
            this.grpPlayingSurface.Controls.Add(this.btnNextMove);
            this.grpPlayingSurface.Controls.Add(this.lblPlayingMode);
            this.grpPlayingSurface.Controls.Add(this.tableBoard);
            this.grpPlayingSurface.Controls.Add(this.chkBoardLabels);
            this.grpPlayingSurface.Controls.Add(this.txtScore);
            this.grpPlayingSurface.Controls.Add(this.btnCreate);
            this.grpPlayingSurface.Location = new System.Drawing.Point(312, 13);
            this.grpPlayingSurface.Name = "grpPlayingSurface";
            this.grpPlayingSurface.Size = new System.Drawing.Size(327, 302);
            this.grpPlayingSurface.TabIndex = 9;
            this.grpPlayingSurface.TabStop = false;
            this.grpPlayingSurface.Text = "playing surface";
            // 
            // btnNextMove
            // 
            this.btnNextMove.Enabled = false;
            this.btnNextMove.Location = new System.Drawing.Point(112, 46);
            this.btnNextMove.Name = "btnNextMove";
            this.btnNextMove.Size = new System.Drawing.Size(75, 23);
            this.btnNextMove.TabIndex = 16;
            this.btnNextMove.Text = "next";
            this.btnNextMove.UseVisualStyleBackColor = true;
            this.btnNextMove.Click += new System.EventHandler(this.btnNextMove_Click);
            // 
            // lblPlayingMode
            // 
            this.lblPlayingMode.AutoSize = true;
            this.lblPlayingMode.Location = new System.Drawing.Point(7, 46);
            this.lblPlayingMode.Name = "lblPlayingMode";
            this.lblPlayingMode.Size = new System.Drawing.Size(98, 13);
            this.lblPlayingMode.TabIndex = 15;
            this.lblPlayingMode.Text = "board is in free play";
            // 
            // tableBoard
            // 
            this.tableBoard.ColumnCount = 15;
            this.tableBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableBoard.Location = new System.Drawing.Point(6, 75);
            this.tableBoard.Name = "tableBoard";
            this.tableBoard.RowCount = 10;
            this.tableBoard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableBoard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableBoard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableBoard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableBoard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableBoard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableBoard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableBoard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableBoard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableBoard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableBoard.Size = new System.Drawing.Size(308, 208);
            this.tableBoard.TabIndex = 14;
            // 
            // chkBoardLabels
            // 
            this.chkBoardLabels.AutoSize = true;
            this.chkBoardLabels.Location = new System.Drawing.Point(193, 16);
            this.chkBoardLabels.Name = "chkBoardLabels";
            this.chkBoardLabels.Size = new System.Drawing.Size(53, 17);
            this.chkBoardLabels.TabIndex = 13;
            this.chkBoardLabels.Text = "labels";
            this.chkBoardLabels.UseVisualStyleBackColor = true;
            this.chkBoardLabels.CheckedChanged += new System.EventHandler(this.chkBoardLabels_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(8, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "new board";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCreateNewBoard);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtBoardSeed);
            this.groupBox1.Location = new System.Drawing.Point(12, 321);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 73);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "new board";
            // 
            // txtBoardSeed
            // 
            this.txtBoardSeed.Location = new System.Drawing.Point(73, 17);
            this.txtBoardSeed.Name = "txtBoardSeed";
            this.txtBoardSeed.Size = new System.Drawing.Size(100, 20);
            this.txtBoardSeed.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "board seed";
            // 
            // btnCreateNewBoard
            // 
            this.btnCreateNewBoard.Location = new System.Drawing.Point(10, 43);
            this.btnCreateNewBoard.Name = "btnCreateNewBoard";
            this.btnCreateNewBoard.Size = new System.Drawing.Size(75, 23);
            this.btnCreateNewBoard.TabIndex = 2;
            this.btnCreateNewBoard.Text = "create";
            this.btnCreateNewBoard.UseVisualStyleBackColor = true;
            this.btnCreateNewBoard.Click += new System.EventHandler(this.btnCreateNewBoard_Click);
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(646, 400);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpPlayingSurface);
            this.Controls.Add(this.grpSimulation);
            this.Name = "GameForm";
            this.Text = "GameForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GameForm_FormClosing);
            this.grpSimulation.ResumeLayout(false);
            this.grpSimulation.PerformLayout();
            this.grpSettings.ResumeLayout(false);
            this.grpSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numGenerations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMutateRatio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCrossRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFilterRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numInitialSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPopSize)).EndInit();
            this.grpPlayingSurface.ResumeLayout(false);
            this.grpPlayingSurface.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpSimulation;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Button btnViewResults;
        private System.Windows.Forms.CheckBox chkDelete;
        private System.Windows.Forms.GroupBox grpSettings;
        private System.Windows.Forms.Label lblPopSize;
        private System.Windows.Forms.NumericUpDown numMutateRatio;
        private System.Windows.Forms.NumericUpDown numFilterRate;
        private System.Windows.Forms.NumericUpDown numPopSize;
        private System.Windows.Forms.Label lblMutate;
        private System.Windows.Forms.Label lblFilterRate;
        private System.Windows.Forms.NumericUpDown numGenerations;
        private System.Windows.Forms.Label lblGenerations;
        private System.Windows.Forms.ProgressBar progCompleted;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.TextBox txtScore;
        private System.Windows.Forms.NumericUpDown numInitialSize;
        private System.Windows.Forms.Label lblInitSize;
        private System.Windows.Forms.GroupBox grpPlayingSurface;
        private System.Windows.Forms.NumericUpDown numCrossRate;
        private System.Windows.Forms.Label lblCross;
        private System.Windows.Forms.TextBox txtBestResult;
        private System.Windows.Forms.Button btnPlayBest;
        private System.Windows.Forms.CheckBox chkBoardLabels;
        private System.Windows.Forms.TableLayoutPanel tableBoard;
        private System.Windows.Forms.Button btnNextMove;
        private System.Windows.Forms.Label lblPlayingMode;
        private System.Windows.Forms.TextBox txtBestFitness;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCreateNewBoard;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBoardSeed;
    }
}