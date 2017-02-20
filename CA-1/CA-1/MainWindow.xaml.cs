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

        private ObservableCollection<Vehicle> vehicles;
        private ObservableCollection<Vehicle> filteredVehicles;
        private List<String> filterTypes;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            vehicles = new ObservableCollection<Vehicle>();
            filteredVehicles = new ObservableCollection<Vehicle>();
            filterTypes = new List<String>();
            CreateFilterList();
            GenerateDummyList();
        }


        private void GenerateDummyList()
        {
            Vehicle v1 = new Car("Ford", "Focus", 24000, 2010, "green");
            Vehicle v2 = new Van("Toyota", "Hiace", 500, 1998, "pink");
            Vehicle v3 = new MotorBike("Suzuki", "AX-100", 12000, 2009, "Yellow");
            vehicles.Add(v1);
            vehicles.Add(v2);
            vehicles.Add(v3);

            lbxVehicleList.ItemsSource = vehicles;
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
                lbxVehicleList.ItemsSource = vehicles;
            }
            else
            {
                foreach (var item in vehicles)
                {
                    if (item.Type.ToString() .Equals(type))
                    {
                        filteredVehicles.Add(item);
                    }
                }
                lbxVehicleList.ItemsSource = filteredVehicles;
            }
        }
    }
}
