using System.Windows;

namespace WpfApp1
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void btnConvert_Click(object sender, RoutedEventArgs e)
        {
            if (decimal.TryParse(txtDolar.Text, out decimal dolar))
            {
                decimal euros = dolar * 0.85m; 
                lblResultado.Text = $"{dolar} USD equals to {euros} Euros";
            }
            else
            {
                MessageBox.Show("input a valid value");
            }
        }
    }
}

