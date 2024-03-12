using System;
using System.Collections.Generic;
using System.Windows;

namespace UnitConverter
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            List<string> units = new List<string> { "Meter", "Inch", "Kilogram", "Pound" };
            changeUnit1.ItemsSource = units;
            changeUnit2.ItemsSource = units;
        }

        private void btnConvert(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(txtAmount.Text, out double amount))
            {
                string fromUnit = changeUnit1.SelectedItem as string;
                string toUnit = changeUnit2.SelectedItem as string;

                double result = 0;

                if ((fromUnit == "Meter" && toUnit == "Inch") || (fromUnit == "Inch" && toUnit == "Meter"))
                {
                    result = UnitConverter.ConvertLength(amount, fromUnit, toUnit);
                }
                else if ((fromUnit == "Kilogram" && toUnit == "Pound") || (fromUnit == "Pound" && toUnit == "Kilogram"))
                {
                    result = UnitConverter.ConvertWeight(amount, fromUnit, toUnit);
                }
                else
                {
                    lblResults.Text = "Invalid conversion.";
                    return;
                }

                lblResults.Text = $"{amount} {fromUnit} = {result} {toUnit}";
            }
            else
            {
                lblResults.Text = "Enter a valid input.";
            }
        }
    }

    public class UnitConverter
    {
        public static double ConvertLength(double amount, string fromUnit, string toUnit)
        {
            if (fromUnit == "Meter" && toUnit == "Inch")
            {
                return amount * 39.3701; // 1 meter = 39.3701 inches
            }
            else if (fromUnit == "Inch" && toUnit == "Meter")
            {
                return amount / 39.3701; // 1 inch = 0.0254 meters
            }
            return amount;
        }

        public static double ConvertWeight(double amount, string fromUnit, string toUnit)
        {
            if (fromUnit == "Kilogram" && toUnit == "Pound")
            {
                return amount * 2.20462; // 1 kilogram = 2.20462 pounds
            }
            else if (fromUnit == "Pound" && toUnit == "Kilogram")
            {
                return amount / 2.20462; // 1 pound = 0.453592 kilograms
            }
            return amount;
        }
    }
}
