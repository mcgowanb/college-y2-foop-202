namespace AWExample
{
    using System;
    using System.Collections.Generic;

    public partial class SalesOrderHeader
    {
        public override string ToString()
        {
            return string.Format("{0} : {1} {2:C}", OrderDate.ToShortDateString(), SalesOrderID, TotalDue);
        }
    }
}
