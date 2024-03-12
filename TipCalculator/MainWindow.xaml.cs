using System;
using System.Windows;

namespace TipCalculator
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnCalc_Click(object sender, RoutedEventArgs e)
        {
            if (decimal.TryParse(txtAmountBill.Text, out decimal amountBill))
            {
                decimal tip = amountBill * 0.15m; 
                lblTip.Text = $"The adviced tip amount is: {tip:C}";
            }
            else
            {
                MessageBox.Show("Please, enter a valid input.");
            }
        }
    }
}