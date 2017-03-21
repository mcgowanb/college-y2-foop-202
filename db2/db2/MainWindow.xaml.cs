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

namespace db2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        NORTHWNDEntities db;
        public MainWindow()
        {
            db = new NORTHWNDEntities();
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            lbxStockLevel.ItemsSource = Enum.GetNames(typeof(StockLevel));

            var suppliers = from s in db.Suppliers
                            orderby s.CompanyName
                            select new
                            {
                                s.SupplierID,
                                s.CompanyName,
                                s.Country
                            };

            var countries = from c in suppliers
                            select new
                            {
                                c.Country
                            };

            lbxSuppliers.ItemsSource = suppliers.ToList();
            lbxCountries.ItemsSource = countries.Distinct().ToList();
        }

        private void lbxStockLevel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            String s = lbxStockLevel.SelectedItem as String;
            switch (s)
            {
                case "Low":
                    var results = from p in db.Products
                                  orderby p.UnitsInStock
                                  where p.UnitsInStock < 50
                                  select p;
                    lbxProducts.ItemsSource = results.ToList();
                    break;
                case "Normal":
                    results = from p in db.Products
                              orderby p.UnitsInStock
                              where p.UnitsInStock >= 50 && p.UnitsInStock < 100
                              select p;
                    lbxProducts.ItemsSource = results.ToList();
                    break;
                case "OverStock":
                    results = from p in db.Products
                              orderby p.UnitsInStock
                              where p.UnitsInStock > 100
                              select p;
                    lbxProducts.ItemsSource = results.ToList();
                    break;
            }

        }

        private void lbxSuppliers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int id = Convert.ToInt32(lbxSuppliers.SelectedValue);
            var query = from p in db.Products
                        orderby p.ProductName
                        where p.SupplierID == id
                        select p;
            lbxProducts.ItemsSource = query.ToList();
        }

        private void lbxCountries_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            String s = lbxCountries.SelectedValue as String;
            var query = from p in db.Products
                        orderby p.ProductName
                        where p.Supplier.Country == s
                        select s;
        }
    }
}


public enum StockLevel { Low, Normal, OverStock }