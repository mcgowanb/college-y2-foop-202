using Humanizer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
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
        private const String FILE_NAME = "vehicles.txt";
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
            lbxVehicleList.ItemsSource = vehicleList;
            //GenerateDummyList();
        }

        private void CloseApp(object sender, ExecutedRoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void GenerateDummyList()
        {
            Vehicle v1 = new Car("Ford", "Focus", 24000, 2010, "#80FF0000", 120000, CarBodyType.Convertible);
            v1.Image = "focus.png";
            v1.Description = "description text and some more blah blah blah more text yet more text again and so on and so on and so on";
            Vehicle v2 = new Van("Toyota", "Hiace", 500, 1998, "pink", 240000, VanBodyType.CombiVan, WheelBase.Short);
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

        private void CarTypeFilter_Click(object sender, RoutedEventArgs e)
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
                    if (item.Type.ToString().Equals(type))
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
            //opening new window
            VehicleDetails details = new VehicleDetails();
            details.Owner = this;
            details.ShowDialog();

            //create new object for the list if user added it
            if (Application.Current.Properties["vehicle"] != null)
            {
                Vehicle nVehicle = Application.Current.Properties["vehicle"] as Vehicle;
                vehicleList.Add(nVehicle);
                //removing the passed object, so not to create duplicates if canclling the add operation
                Application.Current.Properties["vehicle"] = null;
            }

            lbxVehicleList.ItemsSource = null;
            lbxVehicleList.ItemsSource = vehicleList;
        }

        private void cbxVehicleFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            String selected = cbxVehicleFilter.SelectedItem as String;
            SortVehicleList(selected);
        }

        /// <summary>
        /// Sorts list by price, make or type
        /// Want to change this to an enum if possible.
        /// </summary>
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

        private void lbxVehicleList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Vehicle v = lbxVehicleList.SelectedItem as Vehicle;
            if (v != null)
                UpdateDisplay(v);
        }

        private void UpdateDisplay(Vehicle v)
        {
            lblMake.Content = v.Make;
            lblModel.Content = v.Model;
            lblPrice.Content = String.Format("{0:c2}", v.Price);
            lblYear.Content = v.Year.ToString();
            lblMileage.Content = v.Mileage;
            lblDesc.Text = v.Description;
            BitmapImage image;
            if (v.Image != null)
            {
                String dir = Utility.GetImageDirectory();
                image = new BitmapImage(new Uri(String.Format("{0}\\{1}", dir, v.Image), UriKind.Absolute));
            }
            else
            {
                image = new BitmapImage();
            }
            imgVehicle.Source = image;

        }

        private bool WriteDataToFile()
        {
            String dir = Utility.GetWorkingDirectory();
            String[] lines = new String[vehicleList.Count];

            for (int i = 0; i < lines.Length; i++)
            {
                Vehicle v = vehicleList.ElementAt(i) as Vehicle;
                lines[i] = v.LineDataForFile();
            }

            try
            {
                File.WriteAllLines(dir + FILE_NAME, lines);
                return true;
            }
            catch (IOException e)
            {
                MessageBox.Show("Error Saving File");
                return false;
            }
        }

        private void ButtonWrite_Click(object sender, RoutedEventArgs e)
        {
            if (WriteDataToFile())
            {
                MessageBox.Show("File Saved Successfully");
            }
        }

        private void ButtonLoad_Click(object sender, RoutedEventArgs e)
        {
            String dir = Utility.GetWorkingDirectory();
            String[] lines = File.ReadAllLines(dir + FILE_NAME);

            foreach (var line in lines)
            {
                Vehicle v;
                String[] elems = line.Split(',');
                VehicleType vt = Utility.GetVehicleType(elems[0]);
                switch (vt)
                {
                    case VehicleType.Car:
                        v = new Car().CreateFromFile(elems);
                        break;
                    case VehicleType.Motorbike:
                        v = new MotorBike().CreateFromFile(elems);
                        break;
                    case VehicleType.Van:
                        v = new Van().CreateFromFile(elems);
                        break;
                    default:
                        v = null;
                        break;
                }
                if (v != null)
                    vehicleList.Add(v);
            }

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Vehicle v = lbxVehicleList.SelectedItem as Vehicle;
            vehicleList.Remove(v);
        }
    }
}
