namespace BlockGameSolver.Visual
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
            this.progCompleted = new System.Windows.Forms.ProgressBar();
            this.grpSettings = new System.Windows.Forms.GroupBox();
            this.numGenerations = new System.Windows.Forms.NumericUpDown();
            this.numCrossMutate = new System.Windows.Forms.NumericUpDown();
            this.numFilterRate = new System.Windows.Forms.NumericUpDown();
            this.numPopSize = new System.Windows.Forms.NumericUpDown();
            this.lblGenerations = new System.Windows.Forms.Label();
            this.lblCrossMutate = new System.Windows.Forms.Label();
            this.lblFilterRate = new System.Windows.Forms.Label();
            this.lblPopSize = new System.Windows.Forms.Label();
            this.chkDelete = new System.Windows.Forms.CheckBox();
            this.btnScores = new System.Windows.Forms.Button();
            this.btnViewResults = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.tableBoard = new System.Windows.Forms.TableLayoutPanel();
            this.btnCreate = new System.Windows.Forms.Button();
            this.txtScore = new System.Windows.Forms.TextBox();
            this.lblInitSize = new System.Windows.Forms.Label();
            this.numInitialSize = new System.Windows.Forms.NumericUpDown();
            this.grpPlayingSurface = new System.Windows.Forms.GroupBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.grpSimulation.SuspendLayout();
            this.grpSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numGenerations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCrossMutate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFilterRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPopSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numInitialSize)).BeginInit();
            this.grpPlayingSurface.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpSimulation
            // 
            this.grpSimulation.Controls.Add(this.progCompleted);
            this.grpSimulation.Controls.Add(this.grpSettings);
            this.grpSimulation.Controls.Add(this.chkDelete);
            this.grpSimulation.Controls.Add(this.btnScores);
            this.grpSimulation.Controls.Add(this.btnViewResults);
            this.grpSimulation.Controls.Add(this.btnRun);
            this.grpSimulation.Location = new System.Drawing.Point(12, 12);
            this.grpSimulation.Name = "grpSimulation";
            this.grpSimulation.Size = new System.Drawing.Size(294, 274);
            this.grpSimulation.TabIndex = 5;
            this.grpSimulation.TabStop = false;
            this.grpSimulation.Text = "simulation";
            // 
            // progCompleted
            // 
            this.progCompleted.Location = new System.Drawing.Point(5, 207);
            this.progCompleted.Name = "progCompleted";
            this.progCompleted.Size = new System.Drawing.Size(281, 61);
            this.progCompleted.TabIndex = 3;
            // 
            // grpSettings
            // 
            this.grpSettings.Controls.Add(this.numGenerations);
            this.grpSettings.Controls.Add(this.numCrossMutate);
            this.grpSettings.Controls.Add(this.numFilterRate);
            this.grpSettings.Controls.Add(this.numInitialSize);
            this.grpSettings.Controls.Add(this.numPopSize);
            this.grpSettings.Controls.Add(this.lblGenerations);
            this.grpSettings.Controls.Add(this.lblCrossMutate);
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
            this.numGenerations.Location = new System.Drawing.Point(89, 140);
            this.numGenerations.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numGenerations.Name = "numGenerations";
            this.numGenerations.Size = new System.Drawing.Size(104, 20);
            this.numGenerations.TabIndex = 1;
            this.numGenerations.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // numCrossMutate
            // 
            this.numCrossMutate.DecimalPlaces = 2;
            this.numCrossMutate.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numCrossMutate.Location = new System.Drawing.Point(89, 114);
            this.numCrossMutate.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numCrossMutate.Name = "numCrossMutate";
            this.numCrossMutate.Size = new System.Drawing.Size(104, 20);
            this.numCrossMutate.TabIndex = 1;
            this.numCrossMutate.Value = new decimal(new int[] {
            15,
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
            this.numFilterRate.Location = new System.Drawing.Point(90, 87);
            this.numFilterRate.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numFilterRate.Name = "numFilterRate";
            this.numFilterRate.Size = new System.Drawing.Size(104, 20);
            this.numFilterRate.TabIndex = 1;
            this.numFilterRate.Value = new decimal(new int[] {
            4,
            0,
            0,
            65536});
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
            150,
            0,
            0,
            0});
            // 
            // lblGenerations
            // 
            this.lblGenerations.AutoSize = true;
            this.lblGenerations.Location = new System.Drawing.Point(6, 142);
            this.lblGenerations.Name = "lblGenerations";
            this.lblGenerations.Size = new System.Drawing.Size(62, 13);
            this.lblGenerations.TabIndex = 0;
            this.lblGenerations.Text = "generations";
            // 
            // lblCrossMutate
            // 
            this.lblCrossMutate.AutoSize = true;
            this.lblCrossMutate.Location = new System.Drawing.Point(6, 116);
            this.lblCrossMutate.Name = "lblCrossMutate";
            this.lblCrossMutate.Size = new System.Drawing.Size(69, 13);
            this.lblCrossMutate.TabIndex = 0;
            this.lblCrossMutate.Text = "cross/mutate";
            // 
            // lblFilterRate
            // 
            this.lblFilterRate.AutoSize = true;
            this.lblFilterRate.Location = new System.Drawing.Point(7, 89);
            this.lblFilterRate.Name = "lblFilterRate";
            this.lblFilterRate.Size = new System.Drawing.Size(47, 13);
            this.lblFilterRate.TabIndex = 0;
            this.lblFilterRate.Text = "filter rate";
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
            // btnScores
            // 
            this.btnScores.Location = new System.Drawing.Point(6, 78);
            this.btnScores.Name = "btnScores";
            this.btnScores.Size = new System.Drawing.Size(75, 23);
            this.btnScores.TabIndex = 0;
            this.btnScores.Text = "view scores";
            this.btnScores.UseVisualStyleBackColor = true;
            this.btnScores.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnViewResults
            // 
            this.btnViewResults.Location = new System.Drawing.Point(6, 49);
            this.btnViewResults.Name = "btnViewResults";
            this.btnViewResults.Size = new System.Drawing.Size(75, 23);
            this.btnViewResults.TabIndex = 0;
            this.btnViewResults.Text = "view results";
            this.btnViewResults.UseVisualStyleBackColor = true;
            this.btnViewResults.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(7, 20);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 23);
            this.btnRun.TabIndex = 0;
            this.btnRun.Text = "run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // tableBoard
            // 
            this.tableBoard.AutoSize = true;
            this.tableBoard.ColumnCount = 10;
            this.tableBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableBoard.Location = new System.Drawing.Point(6, 45);
            this.tableBoard.Name = "tableBoard";
            this.tableBoard.RowCount = 10;
            this.tableBoard.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableBoard.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableBoard.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableBoard.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableBoard.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableBoard.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableBoard.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableBoard.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableBoard.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableBoard.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableBoard.Size = new System.Drawing.Size(50, 50);
            this.tableBoard.TabIndex = 6;
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(112, 16);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 23);
            this.btnCreate.TabIndex = 0;
            this.btnCreate.Text = "restart";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // txtScore
            // 
            this.txtScore.Location = new System.Drawing.Point(6, 19);
            this.txtScore.Name = "txtScore";
            this.txtScore.Size = new System.Drawing.Size(100, 20);
            this.txtScore.TabIndex = 8;
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
            this.numInitialSize.TabIndex = 1;
            this.numInitialSize.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // grpPlayingSurface
            // 
            this.grpPlayingSurface.Controls.Add(this.tableBoard);
            this.grpPlayingSurface.Controls.Add(this.txtScore);
            this.grpPlayingSurface.Controls.Add(this.btnRefresh);
            this.grpPlayingSurface.Controls.Add(this.btnCreate);
            this.grpPlayingSurface.Location = new System.Drawing.Point(312, 13);
            this.grpPlayingSurface.Name = "grpPlayingSurface";
            this.grpPlayingSurface.Size = new System.Drawing.Size(337, 273);
            this.grpPlayingSurface.TabIndex = 9;
            this.grpPlayingSurface.TabStop = false;
            this.grpPlayingSurface.Text = "playing surface";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(193, 16);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 0;
            this.btnRefresh.Text = "redraw";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 298);
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
            ((System.ComponentModel.ISupportInitialize)(this.numCrossMutate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFilterRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPopSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numInitialSize)).EndInit();
            this.grpPlayingSurface.ResumeLayout(false);
            this.grpPlayingSurface.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpSimulation;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Button btnViewResults;
        private System.Windows.Forms.CheckBox chkDelete;
        private System.Windows.Forms.GroupBox grpSettings;
        private System.Windows.Forms.Label lblPopSize;
        private System.Windows.Forms.NumericUpDown numCrossMutate;
        private System.Windows.Forms.NumericUpDown numFilterRate;
        private System.Windows.Forms.NumericUpDown numPopSize;
        private System.Windows.Forms.Label lblCrossMutate;
        private System.Windows.Forms.Label lblFilterRate;
        private System.Windows.Forms.NumericUpDown numGenerations;
        private System.Windows.Forms.Label lblGenerations;
        private System.Windows.Forms.ProgressBar progCompleted;
        private System.Windows.Forms.Button btnScores;
        private System.Windows.Forms.TableLayoutPanel tableBoard;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.TextBox txtScore;
        private System.Windows.Forms.NumericUpDown numInitialSize;
        private System.Windows.Forms.Label lblInitSize;
        private System.Windows.Forms.GroupBox grpPlayingSurface;
        private System.Windows.Forms.Button btnRefresh;
    }
}