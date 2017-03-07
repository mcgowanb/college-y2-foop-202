using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    class Nurse : Employee
    {
        public String Grade { get; set; }
        public String Specialism { get; set; }

        public Nurse(): base(){}

        public Nurse(String name, String address, String phone, Decimal salary, String grade, String specialism) : base(name, address, phone, salary)
        {
            this.Grade = grade;
            this.Specialism = specialism;
        }

        public override string ToString()
        {
            return String.Format("{0}\nSpecialty: {1}\nSalary: {2}", base.ToString(), Specialism, salary);
        }
    }
}
