using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace q5
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 1, 5, 3, 6, 10, 12, 8 };

            var query1 = numbers.OrderByDescending(n => n);

            var query2 = query1.Where(n => n < 8);

            var query3 = query2.Select(n => DoubleIt(n));

            foreach (var item in query3)
            {
                Console.WriteLine(item);
            }

            var smaller = numbers
                .Where(n => n < 8)
                .OrderByDescending(n => n)
                .Select(n => DoubleIt(n));
            Console.WriteLine("\n\n\n");
            foreach (var item in smaller)
            {
                Console.WriteLine(item);
            }

        }

        private static int DoubleIt(int value)
        {
            Console.WriteLine("Doubling the number " + value);
            return value * 2;
        }
    }
}
