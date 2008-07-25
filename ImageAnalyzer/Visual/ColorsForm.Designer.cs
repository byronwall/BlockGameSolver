namespace ImageAnalyzer
{
    partial class ColorsForm
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
            this.lstColors = new System.Windows.Forms.ListBox();
            this.btnAssignColor = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtColorName = new System.Windows.Forms.TextBox();
            this.txtColorSource = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lstColors
            // 
            this.lstColors.FormattingEnabled = true;
            this.lstColors.Location = new System.Drawing.Point(12, 12);
            this.lstColors.Name = "lstColors";
            this.lstColors.Size = new System.Drawing.Size(120, 238);
            this.lstColors.TabIndex = 0;
            this.lstColors.SelectedIndexChanged += new System.EventHandler(this.lstColors_SelectedIndexChanged);
            // 
            // btnAssignColor
            // 
            this.btnAssignColor.Location = new System.Drawing.Point(138, 198);
            this.btnAssignColor.Name = "btnAssignColor";
            this.btnAssignColor.Size = new System.Drawing.Size(75, 23);
            this.btnAssignColor.TabIndex = 2;
            this.btnAssignColor.Text = "&assign";
            this.btnAssignColor.UseVisualStyleBackColor = true;
            this.btnAssignColor.Click += new System.EventHandler(this.btnAssignColor_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(138, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "name";
            // 
            // txtColorName
            // 
            this.txtColorName.Location = new System.Drawing.Point(178, 13);
            this.txtColorName.Name = "txtColorName";
            this.txtColorName.Size = new System.Drawing.Size(100, 20);
            this.txtColorName.TabIndex = 4;
            // 
            // txtColorSource
            // 
            this.txtColorSource.Location = new System.Drawing.Point(178, 48);
            this.txtColorSource.Name = "txtColorSource";
            this.txtColorSource.ReadOnly = true;
            this.txtColorSource.Size = new System.Drawing.Size(100, 20);
            this.txtColorSource.TabIndex = 4;
            // 
            // ColorsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 266);
            this.Controls.Add(this.txtColorSource);
            this.Controls.Add(this.txtColorName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAssignColor);
            this.Controls.Add(this.lstColors);
            this.Name = "ColorsForm";
            this.Text = "ColorsForm";
            this.Load += new System.EventHandler(this.ColorsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstColors;
        private System.Windows.Forms.Button btnAssignColor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtColorName;
        private System.Windows.Forms.TextBox txtColorSource;

    }
}