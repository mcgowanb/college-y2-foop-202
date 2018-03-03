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

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        NORTHWNDEntities db;
        public MainWindow()
        {
            InitializeComponent();
            db = new NORTHWNDEntities();
        }

        private void btn_ClickEX1(object sender, RoutedEventArgs e)
        {
            var query = from c in db.Customers
                        group c by c.Country into g
                        orderby g.Count() descending
                        select new
                        {
                            Country = g.Key,
                            Total = g.Count()
                        };
            dgEX1.ItemsSource = query.ToList();
            lblEX1.Content = query.ToList().Count();
        }

        private void btn_ClickEX2(object sender, RoutedEventArgs e)
        {
            var query = from c in db.Customers
                        where c.Country.Equals("Italy")
                        select new
                        {
                            c.CompanyName,
                            c.Country,
                            c.City
                        };

            dgEX2.ItemsSource = query.ToList();
        }

        private void btn_ClickEX3(object sender, RoutedEventArgs e)
        {
            var query = from p in db.Products
                        where (p.UnitsInStock - p.UnitsOnOrder) > 0
                        select new
                        {
                            p.ProductName,
                            Available = p.UnitsInStock - p.UnitsOnOrder
                        };

            dgEX3.ItemsSource = query.ToList();
        }

        private void btn_ClickEX4(object sender, RoutedEventArgs e)
        {
            var query = from od in db.Order_Details
                        where od.Discount > 0
                        orderby od.Product.ProductName ascending, od.Discount descending
                        select new
                        {
                            od.Product.ProductName,
                            od.Discount,
                            od.Order.OrderID
                        };

            dgEX4.ItemsSource = query.ToList();
        }

        private void btn_ClickEX5(object sender, RoutedEventArgs e)
        {
            var query = (from o in db.Orders
                         select o.Freight).Sum();

            txtBlkEX5.Text = String.Format("The Total value for freight over all orders is: {0:C}", query);

        }

        private void btn_ClickEX6(object sender, RoutedEventArgs e)
        {
            var query = from p in db.Products
                        orderby p.Category.CategoryName ascending, p.UnitPrice descending
                        select new
                        {
                            p.Category.CategoryID,
                            p.Category.CategoryName,
                            p.ProductName,
                            p.UnitPrice
                        };
            dgEX6.ItemsSource = query.ToList();
        }

        private void btn_ClickEX7(object sender, RoutedEventArgs e)
        {
            var query = (from o in db.Orders
                        group o by o.CustomerID into c
                        orderby c.Count() descending
                        select new
                        {
                            Customer = c.Key,
                            Orders = c.Count()
                        }).Take(10);

            dgEX7.ItemsSource = query.ToList();
        }

        private void btn_ClickEX8(object sender, RoutedEventArgs e)
        { 
            var query = (from o in db.Orders
                         group o by o.CustomerID into c
                         join customer in db.Customers on c.Key equals customer.CustomerID
                         orderby c.Count() descending
                         select new
                         {
                             CustomerID = c.Key,
                             Orders = c.Count(),
                             Customer = customer.CompanyName
                         }).Take(10);

            dgEX8.ItemsSource = query.ToList();
        }

        private void btn_ClickEX9(object sender, RoutedEventArgs e)
        {
            var query = from c in db.Customers
                        where c.Orders.Count() == 0
                        select c;
            dgEX9.ItemsSource = query.ToList();
        }
    }
}
