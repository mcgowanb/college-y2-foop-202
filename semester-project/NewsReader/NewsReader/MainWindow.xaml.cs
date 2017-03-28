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

namespace NewsReader
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private News news;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            news = new News();
            lbxArticles.ItemsSource = news.CurrentNewsArticles;
        }
        private void MenuItemSettings_Click(object sender, RoutedEventArgs e)
        {
            Settings settings = new Settings();
            settings.ShowDialog();
        }
        private void CloseApp()
        {
            Application.Current.Shutdown();
        }

        private void MenuItemClose_Click(object sender, RoutedEventArgs e)
        {
            CloseApp();
        }

        private void OnCloseCmdExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            CloseApp();
        }
        private void WebSiteButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            String selected = rb.Content.ToString();
            lbxArticles.ItemsSource = news.FilterArticlesByName(selected);
        }
        private void lbxTweets_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void lbxTweets_MouseClick(object sender, MouseButtonEventArgs e)
        {

        }
        private void btnLoadTweets_Click(object sender, RoutedEventArgs e)
        {

        }
        private void lbxNewsArticles_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
        private void cbxWebSites_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void RefreshArticles_Click(object sender, RoutedEventArgs e)
        {
            news.RefreshArticles();
            lbxArticles.ItemsSource = null;
            lbxArticles.ItemsSource = news.CurrentNewsArticles;
        }

        private void lbxArticles_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Article a = lbxArticles.SelectedItem as Article;
            wbDisplay.Source = new Uri(a.GUID);
        }
    }
}
