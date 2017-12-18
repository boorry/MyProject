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
    
    public partial class APVUser
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PasswordSalt { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public System.DateTime BeginDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public int LanguageID { get; set; }
        public Nullable<int> CustomerID { get; set; }
        public bool IsLockedOut { get; set; }
        public int FailedPasswordAttemptCount { get; set; }
        public Nullable<System.DateTime> LastLoginDate { get; set; }
        public Nullable<System.DateTime> LastPasswordChangedDate { get; set; }
        public Nullable<System.DateTime> LastLockedOutDate { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime ChangedOn { get; set; }
        public string ChangedBy { get; set; }
        public Nullable<bool> PasswordChangeRequired { get; set; }
        public Nullable<int> CurrentSelectedLanguageID { get; set; }
        public Nullable<System.DateTime> PreviousLoginDate { get; set; }
    }
}
