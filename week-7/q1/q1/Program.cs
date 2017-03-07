using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace q1
{
    class Program
    {
        static int[] numbers = { 1, 5, 6, 11, 12, 2, 15, 21, 13, 10, 12 };

        static void Main(string[] args)
        {
            QuerySyntax();
            Console.WriteLine();
            Console.WriteLine();
            LambdaSyntax();
        }

        static void QuerySyntax()
        {
            var ouputNumbers = from num in numbers
                               where num > 5
                               orderby num descending
                               select num;

            PrintNumbers(ouputNumbers.ToList());
        }

        static void LambdaSyntax()
        {
            var outputNumbers = numbers.Where(n => n > 5)
                .OrderByDescending(n => n);
            PrintNumbers(outputNumbers.ToList());
        }

        static void PrintNumbers(List<int> nums)
        {
            foreach (var n in nums)
            {
                Console.WriteLine(n);
            }
        }
    }
}
