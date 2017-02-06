using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace exceptions
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                double number = Convert.ToDouble(txtNumber.Text);
                txtBlkAns.Text = String.Format("The area of a square with a side of {0} has an area of {1}", number, number * number);
            }
            catch (FormatException fe)
            {
                txtBlkAns.Text = "Input number was not correctly formatted.";
                MessageBox.Show(fe.Message);
                MessageBox.Show(fe.ToString());

                txtNumber.Text = "";
                txtNumber.Focus();
            }

            finally
            {
                MessageBox.Show("Have another go");
            }

        }
    }
}
