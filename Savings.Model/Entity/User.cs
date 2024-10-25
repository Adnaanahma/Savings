using Savings.Model.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Savings.Model.Entity
{
    public  class User:BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public int DOB { get; set; }
        public Gender Gender { get; set; }
        public Country Country { get; set; }
        public Region Region { get; set; }
        public string AccountNumber { get; set; }
        public string Password { get; set; }
        public AccountType AccountType { get; set; }
        public bool IsActive { get; set; }

    }
}
