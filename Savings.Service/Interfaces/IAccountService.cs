using Savings.Model.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Savings.Service.Interfaces
{
    public interface IAccountService
    {
        Task<Account> OpenNewAccount(long openingBalance);
        Task<string> GenerateAccountNumber();
        Task<bool> GetAccount(Guid id);
        void UpdateBalances(int id, long amount);
        void CloseAccount(int id);
        Task<string> GetAccountDetails(int id);
        Task<bool> PnDEnabled(string AccountNumber);
        Task<bool> PnCEnabled(string AccountNumber);
        Task<bool> LienEnabled(string AccountNumber);



    }
}
