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
    
    public partial class AP_Retours
    {
        public int Productionid { get; set; }
        public Nullable<int> Customerid { get; set; }
        public Nullable<int> Orderid { get; set; }
        public string PR_Productid { get; set; }
        public string TP_Producttypeid { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<int> Publicationid { get; set; }
        public Nullable<int> Numberofpages { get; set; }
        public string TE_Sendingtypeid { get; set; }
        public string Reader { get; set; }
        public Nullable<int> EncodingType { get; set; }
        public string Encoder { get; set; }
        public string Artno { get; set; }
        public Nullable<System.DateTime> EncodingDate { get; set; }
    }
}
