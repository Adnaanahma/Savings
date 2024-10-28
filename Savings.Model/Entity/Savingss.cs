using Savings.Model.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Savings.Model.Entity
{
    public class Savingss:BaseEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public Description Description { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public Decimal GoalAmount { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public Decimal CurrentBalance { get; set; }
        public DateTime? TargetDate { get; set; }
    }
}
