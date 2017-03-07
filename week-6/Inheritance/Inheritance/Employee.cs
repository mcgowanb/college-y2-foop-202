using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    class Employee
    {
        public String Name { get; set; }
        public String Address { get; set; }
        public String PhoneNumber { get; set; }

        protected Decimal salary;

        public Employee(){}

        public Employee(String name, String address, String phone, Decimal salary)
        {
            this.Name = name;
            this.Address = address;
            this.PhoneNumber = phone;
            this.salary = salary;
        }

        public override string ToString()
        {
            return String.Format("Name: {0}\nAddress: {1}\nPhone:{2}", Name, Address, PhoneNumber);
        }
    }
}
