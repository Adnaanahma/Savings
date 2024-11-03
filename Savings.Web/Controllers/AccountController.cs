using Microsoft.AspNetCore.Mvc;
using Savings.Service.Interfaces;
using System;
using System.Threading.Tasks;

namespace Savings.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private readonly IAccountService AccountService;

        public AccountController(IAccountService accountService)
        {
            AccountService = accountService;
        }

        [HttpPost("OpenAccount")]
        public async Task<IActionResult> OpenNewAccount(long openingBalance)
        {
            var account = await AccountService.OpenNewAccount(openingBalance);
            return Ok(account);
        }

        [HttpPost("GenerateAccount")]
        public async Task<IActionResult> GenerateAccount()
        {
            var response = await AccountService.GenerateAccountNumber();
            return Ok(response);
        }

        [HttpGet("GetAccount")]
        public async Task<IActionResult>  GetAccount(Guid id)
        {
            var account =  await AccountService.GetAccount(id);
            return Ok(account);
        }

        [HttpPut("UpdateBalance")]
        public async Task<IActionResult> UpdateBalances(int id, long amount)
        {
            AccountService.UpdateBalances(id, amount);
            return Ok();
        }

        [HttpPut("CloseAccount")]
        public async Task<IActionResult> CloseAccount(int id)
        {
            AccountService.CloseAccount(id);
            return Ok();
        }

        [HttpGet("GetAccountDetails")]
        public async Task<IActionResult> GetAccountDetails(int id)
        {
            var details = await AccountService.GetAccountDetails(id);
            return Ok(details);
        }

        [HttpPatch("EnablePnD")]
        public async Task<IActionResult> PnDEnabled(string AccountNumber)
        {
            var response = await AccountService.PnDEnabled(AccountNumber);
            return Ok(response);
        }

        [HttpPatch("EnablePnC")]
        public async Task<IActionResult> PnCEnabled(string AccountNumber)
        {
            var response = await AccountService.PnCEnabled(AccountNumber);
            return Ok(response);
        }

        [HttpPatch("EnableLien")]
        public async Task<IActionResult> LienEnabled(string AccountNumber)
        {
            var response = await AccountService.LienEnabled(AccountNumber);
            return Ok(response);
        }


    }
}
