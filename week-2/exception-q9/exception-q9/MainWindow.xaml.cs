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

namespace exception_q9
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

        private void btnSolve_Click(object sender, RoutedEventArgs e)
        {
            int a = Convert.ToInt32(txt_a.Text);
            int b = Convert.ToInt32(txt_b.Text);
            int c = Convert.ToInt32(txt_c.Text);

            try
            {
                double answer = CalculateTriangleArea(a, b, c);
                txtBlkRootA.Text = Convert.ToString(answer);
            }
            catch (ArithmeticException ae)
            {
                MessageBox.Show(ae.Message);
            }

        }

        private double CalculateTriangleArea(int a, int b, int c)
        {
            int s = CalculateS(a, b, c);
            int numberToCalculate = s * (s - a) * (s - b) * (s - c);
            if (numberToCalculate < 0)
            {
                throw new ArithmeticException("Unable to calculate area, negative value found");
            }
            else return Math.Sqrt(numberToCalculate);
        }

        private int CalculateS(int a, int b, int c)
        {
            return (a + b + c) / 2;
        }
    }
}
