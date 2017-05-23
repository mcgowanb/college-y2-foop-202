using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace final_exam
{
    class PartTimeEmployee : Employee
    {
        public decimal HourlyRate { get; set; }
        public int HoursWorked { get; set; }

        #region ctor
        public PartTimeEmployee() { }

        public PartTimeEmployee(String fName, String lName) : base(fName, lName) { }

        public PartTimeEmployee(String fName, String lName, String PPS, decimal rate, int hrsWorked) : base(fName, lName, PPS)
        {
            HourlyRate = rate;
            HoursWorked = hrsWorked;
        }
        #endregion ctor

        //calculates monthly pay for part time employee
        public override decimal GetMonthlyPay()
        {
            return HourlyRate * HoursWorked;
        }

        public override string ToString()
        {
            return base.ToString() + " PT";
        }
    }
}
