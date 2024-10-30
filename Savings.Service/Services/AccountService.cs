using Arch.EntityFrameworkCore.UnitOfWork;
using Savings.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Savings.Service.Services
{
    public  class AccountService : IAccountService
    {
        private readonly Random _random;
        public AccountService()
        {
            _random = new Random();
        }

      
        public string AccountNumber()
        {
            char[] digits = new char[10];
            for (int i = 0; i < 10; i++)
            {
                digits[i] = (char)('0' + _random.Next(0, 10));
            }
            return new string(digits);
        }



    }
}
