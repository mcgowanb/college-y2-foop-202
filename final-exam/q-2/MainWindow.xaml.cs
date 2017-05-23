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

namespace q_2
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
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //init database connection
            db = new AdventureLiteEntities();
            LoadCategories();
        }


        //query products table and group by category name, add the counts and display
        private void LoadCategories()
        {
            var query = (from p in db.Products
                         group p by p.ProductCategory.Name into pc
                         orderby pc.Count() descending
                         select new CategorySummary
                         {
                             Name = pc.Key,
                             Total = pc.Count()
                         });

            lbxCategories.ItemsSource = query.ToList();
        }


        private void lbxCategories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CategorySummary cs = lbxCategories.SelectedItem as CategorySummary;
            if (cs != null)
            {
                LoadProductsByCategory(cs.Name);
            }
        }

        //get products listed by category
        private void LoadProductsByCategory(String catName)
        {
            var query = from p in db.Products
                        where p.ProductCategory.Name.Equals(catName)
                        select p;

            lbxProducts.ItemsSource = query.ToList();
        }

        //search button to match the querystring of the text box
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            String queryString = txtSearch.Text;
            if(queryString != null)
            {
                var query = from p in db.Products
                            where p.Name.Contains(queryString)
                            select p;
                lbxProducts.ItemsSource = query.ToList();
            } 
        }
    }
}
