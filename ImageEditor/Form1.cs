using System;
using System.Windows.Forms;
using System.Drawing;

namespace ImageEditor
{
    public partial class Form1 : Form
    {
        private Bitmap originalImage;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnLoadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.png;*.jpg;*.jpeg;*.gif;*.bmp";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string routeImage = openFileDialog.FileName;
                originalImage = new Bitmap(routeImage);
                pictureBox.Image = originalImage;
            }
        }

        private void trackBarBrightness_Scroll(object sender, EventArgs e)
        {
            if (originalImage != null)
            {
                int brightnessValue = trackBarBrightness.Value;
                Bitmap adjustedImage = AdjustBrightness(originalImage, brightnessValue);
                pictureBox.Image = adjustedImage; // Display the adjusted image with brightness.
            }
        }

        private void trackBarSize_Scroll(object sender, EventArgs e)
        {
            if (originalImage != null)
            {
                int newSize = trackBarSize.Value;
                Bitmap adjustedImage = ResizeImage(originalImage, newSize, newSize);
                pictureBox.Image = adjustedImage; // Display the adjusted image with size change.
            }
        }

        private Bitmap AdjustBrightness(Bitmap image, int brightnessValue)
        {
            Bitmap adjustedImage = new Bitmap(image.Width, image.Height);

            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    Color originalColor = image.GetPixel(x, y);
                    int r = Math.Max(0, Math.Min(255, originalColor.R + brightnessValue));
                    int g = Math.Max(0, Math.Min(255, originalColor.G + brightnessValue));
                    int b = Math.Max(0, Math.Min(255, originalColor.B + brightnessValue));
                    Color newColor = Color.FromArgb(r, g, b);
                    adjustedImage.SetPixel(x, y, newColor);
                }
            }

            return adjustedImage;
        }

        private Bitmap ResizeImage(Bitmap image, int width, int height)
        {
            return new Bitmap(image, new Size(width, height));
        }
    }
}