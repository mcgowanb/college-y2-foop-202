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
using System.Windows.Shapes;

namespace CA_1
{
    /// <summary>
    /// Interaction logic for VehicleDetails.xaml
    /// </summary>
    public partial class VehicleDetails : Window
    {
        private Vehicle v;
        private Boolean isEdit;
        private String originalFilePath, folderPath;
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
            if (Application.Current.Properties["vehicle"] != null)
            {
                isEdit = true;
                v = (Vehicle)Application.Current.Properties["vehicle"];
                Application.Current.Properties["vehicle"] = null;
                originalFilePath = v.Image ?? txtBxImage.Text;
                PopulatePageInformation();
            }
            else originalFilePath = txtBxImage.Text;
        }


        private void SetVehicleTypes()
        {
            List<String> types = Enum.GetNames(typeof(VehicleType)).ToList();
            cbxType.ItemsSource = types;
        }


        /// <summary>
        /// Dialog box for file input.Changes File Path name when user selects a file
        /// </summary>
        private void txtBxImage_DblClick(object sender, MouseButtonEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.Filter = "Images (*.JPG;*.JPEG;*.PNG) | *.JPG;*.JPEG;*.PNG";
            Nullable<bool> result = dialog.ShowDialog();
            if (result == true)
            {
                txtBxImage.Text = dialog.FileName.Substring(dialog.FileName.LastIndexOf('\\') + 1);
                folderPath = dialog.FileName.Substring(0, dialog.FileName.LastIndexOf('\\') + 1);
            }
        }

        /// <summary>
        /// Fills the contents of the page if an object has been passed over
        /// </summary>
        private void PopulatePageInformation()
        {
            cbxType.SelectedItem = v.Type.ToString();
            txtBxMake.Text = v.Make;
            txtBxModel.Text = v.Model;
            txtBxPrice.Text = v.Price.ToString();
            txtBxYear.Text = v.Year.ToString();
            Color color = Utility.GetColourFromString(v.Colour);
            ClrPckerColour.SelectedColor = color;
            txtBxMileage.Text = v.Mileage.ToString();
            txtBxDescription.Text = v.Description;
            txtBxImage.Text = v.Image;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (isEdit)
                UpdateObjectInformation();
            else CreateNewObject();
            this.Close();
        }

        /// <summary>
        /// Grab page information on save and create a new vehicle object depending 
        /// on what the user had chosen as the type
        /// </summary>
        private void CreateNewObject()
        {
            Vehicle v;
            VehicleType type = GetVehicleType(cbxType);
            String make = txtBxMake.Text;
            String model = txtBxModel.Text;
            int price = Utility.ConvertStringToNumber(txtBxPrice.Text);
            int year = Utility.ConvertStringToNumber(txtBxYear.Text);
            String color = ClrPckerColour.SelectedColor.ToString();
            int mileage = Utility.ConvertStringToNumber(txtBxMileage.Text);
            String desc = txtBxDescription.Text;
            String image = txtBxImage.Text;

            switch (type)
            {
                case VehicleType.Car:
                    v = new Car();
                    break;
                case VehicleType.Motorbike:
                    v = new MotorBike();
                    break;
                case VehicleType.Van:
                    //add bodytpe as a ctor param
                    v = new Van();
                    break;
                default:
                    v = null;
                    break;
            }

            if (v != null)
            {
                v.Make = make;
                v.Model = model;
                v.Price = price;
                v.Year = year;
                v.Colour = color;
                v.Mileage = mileage;
                v.Description = desc;
                v.Mileage = mileage;
                v.Image = image;
                if (v.Image != originalFilePath)
                    v.Image = UpdateVehicleImage(v.Image);
            }

            Application.Current.Properties["vehicle"] = v;
        }

        private String UpdateVehicleImage(String imageName)
        {
            //check for file name duplicates, update if needs be.
            String imageDir = Utility.GetImageDirectory();
            String[] fileNames = Directory.GetFiles(imageDir);
            string sourceFile = folderPath + imageName;

            foreach (var item in fileNames)
            {
                String s = item.Substring(item.LastIndexOf('\\') + 1);
                if (s == imageName)
                {
                    imageName = String.Format("{1}{0}", imageName, 1);
                }
            }
            string destinationFile = imageDir + imageName;

            File.Copy(sourceFile, destinationFile);
            return imageName;
        }

        /// <summary>
        /// Updating the object information at this stage. No need to pass back as a reference to the object
        /// been passed to this page which we are updating
        /// </summary>
        private void UpdateObjectInformation()
        {
            v.Type = GetVehicleType(cbxType);
            v.Make = txtBxMake.Text;
            v.Model = txtBxModel.Text;
            v.Price = Convert.ToInt32(txtBxPrice.Text);
            v.Year = Convert.ToInt32(txtBxYear.Text);
            v.Colour = ClrPckerColour.SelectedColor.ToString();
            v.Mileage = Convert.ToInt32(txtBxMileage.Text);
            v.Description = txtBxDescription.Text;
            v.Image = txtBxImage.Text;
            if (v.Image != originalFilePath)
                v.Image = UpdateVehicleImage(v.Image);

        }



        private VehicleType GetVehicleType(ComboBox cBox)
        {
            VehicleType vType;
            Enum.TryParse(cBox.SelectedItem.ToString(), out vType);
            return vType;
        }
    }
}
