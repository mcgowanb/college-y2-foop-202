using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace q3
{
    class Program
    {
        static FileInfo[] files = new DirectoryInfo("C:\\Windows").GetFiles();
        static void Main(string[] args)
        {
            QuerySynatax();
            Console.WriteLine();
            Console.WriteLine();
            LambdaSyntax();
        }

        public static void QuerySynatax()
        {
            var results = from f in files
                          where f.Length > 1000
                          orderby f.Length, f.Name
                          select new
                          {
                              Name = f.Name,
                              Length = f.Length,
                              CreationDate = f.CreationTime
                          };

            foreach (var item in results)
            {
                Console.WriteLine(item);
            }
        }


        static void LambdaSyntax()
        {
            var results = files
                .Where(f => f.Length > 1000)
                .OrderBy(f => f.Length).ThenBy(f => f.Name)
                .Select(f => new
                {
                    Name = f.Name,
                    Length = f.Length,
                    Created = f.CreationTime
                }
                );

            foreach (var item in results)
            {
                Console.WriteLine(item);
            }
        }
    }
}
