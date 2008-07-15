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
            this.btnViewResults = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.progCompleted = new System.Windows.Forms.ProgressBar();
            this.grpSimulation.SuspendLayout();
            this.grpSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numGenerations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCrossMutate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFilterRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPopSize)).BeginInit();
            this.SuspendLayout();
            // 
            // grpSimulation
            // 
            this.grpSimulation.Controls.Add(this.progCompleted);
            this.grpSimulation.Controls.Add(this.grpSettings);
            this.grpSimulation.Controls.Add(this.chkDelete);
            this.grpSimulation.Controls.Add(this.btnViewResults);
            this.grpSimulation.Controls.Add(this.btnRun);
            this.grpSimulation.Location = new System.Drawing.Point(12, 12);
            this.grpSimulation.Name = "grpSimulation";
            this.grpSimulation.Size = new System.Drawing.Size(294, 236);
            this.grpSimulation.TabIndex = 5;
            this.grpSimulation.TabStop = false;
            this.grpSimulation.Text = "simulation";
            // 
            // grpSettings
            // 
            this.grpSettings.Controls.Add(this.numGenerations);
            this.grpSettings.Controls.Add(this.numCrossMutate);
            this.grpSettings.Controls.Add(this.numFilterRate);
            this.grpSettings.Controls.Add(this.numPopSize);
            this.grpSettings.Controls.Add(this.lblGenerations);
            this.grpSettings.Controls.Add(this.lblCrossMutate);
            this.grpSettings.Controls.Add(this.lblFilterRate);
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
            this.numGenerations.Location = new System.Drawing.Point(89, 104);
            this.numGenerations.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numGenerations.Name = "numGenerations";
            this.numGenerations.Size = new System.Drawing.Size(104, 20);
            this.numGenerations.TabIndex = 1;
            this.numGenerations.Value = new decimal(new int[] {
            5,
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
            this.numCrossMutate.Location = new System.Drawing.Point(89, 78);
            this.numCrossMutate.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numCrossMutate.Name = "numCrossMutate";
            this.numCrossMutate.Size = new System.Drawing.Size(104, 20);
            this.numCrossMutate.TabIndex = 1;
            this.numCrossMutate.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            // 
            // numFilterRate
            // 
            this.numFilterRate.DecimalPlaces = 2;
            this.numFilterRate.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numFilterRate.Location = new System.Drawing.Point(90, 51);
            this.numFilterRate.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numFilterRate.Name = "numFilterRate";
            this.numFilterRate.Size = new System.Drawing.Size(104, 20);
            this.numFilterRate.TabIndex = 1;
            this.numFilterRate.Value = new decimal(new int[] {
            1,
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
            100,
            0,
            0,
            0});
            // 
            // lblGenerations
            // 
            this.lblGenerations.AutoSize = true;
            this.lblGenerations.Location = new System.Drawing.Point(6, 106);
            this.lblGenerations.Name = "lblGenerations";
            this.lblGenerations.Size = new System.Drawing.Size(62, 13);
            this.lblGenerations.TabIndex = 0;
            this.lblGenerations.Text = "generations";
            // 
            // lblCrossMutate
            // 
            this.lblCrossMutate.AutoSize = true;
            this.lblCrossMutate.Location = new System.Drawing.Point(6, 80);
            this.lblCrossMutate.Name = "lblCrossMutate";
            this.lblCrossMutate.Size = new System.Drawing.Size(69, 13);
            this.lblCrossMutate.TabIndex = 0;
            this.lblCrossMutate.Text = "cross/mutate";
            // 
            // lblFilterRate
            // 
            this.lblFilterRate.AutoSize = true;
            this.lblFilterRate.Location = new System.Drawing.Point(7, 53);
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
            this.chkDelete.Location = new System.Drawing.Point(7, 73);
            this.chkDelete.Name = "chkDelete";
            this.chkDelete.Size = new System.Drawing.Size(76, 17);
            this.chkDelete.TabIndex = 1;
            this.chkDelete.Text = "delete files";
            this.chkDelete.UseVisualStyleBackColor = true;
            // 
            // btnViewResults
            // 
            this.btnViewResults.Location = new System.Drawing.Point(7, 46);
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
            // progCompleted
            // 
            this.progCompleted.Location = new System.Drawing.Point(7, 207);
            this.progCompleted.Name = "progCompleted";
            this.progCompleted.Size = new System.Drawing.Size(281, 23);
            this.progCompleted.TabIndex = 3;
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 415);
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
    }
}