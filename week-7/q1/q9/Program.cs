using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace q9
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer c1 = new Customer() { Name = "Brian", City = "Sligo" };
            Customer c2 = new Customer() { Name = "Mike", City = "Galway" };
            Customer c3 = new Customer() { Name = "Shane", City = "Sligo" };
            Customer c4 = new Customer() { Name = "Majella", City = "Limerick" };

            List<Customer> customers = new List<Customer>();
            customers.Add(c1);
            customers.Add(c2);
            customers.Add(c3);
            customers.Add(c4);

            var results = customers
                .Where(c => c.City == "Sligo" || c.City == "Galway");

            var resuts2 = from c in customers
                          where (c.City == "Sligo" || c.City == "Limerick")
                          select c;


            foreach (var item in results)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("\n\n");
            foreach (var item in resuts2)
            {
                Console.WriteLine(item);
            }

        }
    }

    class Customer
    {
        public String Name { get; set; }
        public String  City { get; set; }

        public override string ToString()
        {
            return String.Format("{0} from {1}", Name, City);
        }

    }
}
