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
    
    public partial class Production
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Production()
        {
            this.Productionsending = new HashSet<Productionsending>();
        }
    
        public int Productionid { get; set; }
        public int Exchangeid { get; set; }
        public string Origin { get; set; }
        public System.DateTime Exchangedate { get; set; }
        public Nullable<int> Customerid { get; set; }
        public Nullable<int> Orderid { get; set; }
        public string PR_Productid { get; set; }
        public string TP_Producttypeid { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<System.DateTime> Cutdate { get; set; }
        public Nullable<System.DateTime> Scandate { get; set; }
        public string Usernamereader { get; set; }
        public string Usernamecutter { get; set; }
        public Nullable<System.DateTime> Publicationdate { get; set; }
        public Nullable<int> Publicationid { get; set; }
        public Nullable<int> Numberofpages { get; set; }
        public Nullable<int> Numberofsendings { get; set; }
        public string Delivery { get; set; }
        public Nullable<int> Invoiceid { get; set; }
        public bool Statementprinted { get; set; }
        public Nullable<bool> PubList { get; set; }
    
        public virtual Codespec Codespec { get; set; }
        public virtual Codespec Codespec1 { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Order Order { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Productionsending> Productionsending { get; set; }
        public virtual Publication Publication { get; set; }
    }
}
