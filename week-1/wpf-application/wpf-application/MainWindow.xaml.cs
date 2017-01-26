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
using wpf_application;

namespace wpf_application
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Band> bands;
        private List<Band> filteredBands;
        String[] genres;
        public MainWindow()
        {
            InitializeComponent();
        }


        #region methods
        private void lbxBands_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox lbx = sender as ListBox;
            Band selected = lbx.SelectedItem as Band;
            if (selected != null)
                UpdateBandInfomration(selected);

        }

        private void UpdateBandInfomration(Band band)
        {
            txtblkBandInformation.Text = band.Members;
            lblYearFormed.Content = band.YearFormed;
            txtblkBandInformation.Text = band.PrintAlbums();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            bands = LoadBands();
            filteredBands = new List<Band>();
            bands.Sort();
            lbxBands.ItemsSource = bands;
            genres = new String[] { "All", "Rock", "Pop", "Indie" };
            cbxGenre.ItemsSource = genres;
            cbxGenre.SelectedIndex = 0;

        }

        private List<Band> LoadBands()
        {
            bands = new List<Band>();

            Band b1 = new RockBand("Guns 'N' Roses", "Axel Rose, Slash, Dizzy Reed, Duff McKagan", 1985);
            bands.Add(b1);

            Band b2 = new RockBand("The Eagles", "Glen Frey, Don Henley, Timothy B Schmidt, Don Feder", 1971);
            bands.Add(b2);

            Band b3 = new PopBand("Red Hot Chili Peppers", "Anthony Keidis, Flea, Chad Smith, Josh Klinghoffer", 1994);
            bands.Add(b3);

            Band b4 = new PopBand("Pearl Jam", "Eddy Vedder, Mike McCready, Stone Gossart, Matt Cameron", 1990);
            bands.Add(b4);

            Band b5 = new IndieBand("Nirvana", "Kurt Cobain, Krist Novaselic, Dave Grohl", 1992);
            bands.Add(b5);

            Band b6 = new IndieBand("Foo Fighters", "Dave Grohl, Pat Smear, Nate Mendel, Chris Shiflet", 1994);
            bands.Add(b6);

            return bands;
        }

        private void cbxGenre_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            String genre = cbxGenre.SelectedItem as String;
            if (genre != null)
                FilterList(genre);
        }

        private void FilterList(String genre)
        {
            filteredBands.Clear();
            lbxBands.ItemsSource = null;
            if (genre == "All")
            {
                lbxBands.ItemsSource = bands;
            }
            else
            {
                foreach (var item in bands)
                {
                    if (item.Genre == genre)
                        filteredBands.Add(item);
                }
                lbxBands.ItemsSource = filteredBands;
            }
        }

        private void btnWriteToFile_Click(object sender, RoutedEventArgs e)
        {
            WriteToFile();
        }

        private void WriteToFile()
        {
            String[] lines = new String[bands.Count];
            for (int i = 0; i < lines.Length; i++)
            {
                lines[i] = bands[i].GetPrintableBand();
            }

            File.WriteAllLines("bands.txt", lines);
        }
        #endregion methods

    }
}
