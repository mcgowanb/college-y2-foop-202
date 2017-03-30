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
        NORTHWNDEntities1 db;
        public MainWindow()
        {
            db = new NORTHWNDEntities1();
            InitializeComponent();
        }

        private void btn_ClickEX1(object sender, RoutedEventArgs e)
        {
            var query = from c in db.Categories
                        join p in db.Products on c.CategoryName equals p.Category.CategoryName
                        orderby c.CategoryName
                        select new
                        {
                            Category = c.CategoryName,
                            Product = p.ProductName
                        };

            var query2 = from p in db.Products
                         orderby p.Category.CategoryName
                         select new
                         {
                             Category = p.Category.CategoryName,
                             Product = p.ProductName
                         };
            dgEX1.ItemsSource = query.ToList();

            lblEX1.Content = query.Count();
        }

        private void btn_ClickEX2(object sender, RoutedEventArgs e)
        {
            var query = from p in db.Products
                        orderby p.Category.CategoryName, p.ProductName
                        select new
                        {
                            Category = p.Category.CategoryName,
                            Product = p.ProductName
                        };

            var results = query.ToList();
            dgEX2.ItemsSource = results;
            lblEX2.Content = results.Count().ToString();
        }

        private void btn_ClickEX3(object sender, RoutedEventArgs e)
        {
            var query1 = from detail in db.Order_Details
                         where detail.ProductID == 7
                         select detail;

            var query2 = from detail in db.Order_Details
                         where detail.ProductID == 7
                         select detail.UnitPrice * detail.Quantity;

            int numOrders = query1.Count();
            decimal cost = query2.Sum();
            decimal avg = query2.Average();

            lblEX3.Content = String.Format("Total number of orders {0}\nTotal Value of orders {1:C}\nAverage cost of order {2:C}",
                numOrders,
                cost,
                avg);
        }

        private void btn_ClickEX4(object sender, RoutedEventArgs e)
        {
            var query = from c in db.Customers
                        where c.Orders.Count >= 20
                        select new
                        {
                            Name = c.CompanyName,
                            Orders = c.Orders.Count
                        };

            dgEX4.ItemsSource = query.ToList();
        }

        private void btn_ClickEX5(object sender, RoutedEventArgs e)
        {
            var query = from c in db.Customers
                        where c.Orders.Count < 3
                        orderby c.Orders.Count descending
                        select new
                        {
                            Name = c.CompanyName,
                            City = c.City,
                            Region = c.Region,
                            Orders = c.Orders.Count
                        };
            dgEX5.ItemsSource = query.ToList();
        }

        private void btn_ClickEX6(object sender, RoutedEventArgs e)
        {
            var query = from c in db.Customers
                        orderby c.CompanyName
                        select c.CompanyName;

            lbxEX6.ItemsSource = query.ToList();
        }

        private void lbxEX6_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            String companyName = lbxEX6.SelectedItem as String;

            var query = from o in db.Order_Details
                        where o.Order.Customer.CompanyName == companyName
                        select o.UnitPrice * o.Quantity;

            var total = query.Sum();

            lblEX6.Content = String.Format("Orders total for {0} is\n{1:C}", companyName, total);
        }

        private void btn_ClickEX7(object sender, RoutedEventArgs e)
        {
            var query = from p in db.Products
                        group p by p.Category.CategoryName into g
                        orderby g.Count() descending
                        select new
                        {
                            Category = g.Key,
                            Total = g.Count()
                        };

            dgEX7.ItemsSource = query.ToList();
        }

        private void btn_ClickEX8(object sender, RoutedEventArgs e)
        {
            var query = from c in db.Products
                        select c.Category.CategoryName;

            lbxEX8.ItemsSource = query.Distinct().ToList();
            lblEx8ProductTotal.Content = String.Format("Number of categories is {0}", query.Distinct().Count());
        }
    }
}
