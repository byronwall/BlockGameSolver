using System;
using System.Drawing;
using System.Windows.Forms;

namespace ImageAnalyzer
{
    public partial class ColorsForm : Form
    {
        private readonly ImageSettings imageSettings;

        public ColorsForm(ImageSettings imageSettings)
            : this()
        {
            this.imageSettings = imageSettings;
        }

        public ColorsForm()
        {
            InitializeComponent();
        }

        private void btnAssignColor_Click(object sender, EventArgs e)
        {
            //assign the selected color to the selected item

            ColorPoint point = ((ColorPoint)lstColors.SelectedItem);
            point.Name = txtColorName.Text;
            lstColors.SelectedIndex += (lstColors.SelectedIndex < lstColors.Items.Count - 1) ? 1 : 0;
        }

        private void LoadColors()
        {
            lstColors.DataSource = imageSettings.ColorData;
        }

        private void lstColors_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox control = (ListBox)sender;
            ColorPoint colorPoint = (ColorPoint)control.SelectedItem;

            control.BackColor = Color.FromArgb(colorPoint.ImageColor);

            txtColorName.Text = colorPoint.Name;
            txtColorSource.Text = colorPoint.Source;
        }

        private void ColorsForm_Load(object sender, EventArgs e)
        {
            LoadColors();
        }
    }
}