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

namespace database
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        NORTHWNDEntities db = new NORTHWNDEntities();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_ClickEX1(object sender, RoutedEventArgs e)
        {
            var query = from c in db.Customers
                        select c.CompanyName;

            lbxEX1.ItemsSource = query.ToList();
        }

        private void btn_ClickEX2(object sender, RoutedEventArgs e)
        {
            var query = from c in db.Customers
                        select c;

            dgEX2.ItemsSource = query.ToList();
        }

        private void btn_ClickEX3(object sender, RoutedEventArgs e)
        {
            var query = from o in db.Orders
                        where o.Customer.City.Equals("London")
                        || o.Customer.City.Equals("Paris")
                        || o.Customer.City.Equals("USA")
                        select new
                        {
                            CustomerName = o.Customer.CompanyName,
                            City = o.Customer.City,
                            Address = o.ShipAddress
                        };

            dgEX3.ItemsSource = query.ToList().Distinct();
        }

        private void btn_ClickEX4(object sender, RoutedEventArgs e)
        {
            var query = from p in db.Products
                        where p.Category.CategoryName.Equals("Beverages")
                        orderby p.ProductID descending
                        select new
                        {
                            p.ProductID,
                            p.ProductName,
                            p.Category.CategoryName,
                            p.UnitPrice
                        };

            dgEX4.ItemsSource = query.ToList();
        }

        private void btn_ClickEX5(object sender, RoutedEventArgs e)
        {
            Product p = new Product()
            {
                ProductName = "Kickapoo Jungle Joy Juice",
                UnitPrice = 12.49m,
                CategoryID = 1
            };

            db.Products.Add(p);
            db.SaveChanges();
            ShowProducts(dgEX5);
        }


        private void ShowProducts(DataGrid grid)
        {
            var query = from p in db.Products
                        where p.Category.CategoryName.Equals("Beverages")
                        orderby p.ProductID descending
                        select new
                        {
                            p.ProductID,
                            p.ProductName,
                            p.CategoryID,
                            p.Category.CategoryName,
                            p.UnitPrice
                        };
            grid.ItemsSource = query.ToList();
        }

        private void btn_ClickEX6(object sender, RoutedEventArgs e)
        {
            //Product product = (from p in db.Products
            //                   where p.ProductName.StartsWith("Kick")
            //                   select p).First();
            Product product = null;
            try
            {
                product = db.Products.
                    Where(p => p.ProductName.StartsWith("Kick")).
                    Select(p => p).First();
                product.UnitPrice = 100m;
                db.SaveChanges();


            }
            catch (InvalidOperationException ex) { }
            //crashed when empty - need to handle
            ShowProducts(dgEX6);
        }

        private void btn_ClickEX7(object sender, RoutedEventArgs e)
        {
            var query = from p in db.Products
                        where p.ProductName.StartsWith("Kick")
                        select p;

            foreach (var item in query)
            {
                item.UnitPrice = 120m;
            }
            db.SaveChanges();
            ShowProducts(dgEX7);
        }

        private void btn_ClickEX8(object sender, RoutedEventArgs e)
        {
            var products = from p in db.Products
                           where p.ProductName.StartsWith("Kick")
                           select p;

            db.Products.RemoveRange(products);
            db.SaveChanges();
            ShowProducts(dgEX8);
        }

        private void btn_ClickEX9(object sender, RoutedEventArgs e)
        {
            var query = db.Customers_By_City("London");
            dgEX9.ItemsSource = query.ToList();
        }
    }
}
