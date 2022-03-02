using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using PersonalFinanceManagement.Configurations;
using PersonalFinanceManagement.Data;
using PersonalFinanceManagement.Data.Dtos;
using PersonalFinanceManagement.Models;
using PersonalFinanceManagement.Repositories.Interfaces;
using X.PagedList;

namespace PersonalFinanceManagement.Repositories.Implementations
{
    public class AccountSummaryRepo : IAccountSummaryRepo
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;

        public AccountSummaryRepo(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext; 
            _mapper = mapper;
        }

        public async Task<bool> SaveChangesAsync() => await _appDbContext.SaveChangesAsync() > 0;
        public async Task<AccountSummary> CreateAccount(AccountSummary req)
        {
            await _appDbContext.AccountSummaries.AddAsync(req);
            await SaveChangesAsync();
            return await GetAccount(req.Id);

        }

        public async Task DeleteAccount(string id)
        {
            var account = await GetAccount(id);
            _appDbContext.AccountSummaries.Remove(account); //delete in database operation is not performing async function
            await SaveChangesAsync();
        }

        public async Task<AccountSummary> GetAccount(string id)
        {
            var accountSummary = await _appDbContext.AccountSummaries.FirstOrDefaultAsync(accountSummary => accountSummary.Id == id);
            if (accountSummary == null)
               return null;
            return accountSummary;
        }

        public async Task<List<AccountSummary>> GetAllAccounts()
        {
            var accounts = await _appDbContext.AccountSummaries.ToListAsync();
            return accounts;
        }

       

        public async Task<AccountSummary> PartialUpdateAccount(string id, JsonPatchDocument<UpdateAccountSummaryDto> req)
        {
            var accountSummary = await GetAccount(id);
            var accountSummaryTopatch = _mapper.Map<UpdateAccountSummaryDto>(accountSummary);
            req.ApplyTo(accountSummaryTopatch);
            var accountSummaryPatched = accountSummaryTopatch;
            _mapper.Map(accountSummaryPatched, accountSummary);
            await SaveChangesAsync();
            return accountSummary;

        }

        public async Task UpdateAccount(string id, AccountSummary req)
        {
            var accountSummary = await _appDbContext.AccountSummaries.FirstOrDefaultAsync(accountSummary => accountSummary.Id == id);
            
            _mapper.Map(req, accountSummary);
           
            await SaveChangesAsync();

        }

        public async Task<AccountSummary> UpdateAccountName(string id,string req)
        {
            var accountSummary = await _appDbContext.AccountSummaries.FirstOrDefaultAsync(accountSummary => accountSummary.Id == id);
            accountSummary.FirstName = req;
            await SaveChangesAsync();
            return accountSummary; 
        }

        public async Task<IPagedList<AccountSummary>> GetPageListOfAccounts(RequestParamForPaging req)
        {
            var accountSummaries = await  _appDbContext.AccountSummaries.ToPagedListAsync(req.PageNumber, req.PageSize);
            return accountSummaries;
        }

        public async Task<AccountSummary> UpdateAccountDetails(string id, UpdateAccountSummaryDto req)
        {
            var accountSummary =await GetAccount(id);
            _mapper.Map(req, accountSummary); 
            await SaveChangesAsync();
            return accountSummary;

        }
    }
}
