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
    
    public partial class KeywordGroup
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KeywordGroup()
        {
            this.KeywordLine = new HashSet<KeywordLine>();
        }
    
        public long KeywordGroupID { get; set; }
        public string LA_Languageid { get; set; }
        public int Orderid { get; set; }
        public Nullable<int> ListOrder { get; set; }
        public string KT_Typeid { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KeywordLine> KeywordLine { get; set; }
    }
}
