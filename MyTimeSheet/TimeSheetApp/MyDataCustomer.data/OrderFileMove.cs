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
    
    public partial class OrderFileMove
    {
        public int OrderFileMoveID { get; set; }
        public Nullable<int> Orderid { get; set; }
        public string DirIn { get; set; }
        public string DirOut { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreationDate { get; set; }
        public string ModBy { get; set; }
        public Nullable<System.DateTime> ModDate { get; set; }
        public bool Active { get; set; }
    
        public virtual Order Order { get; set; }
    }
}
