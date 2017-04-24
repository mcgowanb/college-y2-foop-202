
namespace CA_2
{
    using System;
    using System.Collections.Generic;

    public partial class Car
    {

        public override string ToString()
        {
            return String.Format("{0} {1}", Make.Trim(), Model.Trim());
        }
    }
}
