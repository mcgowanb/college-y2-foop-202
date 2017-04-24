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

namespace CA_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CarRentalEntities db;
        public MainWindow()
        {
            db = new CarRentalEntities();
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var query = from ct in db.CarTypes
                        select ct;

            List<CarType> carTypes = query.ToList();
            //manually adding the "all" types to the list
            carTypes.Insert(0, new CA_2.CarType { ID = 0, Name = "All" });
            cbxCarType.ItemsSource = carTypes;
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string start = dpStartDate.Text;
                string end = dpEndDate.Text;
                if (start.Length == 0 || end.Length == 0)
                    throw new FormatException("Please enter a start and end date");

                int carType = Convert.ToInt32(cbxCarType.SelectedValue);

                List<Booking> bookings = GetBookedVehicles(start, end);
                List<Car> list = GetCarsFromDB(carType);
                List<Car> availableCars = FilterBookedCars(bookings, list);
                lbxAvailableCars.ItemsSource = list;
            }
            catch (FormatException fe)
            {
                MessageBox.Show(fe.Message);
            }

        }


        /// <summary>
        /// Removes cars from the vehicleList if they are a match on the bookings list result set.
        /// </summary>
        /// <param name="bookings"></param>
        /// <param name="vehicleList"></param>
        /// <returns></returns>
        private List<Car> FilterBookedCars(List<Booking> bookings, List<Car> vehicleList)
        {
            foreach (var item in bookings)
            {
                var matchingvalues = vehicleList
                    .Where(car => car.ID.Equals(item.CarID));
                if (matchingvalues != null)
                {
                    vehicleList.RemoveAll(car => car.ID == item.CarID);
                }
            }
            return vehicleList;
        }

        /// <summary>
        /// returns any bookings that match the start or end date entered.
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        private List<Booking> GetBookedVehicles(string start, string end)
        {
            DateTime startDate = Convert.ToDateTime(start);
            DateTime endDate = Convert.ToDateTime(end);

            var query = from b in db.Bookings
                        where b.StartDate >= startDate
                        && b.EndDate <= endDate
                        select b;

            return query.ToList();

        }


        /// <summary>
        /// returns a list of cars from the db.
        /// </summary>
        /// <param name="carType"></param>
        /// <returns></returns>
        private List<Car> GetCarsFromDB(int carType)
        {

            if (carType == 0)
            {
                var query = from c in db.Cars
                            select c;
                return query.ToList();
            }
            else
            {
                var query = from c in db.Cars
                            where c.CarTypeID == carType
                            select c;
                return query.ToList();
            }
        }

        private void lbxAvailableCars_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Car c = lbxAvailableCars.SelectedItem as Car;
            if (c != null)
            {
                lblCarID.Content = c.ID;
                lblCarMake.Content = c.Make;
                lblCarModel.Content = c.Model;
                lblCarHireDate.Content = dpStartDate.Text;
                lblCarReturnDate.Content = dpEndDate.Text;
                btnBook.IsEnabled = true;
            }
            else
                btnBook.IsEnabled = false;
        }

        private void btnBook_Click(object sender, RoutedEventArgs e)
        {
            ResetScreen();
            //Car c = lbxAvailableCars.SelectedItem as Car;
            //if (c != null)
            //{
            //    Booking b = new Booking
            //    {
            //        CarID = c.ID,
            //        StartDate = Convert.ToDateTime(dpStartDate.Text),
            //        EndDate = Convert.ToDateTime(dpEndDate.Text)
            //    };

            //    db.Bookings.Add(b);
            //    int rValue = db.SaveChanges();
            //    String message = String.Format("Booking Confirmation\n\n{0} record inserted\nCarID: {1}\nMake: {2}\nModel: {3}\nRental Date: {4}\nReturn Date: {5}",
            //        rValue,
            //        c.ID,
            //        c.Make,
            //        c.Model,
            //        dpStartDate.Text,
            //        dpEndDate.Text
            //        );
            //    MessageBox.Show(message);
            //    ResetScreen();
            //}
        }

        private void ResetScreen()
        {
            cbxCarType.SelectedItem = null;
            dpStartDate.Text = dpEndDate.Text = null;
            lblCarID.Content = lblCarMake.Content = lblCarModel.Content = lblCarHireDate.Content = lblCarReturnDate = null;
        }

    }

}
