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
    
    public partial class ViewCustomers
    {
        public int Customerid { get; set; }
        public string Customername { get; set; }
        public string TC_Customertypeid { get; set; }
        public string CO_Accountmanagerid { get; set; }
        public string Userid { get; set; }
        public string VATnumber { get; set; }
        public string TV_VATcodeid { get; set; }
        public string CD_Paymenttypeid { get; set; }
        public Nullable<int> Numbersupplinvoice { get; set; }
        public string Confirmation { get; set; }
        public string Linkid { get; set; }
        public bool VAT { get; set; }
        public int Orderid { get; set; }
        public string Orderlist { get; set; }
        public string Ordername { get; set; }
        public bool Active { get; set; }
        public bool Export { get; set; }
        public System.DateTime Startdate { get; set; }
        public Nullable<System.DateTime> Enddate { get; set; }
        public string Ordertext { get; set; }
        public string Remark { get; set; }
        public bool Shippingblocked { get; set; }
        public Nullable<int> Discount { get; set; }
        public string OB_Invoicetextid { get; set; }
        public Nullable<int> Groupnumber { get; set; }
        public Nullable<int> Groupdeliverynumber { get; set; }
        public string PA_Ownerid { get; set; }
        public bool Internal { get; set; }
        public string Contactname { get; set; }
        public bool Email { get; set; }
        public bool Customernotification { get; set; }
    }
}
