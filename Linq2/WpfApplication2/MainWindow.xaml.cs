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

namespace WpfApplication2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AdventureLiteEntities db;
        public MainWindow()
        {
            InitializeComponent();
            db = new AdventureLiteEntities();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var query = (from c in db.Products
                        orderby c.ProductCategory.Name
                        select c.ProductCategory.Name).Distinct();
            lbxCategories.ItemsSource = query.ToList();
            lblCategories.Content = String.Format("Number of Categories: {0}", query.Count());
        }

        private void lbcCategories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            String name = lbxCategories.SelectedItem as String;
            if (name != null)
            {
                var query = from p in db.Products
                            where p.ProductCategory.Name.Equals(name)
                            select p.Name;
                lbxProducts.ItemsSource = query.ToList();
                lblProducts.Content = String.Format("Number of products: {0}", query.Count());
            }
        }
    }
}
