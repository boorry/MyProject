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
    
    public partial class KeywordCondition
    {
        public long KeywordConditionID { get; set; }
        public long KeywordLineID { get; set; }
        public string KC_ConditionTypeid { get; set; }
        public string KeywordConditionName { get; set; }
        public Nullable<int> NbOfWords { get; set; }
        public Nullable<int> ListOrder { get; set; }
    
        public virtual KeywordLine KeywordLine { get; set; }
    }
}
