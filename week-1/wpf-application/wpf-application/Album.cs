using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpf_application
{
    public class Album
    {
        public String Name { get; set; }
        public int Released { get; set; }
        public int Sales { get; set; }
        static Random randomFactory = new Random();
        public Album()
        {
            //randomFactory = new Random();
        }

        public Album(String name) : this()
        {
            Name = name;
            Released = generateRandomNumber(1977, 2016);
            Sales = generateRandomNumber(1, 20);
        }

        private int generateRandomNumber(int v1, int v2)
        {
            return randomFactory.Next(v1, v2);
        }

        public override string ToString()
        {
            return String.Format("{0} Released: {1} - Sales ${2}m", Name, Released, Sales);
        }

    }
}
