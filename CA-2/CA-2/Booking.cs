//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CA_2
{
    using System;
    using System.Collections.Generic;
    
    public partial class Booking
    {
        public int ID { get; set; }
        public Nullable<int> CarID { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
    
        public virtual Car Car { get; set; }
    }
}
