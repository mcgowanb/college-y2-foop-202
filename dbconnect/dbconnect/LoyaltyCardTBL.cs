//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace dbconnect
{
    using System;
    using System.Collections.Generic;
    
    public partial class LoyaltyCardTBL
    {
        public int LoyaltyCardID { get; set; }
        public Nullable<int> CustomerID { get; set; }
        public Nullable<short> Points { get; set; }
    
        public virtual CustomerTBL CustomerTBL { get; set; }
    }
}