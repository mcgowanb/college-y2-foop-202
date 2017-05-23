namespace q_2

{
    using System;
    using System.Collections.Generic;

    public partial class Product
    {
        public String DisplayPrice
        {
            get
            {
                return String.Format("{0:C2}", ListPrice);
            }
        }
        public override string ToString()
        {
            return String.Format("{0}", Name);
        }
    }
}
