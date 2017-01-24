using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpf_application
{
    public class RockBand : Band
    {


        public RockBand(String name, String members, int year) : base(name, members, year)
        {
            this.genre = "Rock";
            albums = AddAlbums();
        }

        //private List<Album> AddAlbums()
        //{
        //    albums = new List<Album>();
        //    Album a1 = new Album("fsdf");
        //    albums.Add(a1);

        //    Album a2 = new Album("fsdsdff");
        //    albums.Add(a2);

        //    Album a3 = new Album("faaassdf");
        //    albums.Add(a3);

        //    Album a4 = new Album("wedfd");
        //    albums.Add(a4);
        //    return albums;
        //}
    }
}
