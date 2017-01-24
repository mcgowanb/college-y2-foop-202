using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpf_application
{
    public class IndieBand : Band
    {
        public IndieBand(String name, String members, int year) : base(name, members, year)
        {
            this.genre = "Indie";
            albums = AddAlbums();
        }
    }
}
