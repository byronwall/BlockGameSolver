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
            this.txtBoard = new System.Windows.Forms.TextBox();
            this.btnNewBoard = new System.Windows.Forms.Button();
            this.grpGrouping = new System.Windows.Forms.GroupBox();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnGetGroup = new System.Windows.Forms.Button();
            this.lblCount = new System.Windows.Forms.Label();
            this.txtRemoveTotal = new System.Windows.Forms.TextBox();
            this.txtCount = new System.Windows.Forms.TextBox();
            this.lblCol = new System.Windows.Forms.Label();
            this.txtCol = new System.Windows.Forms.TextBox();
            this.lblRow = new System.Windows.Forms.Label();
            this.txtRow = new System.Windows.Forms.TextBox();
            this.txtDuring = new System.Windows.Forms.TextBox();
            this.txtBefore = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnGapTest = new System.Windows.Forms.Button();
            this.grpSimulation = new System.Windows.Forms.GroupBox();
            this.chkDelete = new System.Windows.Forms.CheckBox();
            this.btnViewResults = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.grpGrouping.SuspendLayout();
            this.grpSimulation.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtBoard
            // 
            this.txtBoard.Location = new System.Drawing.Point(10, 39);
            this.txtBoard.Multiline = true;
            this.txtBoard.Name = "txtBoard";
            this.txtBoard.Size = new System.Drawing.Size(200, 216);
            this.txtBoard.TabIndex = 0;
            // 
            // btnNewBoard
            // 
            this.btnNewBoard.Location = new System.Drawing.Point(11, 262);
            this.btnNewBoard.Name = "btnNewBoard";
            this.btnNewBoard.Size = new System.Drawing.Size(75, 23);
            this.btnNewBoard.TabIndex = 1;
            this.btnNewBoard.Text = "new board";
            this.btnNewBoard.UseVisualStyleBackColor = true;
            this.btnNewBoard.Click += new System.EventHandler(this.btnNewBoard_Click);
            // 
            // grpGrouping
            // 
            this.grpGrouping.Controls.Add(this.btnRemove);
            this.grpGrouping.Controls.Add(this.btnGetGroup);
            this.grpGrouping.Controls.Add(this.lblCount);
            this.grpGrouping.Controls.Add(this.txtRemoveTotal);
            this.grpGrouping.Controls.Add(this.txtCount);
            this.grpGrouping.Controls.Add(this.lblCol);
            this.grpGrouping.Controls.Add(this.txtCol);
            this.grpGrouping.Controls.Add(this.lblRow);
            this.grpGrouping.Controls.Add(this.txtRow);
            this.grpGrouping.Location = new System.Drawing.Point(10, 291);
            this.grpGrouping.Name = "grpGrouping";
            this.grpGrouping.Size = new System.Drawing.Size(200, 115);
            this.grpGrouping.TabIndex = 3;
            this.grpGrouping.TabStop = false;
            this.grpGrouping.Text = "grouping";
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(103, 46);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 7;
            this.btnRemove.Text = "remove group";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnGetGroup
            // 
            this.btnGetGroup.Location = new System.Drawing.Point(103, 22);
            this.btnGetGroup.Name = "btnGetGroup";
            this.btnGetGroup.Size = new System.Drawing.Size(75, 23);
            this.btnGetGroup.TabIndex = 7;
            this.btnGetGroup.Text = "group count";
            this.btnGetGroup.UseVisualStyleBackColor = true;
            this.btnGetGroup.Click += new System.EventHandler(this.btnGetGroup_Click);
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(7, 78);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(34, 13);
            this.lblCount.TabIndex = 6;
            this.lblCount.Text = "count";
            // 
            // txtRemoveTotal
            // 
            this.txtRemoveTotal.Location = new System.Drawing.Point(103, 75);
            this.txtRemoveTotal.Name = "txtRemoveTotal";
            this.txtRemoveTotal.Size = new System.Drawing.Size(48, 20);
            this.txtRemoveTotal.TabIndex = 6;
            // 
            // txtCount
            // 
            this.txtCount.Location = new System.Drawing.Point(48, 75);
            this.txtCount.Name = "txtCount";
            this.txtCount.Size = new System.Drawing.Size(48, 20);
            this.txtCount.TabIndex = 6;
            // 
            // lblCol
            // 
            this.lblCol.AutoSize = true;
            this.lblCol.Location = new System.Drawing.Point(7, 51);
            this.lblCol.Name = "lblCol";
            this.lblCol.Size = new System.Drawing.Size(21, 13);
            this.lblCol.TabIndex = 6;
            this.lblCol.Text = "col";
            // 
            // txtCol
            // 
            this.txtCol.Location = new System.Drawing.Point(48, 48);
            this.txtCol.Name = "txtCol";
            this.txtCol.Size = new System.Drawing.Size(48, 20);
            this.txtCol.TabIndex = 5;
            this.txtCol.Text = "0";
            // 
            // lblRow
            // 
            this.lblRow.AutoSize = true;
            this.lblRow.Location = new System.Drawing.Point(7, 25);
            this.lblRow.Name = "lblRow";
            this.lblRow.Size = new System.Drawing.Size(24, 13);
            this.lblRow.TabIndex = 4;
            this.lblRow.Text = "row";
            // 
            // txtRow
            // 
            this.txtRow.Location = new System.Drawing.Point(48, 22);
            this.txtRow.Name = "txtRow";
            this.txtRow.Size = new System.Drawing.Size(48, 20);
            this.txtRow.TabIndex = 3;
            this.txtRow.Text = "0";
            // 
            // txtDuring
            // 
            this.txtDuring.Location = new System.Drawing.Point(216, 39);
            this.txtDuring.Multiline = true;
            this.txtDuring.Name = "txtDuring";
            this.txtDuring.Size = new System.Drawing.Size(200, 216);
            this.txtDuring.TabIndex = 0;
            // 
            // txtBefore
            // 
            this.txtBefore.Location = new System.Drawing.Point(422, 39);
            this.txtBefore.Multiline = true;
            this.txtBefore.Name = "txtBefore";
            this.txtBefore.Size = new System.Drawing.Size(200, 216);
            this.txtBefore.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "after";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(213, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "during";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(419, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "before";
            // 
            // btnGapTest
            // 
            this.btnGapTest.Location = new System.Drawing.Point(92, 262);
            this.btnGapTest.Name = "btnGapTest";
            this.btnGapTest.Size = new System.Drawing.Size(75, 23);
            this.btnGapTest.TabIndex = 1;
            this.btnGapTest.Text = "colGap";
            this.btnGapTest.UseVisualStyleBackColor = true;
            this.btnGapTest.Click += new System.EventHandler(this.btnGapTest_Click);
            // 
            // grpSimulation
            // 
            this.grpSimulation.Controls.Add(this.chkDelete);
            this.grpSimulation.Controls.Add(this.btnViewResults);
            this.grpSimulation.Controls.Add(this.btnRun);
            this.grpSimulation.Location = new System.Drawing.Point(216, 291);
            this.grpSimulation.Name = "grpSimulation";
            this.grpSimulation.Size = new System.Drawing.Size(200, 112);
            this.grpSimulation.TabIndex = 5;
            this.grpSimulation.TabStop = false;
            this.grpSimulation.Text = "simulation";
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
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 415);
            this.Controls.Add(this.grpSimulation);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grpGrouping);
            this.Controls.Add(this.btnGapTest);
            this.Controls.Add(this.btnNewBoard);
            this.Controls.Add(this.txtBefore);
            this.Controls.Add(this.txtDuring);
            this.Controls.Add(this.txtBoard);
            this.Name = "GameForm";
            this.Text = "GameForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GameForm_FormClosing);
            this.grpGrouping.ResumeLayout(false);
            this.grpGrouping.PerformLayout();
            this.grpSimulation.ResumeLayout(false);
            this.grpSimulation.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBoard;
        private System.Windows.Forms.Button btnNewBoard;
        private System.Windows.Forms.GroupBox grpGrouping;
        private System.Windows.Forms.Button btnGetGroup;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.TextBox txtCount;
        private System.Windows.Forms.Label lblCol;
        private System.Windows.Forms.TextBox txtCol;
        private System.Windows.Forms.Label lblRow;
        private System.Windows.Forms.TextBox txtRow;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.TextBox txtDuring;
        private System.Windows.Forms.TextBox txtBefore;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtRemoveTotal;
        private System.Windows.Forms.Button btnGapTest;
        private System.Windows.Forms.GroupBox grpSimulation;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Button btnViewResults;
        private System.Windows.Forms.CheckBox chkDelete;
    }
}