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
    
    public partial class Owner
    {
        public string PA_Ownerid { get; set; }
        public string Ownernumber { get; set; }
    
        public virtual Codespec Codespec { get; set; }
    }
}
