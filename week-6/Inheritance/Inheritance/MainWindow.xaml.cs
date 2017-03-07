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

namespace Inheritance
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Employee> employeeList;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            employeeList = new List<Employee>();
            Employee e1 = new Doctor("Brian McGowan", "Hospital Road", "123456", 50000, "Consultant");
            Employee e2 = new Doctor("Paul Smith", "Mangle Road", "123456", 50000, "SHO");
            Employee e3 = new Doctor("Frank Kelly", "Glass Street", "123456", 50000, "Registrar");

            Employee e4 = new Nurse("Mrs Doubtfire", "Pudding Lane", "23433", 1234, "Matron", "Paediatrics");
            Employee e5 = new Nurse("Mrs Doyle", "Craggy Island", "23433", 1234, "Student Nurse", "Paediatrics");
            Employee e6 = new Nurse("Ted Crilly", "Bull Island", "23433", 1234, "Surgery Nurse", "Emergency Medicine");

            employeeList.Add(e1);
            employeeList.Add(e2);
            employeeList.Add(e3);
            employeeList.Add(e4);
            employeeList.Add(e5);
            employeeList.Add(e6);

            lbxStaff.ItemsSource = employeeList;
        }
    }
}
