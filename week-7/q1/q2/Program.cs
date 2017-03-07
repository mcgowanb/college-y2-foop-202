using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace q2
{
    class Program
    {
        static FileInfo[] files = new DirectoryInfo("C:\\Windows").GetFiles();
        static void Main(string[] args)
        {
            QuerySyntax();
            Console.WriteLine();
            Console.WriteLine();
            LambdaSyntax();
        }

        static void QuerySyntax()
        {
            var results = from file in files
                          where file.Length > 1000
                          orderby file.Length, file.Name
                          select new MyFileInfo
                          {
                              Name = file.Name,
                              Length = file.Length,
                              CreationDate = file.CreationTime
                          };
            PrintList(results.ToList());
        }

        static void LambdaSyntax()
        {
            var results = files
                .Where(f => f.Length > 1000)
                .OrderBy(f => f.Length).ThenBy(f => f.Name)
                .Select(f => new MyFileInfo
                {
                    Name = f.Name,
                    Length = f.Length,
                    CreationDate = f.CreationTime
                });
            PrintList(results.ToList());

        }


        public static void PrintList(List<MyFileInfo> list)
        {
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}

class MyFileInfo
{
    public String Name { get; set; }
    public long Length { get; set; }
    public DateTime CreationDate { get; set; }

    public override string ToString()
    {
        return String.Format("{0}\t{1}MB\t{2}", Name, Length / 1000, CreationDate);
    }
}
