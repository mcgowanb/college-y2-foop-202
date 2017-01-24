using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpf_application
{
    public abstract class Band : IComparable
    {
        public String Name { get; set; }
        public List<Album> albums { get; set; }


        public String Genre { get
            {
                return this.genre;
            }
        }
        protected String genre;
        public int YearFormed { get; set; }
        public String Members { get; set; }

        #region constructors
        public Band(){}

        public Band(String name)
        {
            Name = name;
        }

        public Band(String name, String members, int year)
        {
            Name = name;
            Members = members;
            YearFormed = year;
        }
        #endregion constructors

        #region methods

        public int CompareTo(object obj)
        {
            Band b = obj as Band;
            return Name.CompareTo(b.Name);
        }

        public override string ToString()
        {
            return String.Format("{0} - {1}", Name, Genre);
        }

        protected List<Album> AddAlbums()
        {
            albums = new List<Album>();
            Album a1 = new Album("fsdf");
            albums.Add(a1);

            Album a2 = new Album("fsdsdff");
            albums.Add(a2);

            Album a3 = new Album("faaassdf");
            albums.Add(a3);

            Album a4 = new Album("wedfd");
            albums.Add(a4);
            return albums;
        }

        public String PrintAlbums()
        {
            String msg = "";
            foreach (var album in albums)
            {
                msg += album + "\n";
            }
            return msg;
        }

        public String GetPrintableBand()
        {
            String line = this.ToString() + " : ";
            foreach (var item in albums)
            {
                line += "Albums: " + item + " : ";
            }
            return line;
        }
        #endregion

    }
}
