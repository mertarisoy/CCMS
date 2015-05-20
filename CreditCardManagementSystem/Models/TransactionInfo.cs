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
    
    public partial class TransactionInfo
    {
        public int TransactionID { get; set; }
        public string CardNumber { get; set; }
        public Nullable<int> InstallmentID { get; set; }
        public string TransectionDescription { get; set; }
        public System.DateTime TransactionDate { get; set; }
        public decimal Amount { get; set; }
    
        public virtual CreditCard CreditCard { get; set; }
        public virtual Installment Installment { get; set; }
    }
}