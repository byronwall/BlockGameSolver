using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using BlockGameSolver.ImageAnalyzer.Core;

namespace BlockGameSolver.ImageAnalyzer.Visual
{
    public partial class ImageForm : Form
    {
        private readonly ImageSettings imageSettings = new ImageSettings();
        private Bitmap loadedImage;

        public ImageForm()
        {
            InitializeComponent();
        }

        private void txtFilename_DragDrop(object sender, DragEventArgs e)
        {
            string filename = string.Empty;
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                filename = ((string[]) e.Data.GetData(DataFormats.FileDrop))[0];
            }
            txtFilename.Text = filename;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            UpdateFileInfo();
        }

        private void txtFilename_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateAnchorInfo();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
        }

        private void btnShowPiece_Click(object sender, EventArgs e)
        {
            UpdatePieceInfo();
        }

        private void btnShowColors_Click(object sender, EventArgs e)
        {
            new ColorsForm(imageSettings).Show();
        }

        private void btnUpdatePiece_Click(object sender, EventArgs e)
        {
            UpdateColorInfo();
        }

        private void UpdateFileInfo()
        {
            if (File.Exists(txtFilename.Text))
            {
                loadedImage = new Bitmap(txtFilename.Text);
                imageSettings.FullImage = loadedImage;
            }

            btnUpdate.Enabled = true;
        }

        private void UpdateAnchorInfo()
        {
            Point corner = new Point(Convert.ToInt32(txtCornerX.Text), Convert.ToInt32(txtCornerY.Text));
            int height = Convert.ToInt32(txtHeight.Text);
            int width = Convert.ToInt32(txtWidth.Text);

            imageSettings.AnchorHeight = height;
            imageSettings.AnchorWidth = width;
            imageSettings.AnchorCorner = corner;

            imgScreenShot.Image = imageSettings.AnchorImage;
        }

        private void UpdatePieceInfo()
        {
            int x = Convert.ToInt32(txtPieceCornerX.Text) - imageSettings.AnchorCorner.X;
            int y = Convert.ToInt32(txtPieceCornerY.Text) - imageSettings.AnchorCorner.Y;

            imageSettings.PieceOffset = new Point(x, y);
            imageSettings.PieceHeight = Convert.ToInt32(txtPieceHeight.Text);
            imageSettings.PieceWidth = Convert.ToInt32(txtPieceWidth.Text);

            imgPieceThumb.Image = imageSettings.PieceThumbnail;
        }

        private void UpdateColorInfo()
        {
            imageSettings.ColorOffset = new Point(Convert.ToInt32(txtColorOffsetX.Text), Convert.ToInt32(txtColorOffsetY.Text));
            imageSettings.DoubleOffset = new Point(Convert.ToInt32(txtDoubleOffsetX.Text), Convert.ToInt32(txtDoubleOffsetY.Text));
            imageSettings.Rows = Convert.ToInt32(txtRows.Text);
            imageSettings.Cols = Convert.ToInt32(txtColumns.Text);
            imageSettings.Colors = Convert.ToInt32(textBox1.Text);
        }

        private void ImageForm_Load(object sender, EventArgs e)
        {
            UpdateFileInfo();
            UpdateAnchorInfo();
            UpdateColorInfo();
            UpdatePieceInfo();

            imageSettings.AddColorsUnique();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            imageSettings.SaveDataToXML();
        }

        private void btnLoadXML_Click(object sender, EventArgs e)
        {
            ImageSettings.LoadDataFromXML("boardData.xml");
        }
    }
}