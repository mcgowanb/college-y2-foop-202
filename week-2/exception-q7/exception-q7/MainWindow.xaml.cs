using System;
using System.Collections.Generic;
using System.IO;
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

namespace exception_q7
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

        private void btnLoadData_Click(object sender, RoutedEventArgs e)
        {
            DirectoryInfo parent = Directory.GetParent(Directory.GetCurrentDirectory());
            DirectoryInfo gp = Directory.GetParent(parent.ToString());

            try
            {
                String[] lines = File.ReadAllLines(gp + "\\salary.txt");
                String[] elems = lines[0].Split(' ');

                int salary = Convert.ToInt32(elems[1]);

                txtSalaryInfo.Text = String.Format("Name: {0}\nSalary: {1}", elems[0], Convert.ToString(salary));
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show("Error Loading file");
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Salary not of numeric data");
            }

        }
    }
}
