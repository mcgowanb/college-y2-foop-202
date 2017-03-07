using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _q4
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 1, 5, 3, 6, 10, 12, 8 };

            var query = numbers
                .Select(n => DoubleIt(n));

            Console.WriteLine("Before the foreach");
            int i = 0;
            foreach (var item in query)
            {
                Console.WriteLine(++i);
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
