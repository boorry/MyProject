//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyDataCustomer.data
{
    using System;
    using System.Collections.Generic;
    
    public partial class VOrders
    {
        public int Customerid { get; set; }
        public string Customername { get; set; }
        public int Orderid { get; set; }
        public string Ordername { get; set; }
        public string Products { get; set; }
        public System.DateTime Startdate { get; set; }
        public Nullable<System.DateTime> Enddate { get; set; }
        public string Ordertext { get; set; }
        public bool Active { get; set; }
    }
}