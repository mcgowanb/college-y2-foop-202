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

namespace exception_q8
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
                txtBlkRootA.Text = Convert.ToString(RootA(a, b, c));
                txtBlkRootB.Text = Convert.ToString(RootB(a, b, c));
            }
            catch (ArithmeticException ae)
            {
                MessageBox.Show("Error with calculation: " + ae.Message);
            }
        }

        private double RootA(int a, int b, int c)
        {
            double ans = (-b + Math.Sqrt(CalculateSum(a, b, c))) / (2 * a);
            return ans;
        }

        private double RootB(int a, int b, int c)
        {
            double ans = (-b - Math.Sqrt(CalculateSum(a, b, c))) / (2 * a);
            return ans;
        }

        private double CalculateSum(int a, int b, int c)
        {
            double ans = b * b - 4 * a * c;
            if (ans < 0)
            {
                throw new ArithmeticException("Negative value has been returned, There are no solutions available");
            }
            else return ans;
        }

    }
}
