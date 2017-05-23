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

namespace final_exam
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Employee> employees;
        List<String> SortList;
        public MainWindow()
        {
            InitializeComponent();
        }

       
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            employees = GetEmployees();
            lbxEmployees.ItemsSource = employees;

            SortList = new List<String>();
            SortList.Add("First Name");
            SortList.Add("Last Name");
            cbxSortBy.ItemsSource = SortList;
        }

        private void TypeFilter_Click(object sender, RoutedEventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            String selected = rb.Content.ToString();
            //using command paramater so I can pass another custom string to the method
            String p = rb.CommandParameter.ToString();
            FilterList(p);
        }



        private List<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>();

            PartTimeEmployee pt1 = new PartTimeEmployee() { FirstName = "Tom", LastName = "Jones", PPS = "P87654321", HourlyRate = 10, HoursWorked = 100 };
            PartTimeEmployee pt2 = new PartTimeEmployee() { FirstName = "Mary", LastName = "McKenna", PPS = "P87654322", HourlyRate = 12, HoursWorked = 160 };
            PartTimeEmployee pt3 = new PartTimeEmployee() { FirstName = "Sally", LastName = "Purcell", PPS = "P87654323", HourlyRate = 9, HoursWorked = 60 };
            PartTimeEmployee pt4 = new PartTimeEmployee() { FirstName = "Michael", LastName = "Egan", PPS = "P87654324", HourlyRate = 15, HoursWorked = 120 };
            PartTimeEmployee pt5 = new PartTimeEmployee() { FirstName = "Sue", LastName = "Quinn", PPS = "P87654325", HourlyRate = 20, HoursWorked = 80 };


            FullTimeEmployee ft1 = new FullTimeEmployee() { FirstName = "Mick", LastName = "Smith", PPS = "F12345678", Salary = 26000, ReviewDate = DateTime.Now.AddMonths(12) };
            FullTimeEmployee ft2 = new FullTimeEmployee() { FirstName = "Joe", LastName = "Agnew", PPS = "F12345678", Salary = 25000, ReviewDate = DateTime.Now.AddMonths(6) };
            FullTimeEmployee ft3 = new FullTimeEmployee() { FirstName = "Sarah", LastName = "Ryan", PPS = "F12345678", Salary = 25000, ReviewDate = DateTime.Now.AddMonths(3) };
            FullTimeEmployee ft4 = new FullTimeEmployee() { FirstName = "Barry", LastName = "McMahon", PPS = "F12345678", Salary = 25000, ReviewDate = DateTime.Now.AddMonths(12) };
            FullTimeEmployee ft5 = new FullTimeEmployee() { FirstName = "Linda", LastName = "Tormey", PPS = "F12345678", Salary = 25000, ReviewDate = DateTime.Now.AddMonths(6) };


            employees.Add(pt1);
            employees.Add(pt2);
            employees.Add(pt3);
            employees.Add(pt4);
            employees.Add(pt5);

            employees.Add(ft1);
            employees.Add(ft2);
            employees.Add(ft3);
            employees.Add(ft4);
            employees.Add(ft5);
            return employees;
        }

        private void lbxEmployees_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Employee emp = lbxEmployees.SelectedItem as Employee;
            if (emp != null)
            {
                //if selection made display in the text area
                txtBlkPayslip.Text = emp.GetPaySlip();
            }
        }


        //sort the list of employees either by first name or last name
        private void cbxSortBy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            String sortBy = cbxSortBy.SelectedItem as String;

            IEnumerable<Employee> filterList = new List<Employee>(employees);
            if (sortBy != null)
            {
                switch (sortBy)
                {
                    case "First Name":
                        filterList = employees.OrderBy(i => i.FirstName);
                        break;
                    case "Last Name":
                        filterList = employees.OrderBy(i => i.LastName);
                        break;
                    default:
                        //failsafe in case of something erroneous
                        filterList = employees;
                        break;
                }
                //replacing the original list contents here so as to maintain sort order when modified by
                //the filter list. ie after the list is sorted and then filtered the sort order will be maintained
                employees = new List<Employee>(filterList);
                lbxEmployees.ItemsSource = null;
                lbxEmployees.ItemsSource = filterList;
            }

        }

        //filter list by employee type
        private void FilterList(String selected)
        {
            lbxEmployees.ItemsSource = null;
            if(selected == "All")
            {
                lbxEmployees.ItemsSource = employees;
            }
            else
            {
                List<Employee> filteredList = new List<Employee>();
                foreach (var emp in employees)
                {
                    //check to see if the class type is the same as the value passed from the radio button
                    String classType = emp.GetType().Name;
                    if (classType.Equals(selected))
                        filteredList.Add(emp);
                }
                lbxEmployees.ItemsSource = filteredList;
            }
        }
    }
}
