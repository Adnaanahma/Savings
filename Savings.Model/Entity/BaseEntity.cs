using System;
using System.Collections.Generic;
using System.Text;

namespace Savings.Model.Entity
{
    public  class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
