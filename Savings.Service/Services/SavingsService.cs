using Arch.EntityFrameworkCore.UnitOfWork;
using Savings.Model.Entity;
using Savings.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Savings.Service.Services
{
    public  class SavingsService: ISavingsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly List<Savingss> _savingss;
        public SavingsService(IUnitOfWork unitOfWork)
        {
            _savingss = new List<Savingss>();
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// "Add savings"
        /// </summary>
        /// <param name="savingss"></param>
        public async void AddSavingsAsync(Savingss savingss)
        {
            _savingss.Add(savingss);
            await _unitOfWork.SaveChangesAsync();
        } 

        /// <summary>
        /// "Get All Savings"
        /// </summary>
        /// <returns></returns>
       public async Task<List<Savingss>> GetAllSavingsAsync()
       { 
            return _savingss; 
            await _unitOfWork.SaveChangesAsync();
       }

        /// <summary>
        /// "Update Balance"
        /// </summary>
        /// <param name="name"></param>
        /// <param name="newBalance"></param>
        public async void UpdateBalance(string name, decimal newBalance) 
        { 
            var response =  _unitOfWork.GetRepository<Savingss>().GetFirstOrDefault(x => x.Name == name, null , null, false);
            if (response != null)
            {
                response.CurrentBalance = newBalance;
                await _unitOfWork.SaveChangesAsync();
            }
            
        }

        /// <summary>
        /// "Calculate with Interest"
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<decimal> CalculateTotalWithInterestAsync(string name)
        { 
           return await Task.Run(() =>
           {
               var response = _savingss.Find(x => x.Name == name);
               if (response != null)
               {
                   var days = response.TargetDate.Value - response.StartDate;
                   var years = days.TotalDays/ 365 ; 
                   var totalWithInterest = response.CurrentBalance * (decimal)Math.Pow(1 + response.InterestRate / 100, years);
                   return totalWithInterest; 
               } 
               return 0; 
           }); 
        }

    }
}
