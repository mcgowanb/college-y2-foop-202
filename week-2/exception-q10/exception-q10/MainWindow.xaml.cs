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

namespace exception_q10
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
            int d = Convert.ToInt32(txt_a.Text);
            int m = Convert.ToInt32(txt_b.Text);
            int y = Convert.ToInt32(txt_c.Text);

            try
            {
                DateTime dt = ConvertToDateTime(d, m, y);
                txtBlkRootA.Text = dt.ToString();
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private DateTime ConvertToDateTime(int d, int m, int y)
        {
            String dFormat = String.Format("{0}-{1}-{2}", y, m, d);
            DateTime date = Convert.ToDateTime(dFormat);
            return date;
        }
    }
}
