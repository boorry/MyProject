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
    
    public partial class Ordersubscription
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ordersubscription()
        {
            this.Ordersending = new HashSet<Ordersending>();
        }
    
        public int Ordersubscriptionid { get; set; }
        public int Orderid { get; set; }
        public Nullable<decimal> Price { get; set; }
        public string PR_Productid { get; set; }
        public Nullable<System.DateTime> Startdate { get; set; }
        public Nullable<System.DateTime> Renewdate { get; set; }
        public Nullable<System.DateTime> Enddate { get; set; }
        public string TR_Tariffplanid { get; set; }
        public Nullable<bool> Subscriptioninvoiced { get; set; }
        public Nullable<System.DateTime> Nextinvoicedate { get; set; }
        public bool OverruleOrderschedule { get; set; }
        public bool Web { get; set; }
        public string AL_Accesslevel { get; set; }
        public Nullable<bool> Inclusive { get; set; }
    
        public virtual Codespec Codespec { get; set; }
        public virtual Codespec Codespec1 { get; set; }
        public virtual Order Order { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ordersending> Ordersending { get; set; }
    }
}