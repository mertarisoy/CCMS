//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CreditCardManagementSystem.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class AccountBalanceInfo
    {
        public int AccountID { get; set; }
        public decimal Balance { get; set; }
    
        public virtual CustomerAccount CustomerAccount { get; set; }
    }
}