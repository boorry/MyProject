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
    
    public partial class Productionflyers
    {
        public int Productionflyersid { get; set; }
        public Nullable<System.DateTime> Publicationdate { get; set; }
        public Nullable<System.DateTime> Productiondate { get; set; }
        public Nullable<int> Orderid { get; set; }
        public string PR_Productid { get; set; }
        public Nullable<int> Publicationid { get; set; }
        public string Articletitle { get; set; }
        public string Articlepagenumber { get; set; }
        public string Resume { get; set; }
        public string Filename { get; set; }
        public string Picturename { get; set; }
        public string TP_Producttypeid { get; set; }
        public string Articleno { get; set; }
        public string Author { get; set; }
        public Nullable<long> ContactID { get; set; }
        public Nullable<decimal> AVE { get; set; }
        public string ArticleLanguage { get; set; }
    
        public virtual Codespec Codespec { get; set; }
        public virtual Codespec Codespec1 { get; set; }
        public virtual Order Order { get; set; }
        public virtual Publication Publication { get; set; }
    }
}
