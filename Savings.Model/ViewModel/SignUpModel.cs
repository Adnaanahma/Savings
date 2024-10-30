using Savings.Model.Enum;
using System;

namespace Savings.Model.ViewModel
{
    public class SignUpModel
    {
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
