using Savings.Model.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Savings.Model.Entity
{
    public class Savingss:BaseEntity
    {
        public Guid AccountId { get; set; }
        public Account Account { get; set; }
        public string Name { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public Decimal GoalAmount { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public Decimal CurrentBalance { get; set; }
        public DateTime? TargetDate { get; set; }
        public DateTime StartDate { get; set; }
        public SavingsFrequency Frequency { get; set; }
        public double InterestRate { get; set; }
    }
}
