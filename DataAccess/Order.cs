//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order
    {
        public int OrderID { get; set; }
        public string Title { get; set; }
        public Nullable<System.DateTime> Time { get; set; }
    
        public virtual Customer Customer { get; set; }
        public virtual Empleyee Empleyee { get; set; }
        public virtual Product Product { get; set; }
        public virtual Sell Sell { get; set; }
    }
}
