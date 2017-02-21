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
using System.Windows.Shapes;

namespace CA_1
{
    /// <summary>
    /// Interaction logic for VehicleDetails.xaml
    /// </summary>
    public partial class VehicleDetails : Window
    {
        private Vehicle v;
        public VehicleDetails()
        {
            InitializeComponent();
        }

        private void btnCanx_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SetVehicleTypes();
            if(Application.Current.Properties["vehicle"] != null)
            {
                v = (Vehicle)Application.Current.Properties["vehicle"];
                PopulatePageInformation();
            }
        }

        private void SetVehicleTypes()
        {
            List<String> types = Enum.GetNames(typeof(VehicleType)).ToList();
            cbxType.ItemsSource = types;
        }

        private void txtBxImage_DblClick(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("sdfsdf");
        }

        private void PopulatePageInformation()
        {
            cbxType.SelectedItem = v.Type.ToString();
            txtBxMake.Text = v.Make;
            txtBxModel.Text = v.Model;
            txtBxPrice.Text = v.Price.ToString();
            txtBxYear.Text = v.Year.ToString();
            txtBxColour.Text = v.Colour.ToString();
            txtBxMileage.Text = v.Mileage.ToString();
            txtBxDescription.Text = v.Description;
            txtBxImage.Text = v.Image;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            v.Model = txtBxModel.Text;
            this.Close();
        }
    }
}
