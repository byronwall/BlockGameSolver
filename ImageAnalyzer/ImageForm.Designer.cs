namespace ImageAnalyzer
{
    partial class ImageForm
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
            this.txtFilename = new System.Windows.Forms.TextBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.grpAnchor = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.imgScreenShot = new System.Windows.Forms.PictureBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCornerX = new System.Windows.Forms.TextBox();
            this.txtCornerY = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grpPieces = new System.Windows.Forms.GroupBox();
            this.btnShowPiece = new System.Windows.Forms.Button();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.imgPieceThumb = new System.Windows.Forms.PictureBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.txtPieceWidth = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPieceHeight = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPieceOffsetX = new System.Windows.Forms.TextBox();
            this.txtPieceOffsetY = new System.Windows.Forms.TextBox();
            this.txtPieceCornerX = new System.Windows.Forms.TextBox();
            this.txtPieceCornerY = new System.Windows.Forms.TextBox();
            this.grpAnchor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgScreenShot)).BeginInit();
            this.grpPieces.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgPieceThumb)).BeginInit();
            this.SuspendLayout();
            // 
            // txtFilename
            // 
            this.txtFilename.AllowDrop = true;
            this.txtFilename.Location = new System.Drawing.Point(12, 12);
            this.txtFilename.Name = "txtFilename";
            this.txtFilename.Size = new System.Drawing.Size(325, 20);
            this.txtFilename.TabIndex = 0;
            this.txtFilename.Text = "C:\\Documents and Settings\\Byron Wall\\Desktop\\klciker klacker copy.bmp";
            this.txtFilename.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtFilename_DragDrop);
            this.txtFilename.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtFilename_DragEnter);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(343, 12);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 1;
            this.btnLoad.Text = "load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // grpAnchor
            // 
            this.grpAnchor.Controls.Add(this.btnSave);
            this.grpAnchor.Controls.Add(this.imgScreenShot);
            this.grpAnchor.Controls.Add(this.btnUpdate);
            this.grpAnchor.Controls.Add(this.txtWidth);
            this.grpAnchor.Controls.Add(this.label3);
            this.grpAnchor.Controls.Add(this.txtHeight);
            this.grpAnchor.Controls.Add(this.label2);
            this.grpAnchor.Controls.Add(this.txtCornerX);
            this.grpAnchor.Controls.Add(this.txtCornerY);
            this.grpAnchor.Controls.Add(this.label1);
            this.grpAnchor.Location = new System.Drawing.Point(12, 36);
            this.grpAnchor.Name = "grpAnchor";
            this.grpAnchor.Size = new System.Drawing.Size(200, 149);
            this.grpAnchor.TabIndex = 2;
            this.grpAnchor.TabStop = false;
            this.grpAnchor.Text = "anchor settings";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(97, 96);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(40, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // imgScreenShot
            // 
            this.imgScreenShot.Location = new System.Drawing.Point(6, 88);
            this.imgScreenShot.Name = "imgScreenShot";
            this.imgScreenShot.Size = new System.Drawing.Size(56, 53);
            this.imgScreenShot.TabIndex = 3;
            this.imgScreenShot.TabStop = false;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Enabled = false;
            this.btnUpdate.Location = new System.Drawing.Point(143, 96);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(51, 23);
            this.btnUpdate.TabIndex = 5;
            this.btnUpdate.Text = "update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // txtWidth
            // 
            this.txtWidth.Location = new System.Drawing.Point(143, 69);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(51, 20);
            this.txtWidth.TabIndex = 3;
            this.txtWidth.Text = "20";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "width";
            // 
            // txtHeight
            // 
            this.txtHeight.Location = new System.Drawing.Point(143, 43);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(51, 20);
            this.txtHeight.TabIndex = 2;
            this.txtHeight.Text = "20";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "height";
            // 
            // txtCornerX
            // 
            this.txtCornerX.Location = new System.Drawing.Point(86, 17);
            this.txtCornerX.Name = "txtCornerX";
            this.txtCornerX.Size = new System.Drawing.Size(51, 20);
            this.txtCornerX.TabIndex = 0;
            this.txtCornerX.Text = "255";
            // 
            // txtCornerY
            // 
            this.txtCornerY.Location = new System.Drawing.Point(143, 17);
            this.txtCornerY.Name = "txtCornerY";
            this.txtCornerY.Size = new System.Drawing.Size(51, 20);
            this.txtCornerY.TabIndex = 1;
            this.txtCornerY.Text = "264";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "top corner";
            // 
            // grpPieces
            // 
            this.grpPieces.Controls.Add(this.btnShowPiece);
            this.grpPieces.Controls.Add(this.radioButton2);
            this.grpPieces.Controls.Add(this.imgPieceThumb);
            this.grpPieces.Controls.Add(this.radioButton1);
            this.grpPieces.Controls.Add(this.txtPieceWidth);
            this.grpPieces.Controls.Add(this.label7);
            this.grpPieces.Controls.Add(this.txtPieceHeight);
            this.grpPieces.Controls.Add(this.label6);
            this.grpPieces.Controls.Add(this.txtPieceOffsetX);
            this.grpPieces.Controls.Add(this.txtPieceOffsetY);
            this.grpPieces.Controls.Add(this.txtPieceCornerX);
            this.grpPieces.Controls.Add(this.txtPieceCornerY);
            this.grpPieces.Location = new System.Drawing.Point(12, 191);
            this.grpPieces.Name = "grpPieces";
            this.grpPieces.Size = new System.Drawing.Size(200, 182);
            this.grpPieces.TabIndex = 3;
            this.grpPieces.TabStop = false;
            this.grpPieces.Text = "piece settings";
            // 
            // btnShowPiece
            // 
            this.btnShowPiece.Location = new System.Drawing.Point(118, 126);
            this.btnShowPiece.Name = "btnShowPiece";
            this.btnShowPiece.Size = new System.Drawing.Size(75, 23);
            this.btnShowPiece.TabIndex = 4;
            this.btnShowPiece.Text = "show piece";
            this.btnShowPiece.UseVisualStyleBackColor = true;
            this.btnShowPiece.Click += new System.EventHandler(this.btnShowPiece_Click);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(6, 44);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(51, 17);
            this.radioButton2.TabIndex = 2;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "offset";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // imgPieceThumb
            // 
            this.imgPieceThumb.Location = new System.Drawing.Point(9, 117);
            this.imgPieceThumb.Name = "imgPieceThumb";
            this.imgPieceThumb.Size = new System.Drawing.Size(55, 57);
            this.imgPieceThumb.TabIndex = 3;
            this.imgPieceThumb.TabStop = false;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(6, 21);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(55, 17);
            this.radioButton1.TabIndex = 2;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "corner";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // txtPieceWidth
            // 
            this.txtPieceWidth.Location = new System.Drawing.Point(138, 98);
            this.txtPieceWidth.Name = "txtPieceWidth";
            this.txtPieceWidth.Size = new System.Drawing.Size(56, 20);
            this.txtPieceWidth.TabIndex = 1;
            this.txtPieceWidth.Text = "30";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 101);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "width";
            // 
            // txtPieceHeight
            // 
            this.txtPieceHeight.Location = new System.Drawing.Point(138, 72);
            this.txtPieceHeight.Name = "txtPieceHeight";
            this.txtPieceHeight.Size = new System.Drawing.Size(56, 20);
            this.txtPieceHeight.TabIndex = 1;
            this.txtPieceHeight.Text = "30";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 75);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "height";
            // 
            // txtPieceOffsetX
            // 
            this.txtPieceOffsetX.Location = new System.Drawing.Point(76, 46);
            this.txtPieceOffsetX.Name = "txtPieceOffsetX";
            this.txtPieceOffsetX.Size = new System.Drawing.Size(56, 20);
            this.txtPieceOffsetX.TabIndex = 1;
            // 
            // txtPieceOffsetY
            // 
            this.txtPieceOffsetY.Location = new System.Drawing.Point(138, 46);
            this.txtPieceOffsetY.Name = "txtPieceOffsetY";
            this.txtPieceOffsetY.Size = new System.Drawing.Size(56, 20);
            this.txtPieceOffsetY.TabIndex = 1;
            // 
            // txtPieceCornerX
            // 
            this.txtPieceCornerX.Location = new System.Drawing.Point(76, 20);
            this.txtPieceCornerX.Name = "txtPieceCornerX";
            this.txtPieceCornerX.Size = new System.Drawing.Size(56, 20);
            this.txtPieceCornerX.TabIndex = 1;
            this.txtPieceCornerX.Text = "385";
            // 
            // txtPieceCornerY
            // 
            this.txtPieceCornerY.Location = new System.Drawing.Point(138, 20);
            this.txtPieceCornerY.Name = "txtPieceCornerY";
            this.txtPieceCornerY.Size = new System.Drawing.Size(56, 20);
            this.txtPieceCornerY.TabIndex = 1;
            this.txtPieceCornerY.Text = "261";
            // 
            // ImageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 382);
            this.Controls.Add(this.grpPieces);
            this.Controls.Add(this.grpAnchor);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.txtFilename);
            this.Name = "ImageForm";
            this.Text = "image analyzer";
            this.grpAnchor.ResumeLayout(false);
            this.grpAnchor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgScreenShot)).EndInit();
            this.grpPieces.ResumeLayout(false);
            this.grpPieces.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgPieceThumb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFilename;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.GroupBox grpAnchor;
        private System.Windows.Forms.TextBox txtWidth;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtHeight;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCornerY;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCornerX;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.PictureBox imgScreenShot;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox grpPieces;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.TextBox txtPieceWidth;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtPieceHeight;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPieceOffsetX;
        private System.Windows.Forms.TextBox txtPieceOffsetY;
        private System.Windows.Forms.TextBox txtPieceCornerX;
        private System.Windows.Forms.TextBox txtPieceCornerY;
        private System.Windows.Forms.Button btnShowPiece;
        private System.Windows.Forms.PictureBox imgPieceThumb;
    }
}

