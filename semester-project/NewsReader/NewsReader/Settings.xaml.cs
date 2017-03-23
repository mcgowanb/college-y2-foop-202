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
using System.Windows.Shapes;

namespace NewsReader
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        public Settings()
        {
            InitializeComponent();
            Window parent = Window.GetWindow(this);
            parent.Topmost = true;
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.UserID = txtUserID.Text;
            Properties.Settings.Default.AccessSecret = txtAccessSecret.Text;
            Properties.Settings.Default.AccessToken = txtAccessToken.Text;
            Properties.Settings.Default.ConsumerKey = txtConsumerKey.Text;
            Properties.Settings.Default.ConsumerSecret = txtConsumerSecret.Text;
            Properties.Settings.Default.TheJournalXmlUri = txtJournal.Text;
            Properties.Settings.Default.DailyEdgeXmlUri = txtDailyEdge.Text;
            Properties.Settings.Default.ForaXmlUri = txtFora.Text;
            Properties.Settings.Default.The42XmlUri = txtThe42.Text;
            Properties.Settings.Default.Save();
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtUserID.Text = Properties.Settings.Default.UserID;
            txtAccessSecret.Text = Properties.Settings.Default.AccessSecret;
            txtAccessToken.Text = Properties.Settings.Default.AccessToken;
            txtConsumerKey.Text = Properties.Settings.Default.ConsumerKey;
            txtConsumerSecret.Text = Properties.Settings.Default.ConsumerSecret;
            txtJournal.Text = Properties.Settings.Default.TheJournalXmlUri;
            txtDailyEdge.Text = Properties.Settings.Default.DailyEdgeXmlUri;
            txtFora.Text = Properties.Settings.Default.ForaXmlUri;
            txtThe42.Text = Properties.Settings.Default.The42XmlUri;
        }

        private void OnCloseCmdExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
            Random rf = new Random();

        }
    }
}
