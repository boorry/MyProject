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
    
    public partial class Period
    {
        public int Periodid { get; set; }
        public int Calendarid { get; set; }
        public System.DateTime Date { get; set; }
    
        public virtual Calendar Calendar { get; set; }
    }
}
