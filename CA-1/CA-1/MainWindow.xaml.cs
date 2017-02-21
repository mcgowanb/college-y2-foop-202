using Humanizer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
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

namespace CA_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private ObservableCollection<Vehicle> vehicleList;
        private ObservableCollection<Vehicle> filteredVehicles;
        private List<String> filterTypes;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            vehicleList = new ObservableCollection<Vehicle>();
            filteredVehicles = new ObservableCollection<Vehicle>();
            filterTypes = new List<String>();
            CreateFilterList();
            GenerateDummyList();
        }


        private void GenerateDummyList()
        {
            Vehicle v1 = new Car("Ford", "Focus", 24000, 2010, "green", 120000);
            v1.Image = "image Link";
            v1.Description = "description text";
            Vehicle v2 = new Van("Toyota", "Hiace", 500, 1998, "pink", 240000);
            Vehicle v3 = new MotorBike("Suzuki", "AX-100", 12000, 2009, "Yellow", 34500);
            vehicleList.Add(v1);
            vehicleList.Add(v2);
            vehicleList.Add(v3);

            lbxVehicleList.ItemsSource = vehicleList;
        }

        private void CreateFilterList()
        {
            string[] s = { "Price", "Mileage", "Make" };
            cbxVehicleFilter.ItemsSource = s;
        }

        private void CarType_Click(object sender, RoutedEventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            String selected = rb.Content.ToString().Singularize(inputIsKnownToBePlural: false);
            FilterList(selected);
        }

        private void FilterList(String type)
        {
            lbxVehicleList.ItemsSource = "";
            filteredVehicles.Clear();
            if (type == "All")
            {
                lbxVehicleList.ItemsSource = vehicleList;
            }
            else
            {
                foreach (var item in vehicleList)
                {
                    if (item.Type.ToString() .Equals(type))
                    {
                        filteredVehicles.Add(item);
                    }
                }
                lbxVehicleList.ItemsSource = filteredVehicles;
            }
        }

        private void Button_Edit(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            //pass the object over if you want to edit the information
            Vehicle v = lbxVehicleList.SelectedItem as Vehicle;
            if (b.Content.ToString() == "Edit" && lbxVehicleList.SelectedItem != null)
            {
                Application.Current.Properties["vehicle"] = lbxVehicleList.SelectedItem as Vehicle;
            }
            VehicleDetails details = new VehicleDetails();
            details.Owner = this;
            details.ShowDialog();

            lbxVehicleList.ItemsSource = null;
            lbxVehicleList.ItemsSource = vehicleList;
        }

        private void cbxVehicleFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            String selected = cbxVehicleFilter.SelectedItem as String;
            SortVehicleList(selected);
        }


        private void SortVehicleList(String selected)
        {
            List<Vehicle> v = new List<Vehicle>(vehicleList);
            IEnumerable<Vehicle> lst = vehicleList;

            switch (selected)
            {
                case "Price":
                    lst = vehicleList.OrderBy(i => i.Price);
                    break;
                case "Mileage":
                    lst = vehicleList.OrderBy(i => i.Make);
                    break;
                case "Make":
                    lst = vehicleList.OrderBy(i => i.Mileage);
                    break;
                default:
                    lst = vehicleList;
                    break;
            }
            lbxVehicleList.ItemsSource = null;
            lbxVehicleList.ItemsSource = new ObservableCollection<Vehicle>(lst);
            
        }
    }
}
