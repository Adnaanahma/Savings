using Arch.EntityFrameworkCore.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Savings.Model.Entity;
using Savings.Service.Interfaces;
using System.Threading.Tasks;

namespace Savings.Web.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class SavingsController : Controller
    {
        private readonly ISavingsService SavingsService;
        private readonly IUnitOfWork _unitOfWork;

        public SavingsController(ISavingsService savingsService, IUnitOfWork unitOfWork)
        {
            SavingsService = savingsService;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// "Add Savings"
        /// </summary>
        /// <param name="savings"></param>
        /// <returns></returns>
        [HttpPost("AddSavings")]
        public async Task<IActionResult> AddSavings( Savingss savings) 
        { 
             SavingsService.AddSavingsAsync(savings);
            await _unitOfWork.SaveChangesAsync();
            return Ok("Savings goal added successfully.");
        }

        /// <summary>
        /// "Get All Savings"
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllSavings")]
        public async Task<IActionResult> GetAllSavings() 
        {
            var savings = await SavingsService.GetAllSavingsAsync();
            return Ok(savings); 
        }

        /// <summary>
        /// "Update Balance"
        /// </summary>
        /// <param name="name"></param>
        /// <param name="newBalance"></param>
        /// <returns></returns>
        [HttpPut("UpdateBalance")]
         public async Task<IActionResult> UpdateBalance( string name,  decimal newBalance) 
         { 
             SavingsService.UpdateBalance(name, newBalance);
            await _unitOfWork.SaveChangesAsync();
            return Ok("Balance updated successfully.");
         }

        /// <summary>
        /// "Calculate with Interest"
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet("CalculateWithInterest")] 
        public async Task<IActionResult> CalculateTotalWithInterest(string name)
        {
            var totalWithInterest = await SavingsService.CalculateTotalWithInterestAsync(name);
            return Ok(totalWithInterest);
        }
    }
}
