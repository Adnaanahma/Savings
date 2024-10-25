using System;
using System.Collections.Generic;
using System.Text;

namespace Savings.Model.ViewModel
{
    public  class BaseResponse
    {
        public string Message { get; set; }
        public bool Status { get; set; }
        public bool IsActive { get; set; }
    }
}
