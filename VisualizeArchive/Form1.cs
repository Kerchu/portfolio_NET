using System;
using System.Windows.Forms;
using System.IO;

namespace VisualizeArchive
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSeeArch_Click(object sender, EventArgs e)
        {
            // Create an OpenFileDialog instance to select a text file.
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Archive|*.txt";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Read the contents of the selected text file.
                string filePath = openFileDialog.FileName;
                string archCont = File.ReadAllText(filePath);

                // Display the file contents in a MessageBox.
                MessageBox.Show($"Archive Content:\n\n{archCont}", "Selected Archive");
            }
        }
    }
}
