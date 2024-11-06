using Savings.Model.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Savings.Service.Interfaces
{
    public interface ISavingsService
    {
        void AddSavingsAsync(Savingss savingss);
         Task<List<Savingss>> GetAllSavingsAsync();
        void UpdateBalance(string name, decimal newBalance);
        Task<decimal> CalculateTotalWithInterestAsync(string name);

    }
}
