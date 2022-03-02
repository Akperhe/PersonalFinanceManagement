using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using PersonalFinanceManagement.Configurations;
using PersonalFinanceManagement.Data;
using PersonalFinanceManagement.Data.Dtos;
using PersonalFinanceManagement.Models;
using PersonalFinanceManagement.Services.Interfaces;

namespace PersonalFinanceManagement.Controllers
{
   
    [Route("accountSummary/")]
    [ApiController]
    public class AccountSummaryController : ControllerBase
    {
        private readonly IAccountSummaryServices _accountSummaryServices;
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;

        public AccountSummaryController(IAccountSummaryServices accountSummaryServices, AppDbContext appDbContext, IMapper mapper)
        {
            _accountSummaryServices = accountSummaryServices;
            _appDbContext = appDbContext;
            _mapper = mapper;
        }


        [HttpPost]
        public async Task<IActionResult> CreateAccount(CreateAccountSummaryDto req)
        {
            if (!ModelState.IsValid) return BadRequest("Required");
            var accountSumary = await _accountSummaryServices.CreateAccount(req);
            return Ok($"Account with name {accountSumary.FirstName} {accountSumary.LastName} created successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccount(String? id)
        {
            
            if (await _accountSummaryServices.GetAccount(id) == null) return NotFound("Account with that ID is not found");
            await _accountSummaryServices.DeleteAccount(id);
            return Ok("Successfully Deleted");
        }

        [HttpGet("all/")]
        public async Task<IActionResult> GetAllAccounts()
        {
           var accounts = await _accountSummaryServices.GetAllAccounts();
            return Ok(accounts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAccount(String? id)
        {
            var account = await _accountSummaryServices.GetAccount(id);
            if (account == null) return NotFound("Account with that ID is not found");  
            return Ok(account);
        }


        [HttpPatch("editAccountDetails/{id}")]
        public async Task<IActionResult> PartialUpdateAccount(string id, JsonPatchDocument<UpdateAccountSummaryDto> req)
        {
            if (await _accountSummaryServices.GetAccount(id) == null) return BadRequest("Account don't exist");
            var accountSummaryDto = await _accountSummaryServices.PartialUpdateAccount(id, req);
            return Ok(accountSummaryDto);

        }

        [HttpPatch("updateAccountName/{id}")]
        public async Task<IActionResult> UpdateAccountName(string id, string req)
        {
            if (await _accountSummaryServices.GetAccount(id) == null) return BadRequest("Account don't exist");
            var accountSummary = await _accountSummaryServices.UpdateAccountName(id,req);
            return Ok("Changes Effected");

        }


        [HttpGet("pagination/")]
        public async Task<IActionResult> GetPageListOfAccounts([FromQuery] RequestParamForPaging req)
        {
            var accountsPageList = await _accountSummaryServices.GetPageListOfAccounts(req);
            return Ok(accountsPageList);
        }

        [HttpPut("updateAccountDetails/")]
        public async Task<IActionResult> UpdateAccountDetails(string id, [FromBody] UpdateAccountSummaryDto req)
        {
            if (await _accountSummaryServices.GetAccount(id) == null) return BadRequest("Account don't exist");
            var accountSummaryDto = await _accountSummaryServices.UpdateAccountDetails(id, req);
            return Ok(accountSummaryDto);
        }
    }
}
