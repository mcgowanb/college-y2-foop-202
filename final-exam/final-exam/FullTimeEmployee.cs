using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace final_exam
{
    class FullTimeEmployee : Employee
    {
        public DateTime ReviewDate { get; set; }
        public decimal Salary { get; set; }

        #region ctor
        public FullTimeEmployee(){}

        public FullTimeEmployee(String fName, String lName): base(fName, lName){}

        public FullTimeEmployee(String fName, String lName, String PPS, DateTime reviewDate, decimal salary) : base(fName, lName, PPS)
        {
            ReviewDate = reviewDate;
            Salary = salary;
        }
        #endregion ctor

        //calculates montly pay for full time employees
        public override decimal GetMonthlyPay()
        {
            return Salary / 12;
        }

        public override string ToString()
        {
            return base.ToString() + " FT";
        }
    }
}
