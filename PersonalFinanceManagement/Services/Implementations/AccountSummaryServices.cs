using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using PersonalFinanceManagement.Data;
using PersonalFinanceManagement.Data.Dtos;
using PersonalFinanceManagement.Models;
using PersonalFinanceManagement.Repositories.Interfaces;
using PersonalFinanceManagement.Services.Interfaces;
using X.PagedList;

//using System.Web.Mvc.Controller;

namespace PersonalFinanceManagement.Services.Implementations
{
    public class AccountSummaryServices : IAccountSummaryServices
    {
        private readonly IMapper _mapper;
        private readonly IAccountSummaryRepo _accountSummaryRepo;

        public AccountSummaryServices(IMapper mapper, IAccountSummaryRepo accountSummaryRepo)
        {
            _mapper = mapper;
            _accountSummaryRepo  = accountSummaryRepo;
        }
        public async Task<AccountSummaryDto> CreateAccount(CreateAccountSummaryDto req)
        {
            var accountSummary = _mapper.Map<AccountSummary>(req);
            return _mapper.Map<AccountSummaryDto> (await _accountSummaryRepo.CreateAccount(accountSummary));
        }


        public async Task DeleteAccount(string? id)
        {
            await _accountSummaryRepo.DeleteAccount(id);
        }

        public async Task<List<AccountSummaryDto>> GetAllAccounts()
        {
            var accounts = await _accountSummaryRepo.GetAllAccounts();
            var results = _mapper.Map<List<AccountSummaryDto>>(accounts); //becareful of the type you are mapping exmaple a list.
            return results;
        }

     

        public async Task<bool> SaveChangesAsync() => await _accountSummaryRepo.SaveChangesAsync();

        public async Task<AccountSummaryDto> GetAccount(string id)
        {
           var accountSummary =  await _accountSummaryRepo.GetAccount(id);  // a service call the interface of the object tag A
            return _mapper.Map<AccountSummaryDto>(accountSummary);


        }


        public async Task<AccountSummaryDto> PartialUpdateAccount(string id, JsonPatchDocument<UpdateAccountSummaryDto> req)
        {
            var accountSummary = await _accountSummaryRepo.PartialUpdateAccount(id, req);
            return _mapper.Map<AccountSummaryDto>(accountSummary);
        }

        public async Task UpdateAccount(string id, AccountSummary req)
        {
            await _accountSummaryRepo.UpdateAccount(id, req);
        }

        public async Task<AccountSummaryDto> UpdateAccountName(string id,string req)
        {
           var accountSummary = await _accountSummaryRepo.UpdateAccountName(id, req);
           return _mapper.Map<AccountSummaryDto>(accountSummary);
        }

        public async Task<List<AccountSummaryDto>> GetPageListOfAccounts(RequestParamForPaging req)
        {
            var accountSummaries = await _accountSummaryRepo.GetPageListOfAccounts(req);
         var accountSummariesDto = _mapper.Map<List<AccountSummaryDto>>(accountSummaries);  //note if you try to make mape type IPageList instead of List you will get error in swagger result, this is wierd.
            return accountSummariesDto;
        }

        public async Task<AccountSummaryDto> UpdateAccountDetails(string id, UpdateAccountSummaryDto req)
        {
            var accountSummary = await _accountSummaryRepo.UpdateAccountDetails(id, req);
            return _mapper.Map<AccountSummaryDto>(accountSummary);
        }
    }
}
