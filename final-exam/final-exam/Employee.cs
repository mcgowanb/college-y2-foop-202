using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace final_exam
{
    abstract class Employee
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String PPS { get; set; }

        #region ctor
        public Employee(){}

        public Employee(String fName, String lName)
        {
            FirstName = fName;
            LastName = lName;
        }

        public Employee(String fName, String lName, String ppsn) : this(fName, lName)
        {
            PPS = ppsn;
        }

        public override string ToString()
        {
            return String.Format("{0} {1}", FirstName, LastName);
        }
        #endregion ctor

        //abstract method to be implementedd in sub classes
        public abstract decimal GetMonthlyPay();

        //returns string for display in the text box for payslip. uses the child implementation of
        // the montly pay method to calculate pay
        public String GetPaySlip()
        {
            return String.Format("{0} {1}\n{2}\nMonthly Pay: {3:C2}",FirstName, LastName, PPS, GetMonthlyPay());
        }
    }
}
