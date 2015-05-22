using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CreditCardManagementSystem.Models
{
    public class Register
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }
        public string Email { get; set; }
        public System.DateTime DateOfBirth { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string PhoneCell { get; set; }
        public string PhoneHome { get; set; }
        public string PhoneWork { get; set; }
        public bool isActive { get; set; }

        public Customer toCustomerObject()
        {
            Customer c = new Customer();
            c.CustomerName = CustomerName;
            c.CustomerSurname = CustomerSurname;
            c.Email = Email;
            c.DateOfBirth = DateOfBirth;
            c.Address1 = Address1;
            c.Address2 = Address2;
            c.PhoneCell = PhoneCell;
            c.PhoneHome = PhoneHome;
            c.PhoneWork = PhoneWork;
            c.isActive = true;

            return c;
        }
    }
}