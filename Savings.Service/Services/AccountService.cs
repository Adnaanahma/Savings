using Arch.EntityFrameworkCore.UnitOfWork;
using Savings.Model.Entity;
using Savings.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Savings.Service.Services
{
    public  class AccountService : IAccountService
    {
        private readonly List<Account> _account;
        private static readonly Random _random = new Random();
        public AccountService()
        {
            _account = new List<Account>();
            
        }
        private readonly IUnitOfWork _unitOfWork;

        public AccountService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
      



        public async Task<Account> OpenNewAccount(long openingBalance)
        {
            var account = new Account
            {
                Id = Guid.NewGuid(),
                OpeningBalance = openingBalance,
                AvailableBalance = openingBalance,
                LedgerBalance = openingBalance,
                ClosingBalance = 0 // Initial closing balance
            };
            _unitOfWork.GetRepository<Account>().Insert(account);
            await _unitOfWork.SaveChangesAsync();
            return account;
        }
        public async  Task<string> GenerateAccountNumber()
        {
            var AccountNumber = _random.Next(1000000000, int.MaxValue).ToString("D10");
            await _unitOfWork.SaveChangesAsync();
            return AccountNumber;
        }

        public async Task<bool> GetAccount(Guid id)
        {
            var account = _unitOfWork.GetRepository<Account>().GetFirstOrDefaultAsync(x => x.Id == id, null, null, false);
            if (account != null)
            {
                _unitOfWork.GetRepository<Account>().Find(account);
                await _unitOfWork.SaveChangesAsync();
            }
            return false;
        }

        public void UpdateBalances(int id, long amount)
        {
            var account = _account[id];
            account.AvailableBalance += amount;
            account.LedgerBalance += amount;
        }

        public void CloseAccount(int id)
        {
            var account = _account[id];
            account.ClosingBalance = account.AvailableBalance;
        }

        public async Task<string> GetAccountDetails(int id)
        {
            var account = _account[id];
            await _unitOfWork.SaveChangesAsync();
            return $"Account Number: {account.AccountNumber}, Opening Balance: {account.OpeningBalance}, Available Balance: {account.AvailableBalance}, Ledger Balance: {account.LedgerBalance}, Closing Balance: {account.ClosingBalance}";
        }

        public async Task<bool> PnDEnabled(string AccountNumber)
        {
            var response = await _unitOfWork.GetRepository<Account>().GetFirstOrDefaultAsync(x => x.AccountNumber == AccountNumber, null, null, false);
            if (response != null)
            {
                response.IsEnabled = true;
                _unitOfWork.GetRepository<Account>().Update(response);
                await _unitOfWork.SaveChangesAsync();
            }
            throw new Exception("null");
        }

        public async Task<bool> PnCEnabled(string AccountNumber)
        {
            var response = await _unitOfWork.GetRepository<Account>().GetFirstOrDefaultAsync(x => x.AccountNumber == AccountNumber, null, null, false);
            if (response != null)
            {
                response.IsEnabled = true;
                _unitOfWork.GetRepository<Account>().Update(response);
                await _unitOfWork.SaveChangesAsync();
            }
            throw new Exception("null");
        }

        public async Task<bool> LienEnabled(string AccountNumber)
        {
            var response = await _unitOfWork.GetRepository<Account>().GetFirstOrDefaultAsync(x => x.AccountNumber == AccountNumber, null, null, false);
            if (response != null)
            {
                response.IsEnabled = true;
                _unitOfWork.GetRepository<Account>().Update(response);
                await _unitOfWork.SaveChangesAsync();
            }
            throw new Exception("null");
        }


    }




    
}

