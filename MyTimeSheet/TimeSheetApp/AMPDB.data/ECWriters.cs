//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AMPDB.data
{
    using System;
    using System.Collections.Generic;
    
    public partial class ECWriters
    {
        public long ECWritersID { get; set; }
        public string WriterName { get; set; }
        public string Path { get; set; }
        public int ListOrder { get; set; }
        public bool Active { get; set; }
        public Nullable<int> NbOfFiles { get; set; }
        public string ADName { get; set; }
    }
}
