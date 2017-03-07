using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    class Doctor : Employee
    {
        public String Position { get; set; }
        public Doctor(): base(){}

        public Doctor(String name, String address, String phone, Decimal salary, String position) : base(name, address, phone, salary)
        {
            this.Position = position;
        }

        public override string ToString()
        {
            return String.Format("{0}\nPosition: {1}", base.ToString(), Position);
        }
    }
}
