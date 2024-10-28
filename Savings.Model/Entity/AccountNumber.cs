using System;
using System.Collections.Generic;
using System.Text;

namespace Savings.Model.Entity
{
    public  class AccountNumber:BaseEntity
    {
        public Guid UserId { get; set; }
        public string Number { get; set; }
        public DateTime? GeneratedAt { get; set; }
    }
}
