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
    
    public partial class Invoicedetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Invoicedetail()
        {
            this.Invoicedetailsending = new HashSet<Invoicedetailsending>();
        }
    
        public int Invoicedetailid { get; set; }
        public int Invoiceid { get; set; }
        public string DT_Invoicedetailtypeid { get; set; }
        public string PR_Productid { get; set; }
        public string TP_Producttypeid { get; set; }
        public Nullable<int> Orderid { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<bool> Variableprice { get; set; }
        public Nullable<System.DateTime> Startdate { get; set; }
        public Nullable<System.DateTime> Renewdate { get; set; }
        public Nullable<System.DateTime> Enddate { get; set; }
        public Nullable<decimal> Discount { get; set; }
        public Nullable<int> Quantity { get; set; }
        public string Extracostdescription { get; set; }
        public string TE_Sendingtypeid { get; set; }
    
        public virtual Codespec Codespec { get; set; }
        public virtual Codespec Codespec1 { get; set; }
        public virtual Codespec Codespec2 { get; set; }
        public virtual Codespec Codespec3 { get; set; }
        public virtual Invoice Invoice { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Invoicedetailsending> Invoicedetailsending { get; set; }
    }
}
