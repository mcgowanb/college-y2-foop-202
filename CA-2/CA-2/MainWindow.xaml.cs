/* database connection string
 * Server=tcp:college-db-server.database.windows.net,1433;Initial Catalog=news-reader;Persist Security Info=False;User ID={brian};Password={CollegeDb1};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

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
            //using try catch to handle empty dates & no type selection and display a prompt
            try
            {
                string start = dpStartDate.Text;
                string end = dpEndDate.Text;

                if(cbxCarType.SelectedIndex == -1)
                    throw new FormatException("Please choose a vehicle type");

                if (start.Length == 0 || end.Length == 0)
                    throw new FormatException("Please enter a start and end date");

                int carType = Convert.ToInt32(cbxCarType.SelectedValue);

                lbxAvailableCars.ItemsSource = GetAvailableVehicles(start, end, carType);
            }
            catch (FormatException fe)
            {
                MessageBox.Show(fe.Message);
            }

        }

        /// <summary>
        /// Gets available vehicles for hire. Checkes the booked table and removes any cars that are booked
        /// for the date period that has been selected
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        private List<Car> GetAvailableVehicles(string start, string end, int carType)
        {
            DateTime startDate = Convert.ToDateTime(start);
            DateTime endDate = Convert.ToDateTime(end);

            var bookings = from b in db.Bookings
                           where !((startDate < b.StartDate && endDate < b.EndDate) || startDate > b.EndDate)
                           select b.CarID;


            List<Car> availableCars = FilterCars(bookings, carType);
            return availableCars;
        }


        /// <summary>
        /// returns a list of cars from the db, excluding the ones that have bookings
        /// </summary>
        /// <param name="carType"></param>
        /// <returns></returns>
        private List<Car> FilterCars(IQueryable<int?> bookings, int carType)
        {
            if (carType == 0)
            //all car types
            {
                var results = from c in db.Cars
                              select c;
                    return results.ToList();
            }
            else
            {
                var results = from c in db.Cars
                              where !(bookings).Contains(c.ID) && c.CarTypeID == carType
                              select c;
                return results.ToList();
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
            Car c = lbxAvailableCars.SelectedItem as Car;
            if (c != null)
            {
                String message = SaveBooking(c);
                MessageBox.Show(message);
                ResetScreen();
            }
        }

        /// <summary>
        /// persist the vehicle booking to the database
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        private String SaveBooking(Car c)
        {
            Booking b = new Booking
            {
                CarID = c.ID,
                StartDate = Convert.ToDateTime(dpStartDate.Text),
                EndDate = Convert.ToDateTime(dpEndDate.Text)
            };

            db.Bookings.Add(b);
            int rValue = db.SaveChanges();
            String message = String.Format("Booking Confirmation\n\n{0} record inserted\nCarID: {1}\nMake: {2}\nModel: {3}\nRental Date: {4}\nReturn Date: {5}",
                rValue,
                c.ID,
                c.Make,
                c.Model,
                dpStartDate.Text,
                dpEndDate.Text
                );
            return message;
           
        }


        /// <summary>
        /// Resets all fields on the screen
        /// </summary>
        private void ResetScreen()
        {
            cbxCarType.SelectedItem = null;
            dpStartDate.Text = dpEndDate.Text = null;
            lblCarID.Content = lblCarMake.Content = lblCarModel.Content = lblCarHireDate.Content = lblCarReturnDate = null;
            lbxAvailableCars.ItemsSource = null;
        }

        /// <summary>
        /// returns car object from database based on id passed
        /// </summary>
        /// <param name="carID"></param>
        /// <returns></returns>
        private Car GetCarDetails(int carID)
        {
            Car car = (from c in db.Cars
                       where c.ID == carID
                       select c).First();
            return car;

        }

    }

}
