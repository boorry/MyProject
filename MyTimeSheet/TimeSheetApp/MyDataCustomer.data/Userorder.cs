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
    
    public partial class Userorder
    {
        public int Userorderid { get; set; }
        public string Username { get; set; }
        public Nullable<int> Orderid { get; set; }
    
        public virtual Order Order { get; set; }
    }
}
