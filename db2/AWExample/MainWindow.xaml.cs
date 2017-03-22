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

namespace AWExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AdventureLiteEntities db = new AdventureLiteEntities();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void lbxCustomers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string name = lbxCustomers.SelectedValue as string;

            if (name != null)
            {
                var query = from o in db.SalesOrderHeaders
                            where o.Customer.CompanyName.Equals(name)
                            select o;

                lbxOrders.ItemsSource = query.ToList();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var query = from c in db.SalesOrderHeaders
                        orderby c.Customer.CompanyName ascending
                        select new 
                        {
                           Name = c.Customer.CompanyName,
                           ID = c.CustomerID,
                           SalesOrderID = c.SalesOrderID
                        };

            lbxCustomers.ItemsSource = query.ToList().Distinct();

        }

        private void lbxOrders_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int id = Convert.ToInt32(lbxOrders.SelectedValue);

            if (id > 0)
            {
                var query = from od in db.SalesOrderDetails
                            where od.SalesOrderID == id
                            orderby od.UnitPrice
                            select new
                            {
                                od.Product.Name,
                                od.UnitPrice,
                                od.UnitPriceDiscount,
                                od.OrderQty,
                                od.LineTotal
                            };

                dgOrderDetails.ItemsSource = query.ToList();
            }
        }
    }
}
