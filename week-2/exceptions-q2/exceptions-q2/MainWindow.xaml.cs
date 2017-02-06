using System;
using System.Collections.Generic;
using System.IO;
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

namespace exceptions_q2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnLoadData_Click(object sender, RoutedEventArgs e)
        {
            ReadFileData();
        }

        private void ReadFileData()
        {
            try
            {
                String currentDir = Directory.GetCurrentDirectory();
                DirectoryInfo parent = Directory.GetParent(currentDir);
                DirectoryInfo gParent = Directory.GetParent(parent.FullName);    
                String[] names = File.ReadAllLines(gParent + "\\names.txt");
                lbxFileData.ItemsSource = names;
            }

            catch  (FileNotFoundException e)
            {
                MessageBox.Show(String.Format("Message: {0}\n\nSource: {1}\n\nStackTrace: {2}", e.Message, e.Source, e.ToString()));
            }
            
        }
    }
}
