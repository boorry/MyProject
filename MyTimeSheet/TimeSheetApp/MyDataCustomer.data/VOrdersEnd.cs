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
    
    public partial class VOrdersEnd
    {
        public int Customerid { get; set; }
        public string Customername { get; set; }
        public string Secteur { get; set; }
        public int Orderid { get; set; }
        public string Ordername { get; set; }
        public string OwnerType { get; set; }
        public string Commercial { get; set; }
        public string Produit { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<System.DateTime> Renewdate { get; set; }
        public Nullable<System.DateTime> Enddate { get; set; }
    }
}