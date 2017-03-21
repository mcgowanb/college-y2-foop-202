namespace db2
{
    using System;
    using System.Collections.Generic;

    public partial class Product {

        public override string ToString()
        {
            return String.Format("{0} | {1}", ProductName, UnitsInStock);
        }
    }
}
