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
        private String originalFilePath, folderPath, action;
        public VehicleDetails()
        {
            InitializeComponent();
            action = "Add";
        }

        private void btnCanx_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Window loaded method. Sets permissions for fields, genreates data to be populated and so on
        /// basis init metho to set everything up
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            VehicleType vt;
            SetListValues();

            if (Application.Current.Properties["vehicle"] != null)
            {
                //we are editing an object, so set the data fields accordingly
                isEdit = true;
                action = "Edit";
                Vehicle tmp = (Vehicle)Application.Current.Properties["vehicle"];
                DefineVehicleType(tmp.Type);
                Application.Current.Properties["vehicle"] = null;
                originalFilePath = v.Image ?? txtBxImage.Text;
                PopulateVehicleData();
                vt = Utility.GetVehicleType(v.Type.ToString());
            }
            else
            {
                //new vehicle object, so default to car and set the original file path so we know its changed
                //when an image gets added
                originalFilePath = txtBxImage.Text;
                vt = VehicleType.Car;
            }
            //set vehicle type and wheelbase lists
            //contextually set the body types depending on car or van
            SetBodyTypeLists(vt);
            //if it add, set the label to add {VehicleType} or else Edit {Vehicle Type}
            SetLabelAndTypeState();
        }

        /// <summary>
        /// Depending on the vechicle type, the idea is to set the vehicle to a more specific subclass so 
        /// if the sub class has additional properties they are available in here.
        /// </summary>
        /// <param name="t"></param>
        private void DefineVehicleType(VehicleType t)
        {
            switch (t)
            {
                case VehicleType.Car:
                    v = (Car)Application.Current.Properties["vehicle"];
                    break;
                case VehicleType.Motorbike:
                    v = (MotorBike)Application.Current.Properties["vehicle"];
                    break;
                case VehicleType.Van:
                    v = (Van)Application.Current.Properties["vehicle"];
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// On add or edit, this method checks the type of vehicle and sets the permissions, labels and content of 
        /// the combo boxes that are specific for each vehicle type, disabling them if it is a motorbike
        /// </summary>
        /// <param name="type"></param>
        private void SetBodyTypeLists(VehicleType type)
        {
            List<String> types = new List<String>();
            cbxWheelBase.IsHitTestVisible = false;
            cbxWheelBase.Focusable = false;
            cbxBodyTypes.IsHitTestVisible = true;
            cbxBodyTypes.Focusable = true;
            lblWheelBase.Content = "WheelBase (N/A)";

            switch (type)
            {
                case VehicleType.Car:
                    types = Enum.GetNames(typeof(CarBodyType)).ToList();
                    lblBodyType.Content = "Body Type (Car)";
                    break;
                case VehicleType.Van:
                    types = Enum.GetNames(typeof(VanBodyType)).ToList();
                    lblBodyType.Content = "Body Type (Van)";
                    lblWheelBase.Content = "WheelBase (Van Only)";
                    cbxWheelBase.IsHitTestVisible = true;
                    cbxWheelBase.Focusable = true;
                    break;
                default:
                    lblBodyType.Content = "Body Type (N/A)";
                    cbxBodyTypes.IsHitTestVisible = false;
                    cbxBodyTypes.Focusable = false;
                    break;
            }
            cbxBodyTypes.ItemsSource = types;
        }

        /// <summary>
        /// Set Vehicle Types and van details. Only needed on on load as the lists do not change regardless of 
        /// the vehicle type. all that happens is the field is read only or not.
        /// </summary>
        private void SetListValues()
        {
            List<String> types = Enum.GetNames(typeof(VehicleType)).ToList();
            cbxType.ItemsSource = types;

            List<String> wheelBases = Enum.GetNames(typeof(WheelBase)).ToList();
            cbxWheelBase.ItemsSource = wheelBases;
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
        private void PopulateVehicleData()
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
            //set body type & wheelbase if its a van
            if (v.Type.Equals(VehicleType.Van))
            {
                Van nVan = v as Van;
                cbxBodyTypes.SelectedItem = nVan.BodyType.ToString();
                cbxWheelBase.SelectedItem = nVan.WheelBase.ToString();
            }
            else if(v.Type.Equals(VehicleType.Car)){
                Car nCar = v as Car;
                cbxBodyTypes.SelectedItem = nCar.CarType.ToString();
            }
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
            VehicleType type = Utility.GetVehicleType(cbxType.SelectedItem.ToString());
            String make = txtBxMake.Text;
            String model = txtBxModel.Text;
            int price = Utility.ConvertStringToInteger(txtBxPrice.Text);
            int year = Utility.ConvertStringToInteger(txtBxYear.Text);
            String color = ClrPckerColour.SelectedColor.ToString();
            int mileage = Utility.ConvertStringToInteger(txtBxMileage.Text);
            String desc = txtBxDescription.Text;
            String image = txtBxImage.Text;

            switch (type)
            {
                case VehicleType.Car:
                    v = new Car() { CarType = GetCarBodyType(cbxBodyTypes) };
                    break;
                case VehicleType.Motorbike:
                    v = new MotorBike();
                    break;
                case VehicleType.Van:
                    v = new Van(GetVanBodyType(cbxBodyTypes), GetWheelBaseType(cbxWheelBase));
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
                if (v.Image != originalFilePath && v.Image != "")
                    v.Image = UpdateVehicleImage(v.Image);
            }

            Application.Current.Properties["vehicle"] = v;
        }

        /// <summary>
        /// Add or saves vehicle image. Checkes the image folder for a matching filename and changes the image name
        /// to prepend a 1 before hand. Just to prevent the existing image getting overwritten
        /// </summary>
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
            //catch arguement exception
            File.Copy(sourceFile, destinationFile);
            return imageName;
        }

        /// <summary>
        /// Updating the object information at this stage. No need to pass back as a reference to the object
        /// been passed to this page which we are updating
        /// </summary>
        private void UpdateObjectInformation()
        {
            Van nVan;
            v.Type = Utility.GetVehicleType(cbxType.SelectedItem.ToString());
            v.Make = txtBxMake.Text;
            v.Model = txtBxModel.Text;
            v.Price = Convert.ToInt32(txtBxPrice.Text);
            v.Year = Convert.ToInt32(txtBxYear.Text);
            v.Colour = ClrPckerColour.SelectedColor.ToString();
            v.Mileage = Convert.ToInt32(txtBxMileage.Text);
            v.Description = txtBxDescription.Text;
            v.Image = txtBxImage.Text;
            //image has either been added or changed, so update the image in the folder
            if (v.Image != originalFilePath && v.Image != "")
                v.Image = UpdateVehicleImage(v.Image);
            //if its a van
            //problem here with changing from a car / bike to  a van.
            if (v.Type == VehicleType.Van)
            {
                nVan = v as Van;
                nVan.WheelBase = GetWheelBaseType(cbxWheelBase);
                nVan.BodyType = GetVanBodyType(cbxBodyTypes);
                v = nVan;
            }
            else if (v.Type.Equals(VehicleType.Car))
            {
                Car nCar = v as Car;
                nCar.CarType = GetCarBodyType(cbxBodyTypes);
                v = nCar;
            }
        }

        private void cbxType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            VehicleType t = Utility.GetVehicleType(cbxType.SelectedItem.ToString());
            SetBodyTypeLists(t);
            SetLabelAndTypeState();
            //SetVanFieldStates();
        }

        /// <summary>
        /// Sets the header title for the window.
        /// There is a problem with changing a vehicle from one type to another in edit mode. It produces
        /// invalid cast exceptions and so on due to the fact that you're convrting a van to a car and so on.
        /// Exceptions are thrown when it comes to editing the objects again. Easiest Solution currently is to remove the ability 
        /// to edit a vehicle once its created. Needs more thought for a more viable solution
        /// </summary>
        private void SetLabelAndTypeState()
        {
            String vehType = Utility.GetVehicleType(cbxType.SelectedItem.ToString()).ToString();
            lblTitle.Content = String.Format("{0} {1}", action, vehType);
            //cbxType.IsHitTestVisible = !isEdit;
            //cbxType.Focusable = !isEdit;

        }

        /// <summary>
        /// Converts String to Enum Type. Returns unlsited on unset values
        /// </summary>
        /// <param name="cBox"></param>
        /// <returns></returns>
        private WheelBase GetWheelBaseType(ComboBox cBox)
        {
            try
            {
                WheelBase wb;
                Enum.TryParse(cBox.SelectedItem.ToString(), out wb);
                return wb;
            }
            catch (NullReferenceException e)
            {
                return WheelBase.Unlisted;
            }
        }

        /// <summary>
        /// Converts String to Enum Type  Returns unlsited on unset values
        /// </summary>
        /// <param name="cBox"></param>
        /// <returns></returns>
        private VanBodyType GetVanBodyType(ComboBox cBox)
        {
            try
            {
                VanBodyType vt;
                Enum.TryParse(cBox.SelectedItem.ToString(), out vt);
                return vt;
            }
            catch (NullReferenceException e)
            {
                return VanBodyType.Unlisted;
            }
        }

        /// <summary>
        /// Converts String to Enum Type  Returns unlsited on unset values
        /// </summary>
        /// <param name="cBox"></param>
        /// <returns></returns>
        private CarBodyType GetCarBodyType(ComboBox cBox)
        {
            try
            {
                CarBodyType ct;
                Enum.TryParse(cBox.SelectedItem.ToString(), out ct);
                return ct;
            }
            catch (NullReferenceException e)
            {
                return CarBodyType.Unlisted;
            }
        }
    }
}
