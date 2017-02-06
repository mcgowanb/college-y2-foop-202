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

namespace exception_q6
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
                int number1 = Convert.ToInt32(txt1.Text);
                int number2 = Convert.ToInt32(txt2.Text);

                int result = number2 / number1;
                txtBlkAns.Text = Convert.ToString(result);

            }

            catch (FormatException ex)
            {
                MessageBox.Show("Non numeric data entered");
            }

            catch (DivideByZeroException ex)
            {
                MessageBox.Show("Cannot divide by zero");
            }

        }
    }
}
