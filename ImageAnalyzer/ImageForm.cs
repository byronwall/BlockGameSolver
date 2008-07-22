using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ImageAnalyzer
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
                filename = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
            }
            txtFilename.Text = filename;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (File.Exists(txtFilename.Text))
            {
                loadedImage = new Bitmap(txtFilename.Text);
                imageSettings.FullImage = loadedImage;
            }

            btnUpdate.Enabled = true;
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
            Point corner = new Point(Convert.ToInt32(txtCornerX.Text), Convert.ToInt32(txtCornerY.Text));
            int height = Convert.ToInt32(txtHeight.Text);
            int width = Convert.ToInt32(txtWidth.Text);

            imageSettings.ThumbnailHeight = height;
            imageSettings.ThumbnailWidth = width;
            imageSettings.ThumbnailCorner = corner;
            imageSettings.UpdateThumbnail();
            imgScreenShot.Image = imageSettings.ThumbnailImage;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            MessageBox.Show(imageSettings.SaveThumbnailData());
        }

        private void btnShowPiece_Click(object sender, EventArgs e)
        {
            imageSettings.PieceCorner = new Point(Convert.ToInt32(txtPieceCornerX.Text), Convert.ToInt32(txtPieceCornerY.Text));
            imageSettings.PieceHeight = Convert.ToInt32(txtPieceHeight.Text);
            imageSettings.PieceWidth = Convert.ToInt32(txtPieceWidth.Text);


            imgPieceThumb.Image = imageSettings.PieceThumbnail;
        }
    }
}