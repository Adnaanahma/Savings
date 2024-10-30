using Savings.Model.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Savings.Model.Entity
{
    public  class Account :  BaseEntity
    {
        public Guid UserId { get; set; }
        public string AccountNumber { get; set; }
        public bool PnDEnabled { get; set; }
        public bool PnCEnabled { get; set; }
        public bool LienEnabled { get; set; }
        public AccountTier Tier { get; set; }
        public Currency Currency { get; set; }
        public long LedgerBalance { get; set; }
        public long AvailableBalance { get; set; }
        public long OpeningBalance { get; set; }
        public long ClosingBalance { get; set; }
    }
}
