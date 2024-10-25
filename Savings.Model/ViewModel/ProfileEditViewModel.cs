using Savings.Model.Enum;
using System;

namespace Savings.Model.ViewModel
{
    public class ProfileEditViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public Country Country { get; set; }
        public Region Region { get; set; }
        public DateTime? UpdatdDate { get; set; }
        
    }
}
