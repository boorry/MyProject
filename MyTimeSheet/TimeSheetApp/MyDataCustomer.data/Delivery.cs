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
    
    public partial class Delivery
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Delivery()
        {
            this.Articles = new HashSet<Articles>();
            this.Deliverysubject = new HashSet<Deliverysubject>();
            this.Planning = new HashSet<Planning>();
        }
    
        public int Deliveryid { get; set; }
        public int Orderid { get; set; }
        public string Deliveryname { get; set; }
        public string SM_SendingMode { get; set; }
        public int SenderID { get; set; }
        public string SA_SendingAs { get; set; }
        public string AT_Attachment { get; set; }
        public string Email { get; set; }
        public string EmailTest { get; set; }
        public string EmailSubject { get; set; }
        public bool SentAsTest { get; set; }
        public string AttachmentName { get; set; }
        public bool PressReview { get; set; }
        public string PRName { get; set; }
        public string CV_CoverPage { get; set; }
        public bool PROrderBySubject { get; set; }
        public string PRDefaultSubjectName { get; set; }
        public string CL_Calendar { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Articles> Articles { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Deliverysubject> Deliverysubject { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Planning> Planning { get; set; }
    }
}
