using Microsoft.AspNetCore.JsonPatch;
using PersonalFinanceManagement.Data;
using PersonalFinanceManagement.Data.Dtos;
using PersonalFinanceManagement.Models;
using X.PagedList;

namespace PersonalFinanceManagement.Repositories.Interfaces
{
    public interface IAccountSummaryRepo
    {

        public Task<AccountSummary> CreateAccount(AccountSummary req);
        public Task DeleteAccount(string id);
        public Task<List<AccountSummary>> GetAllAccounts();
        public Task<AccountSummary> GetAccount(string id); //<AccountSummaryDto> pleassed add the returned type cos a service will it TAG A
        public Task UpdateAccount(string id, AccountSummary req); //<AccountSummaryDto> pleassed add the returned type cos a service will it TAG A
        
        public Task<AccountSummary> PartialUpdateAccount(string id, JsonPatchDocument<UpdateAccountSummaryDto> req);

        public Task<AccountSummary> UpdateAccountName(string id, string req);
        public Task<AccountSummary> UpdateAccountDetails(string id, UpdateAccountSummaryDto req);
        public Task<IPagedList<AccountSummary>> GetPageListOfAccounts(RequestParamForPaging req);
        public Task<bool> SaveChangesAsync();
    }
}
