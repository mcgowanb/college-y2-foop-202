/* database connection string
 * Server=tcp:college-db-server.database.windows.net,1433;Initial Catalog=news-reader;Persist Security Info=False;User ID={brian};Password={CollegeDb1};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
            news.FilterArticlesByName(selected);
            lbxArticles.ItemsSource = null;
            lbxArticles.ItemsSource = news.CurrentNewsArticles;
        }
        private void lbxTweets_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TweetSharp.TwitterStatus selected = lbxTweets.SelectedItem as TweetSharp.TwitterStatus;
            if (selected != null)
            {
                String s = String.Format("{0}{1}", Utility.BASELINE_URL, selected.IdStr);
                wbDisplay.Source = new Uri(s);
            }
        }
      
        private void btnLoadTweets_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Mouse.OverrideCursor = Cursors.Wait;
                news.LoadTwitterFeed();
                lbxTweets.ItemsSource = news.TwitterTimeline;
                Mouse.OverrideCursor = null;
            }
            catch (ArgumentNullException ex)
            {
                Mouse.OverrideCursor = null;
                MessageBox.Show("You have no Twitter API Details Set, please enter them first before continuing");
                Settings settings = new Settings();
                settings.Show();
                //details of object have been changed, so need to rebuild the factory
                news.RefreshTwitterFactory();
            }
            
        }
       

        private void RefreshArticles_Click(object sender, RoutedEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Wait;
            news.RefreshArticles();
            lbxArticles.ItemsSource = null;
            lbxArticles.ItemsSource = news.CurrentNewsArticles;
            Mouse.OverrideCursor = null;
        }

        private void lbxArticles_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Article a = lbxArticles.SelectedItem as Article;

            SupressScriptErrors();
            wbDisplay.Source = new Uri(a.GUID);
        }


        private void btnPublish_Click(object sender, RoutedEventArgs e)
        {
            Article a = lbxArticles.SelectedItem as Article;
            if(a == null)
            {
                MessageBox.Show("No Article Selected, Please select an article first");
            }
            else
            {
                MessageBox.Show(news.PublishTweet(a));
            }
        }

        /// <summary>
        /// Supress the irritating script erros from the web browser.
        /// </summary>
        private void SupressScriptErrors()
        {
            dynamic activeX = wbDisplay.GetType().InvokeMember("ActiveXInstance",
                    BindingFlags.GetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
                    null, wbDisplay, new object[] { });

            activeX.Silent = true;
        }
    }
}
