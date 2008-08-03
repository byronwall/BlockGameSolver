using System.Windows.Forms;

namespace BlockGameSolver.StatisticalAnalysis.Visual
{
    static class FormExtensions
    {
        public static void EnableDragDropFilename(this TextBox textBox)
        {
            textBox.AllowDrop = true;
            textBox.DragEnter += textBox_DragEnter;
            textBox.DragDrop += textBox_DragDrop;
        }

        static void textBox_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] strings = (string[])e.Data.GetData(DataFormats.FileDrop);
                string path = strings[0];

                TextBox control = (TextBox)sender;
                control.Text = path;
            }
        }

        static void textBox_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }
    }
}