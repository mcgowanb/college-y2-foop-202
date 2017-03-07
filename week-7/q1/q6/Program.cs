using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace q6
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = { "Mary", "Joseph", "Michael", "Sarah", "Margaret", "John" };

            //var result = names
            //    .OrderBy(n => n)
            //    .Where(n => n.StartsWith("M"));

            //var result = names
            //    .Select(n => n);

            var result = from n in names
                         where n.StartsWith("M")
                         select n;


            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }
    }
}
