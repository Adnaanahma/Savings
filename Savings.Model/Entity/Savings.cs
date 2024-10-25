using Savings.Model.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Savings.Model.Entity
{
    public class Savings:BaseEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public Description Description { get; set; }
        public Decimal GoalAmount { get; set; }
        public Decimal CurrentBalance { get; set; }
        public DateTime? TargetDate { get; set; }
    }
}
