using Microsoft.AspNetCore.JsonPatch;
using PersonalFinanceManagement.Data;
using PersonalFinanceManagement.Data.Dtos;
using PersonalFinanceManagement.Models;
using X.PagedList;

namespace PersonalFinanceManagement.Services.Interfaces
{
    public interface IAccountSummaryServices
    {

        public Task<AccountSummaryDto> CreateAccount(CreateAccountSummaryDto req);
        public Task DeleteAccount(string? id);
        public Task<List<AccountSummaryDto>> GetAllAccounts();
        public Task<AccountSummaryDto> GetAccount(string id); //i didnt add the type trying out
        public Task UpdateAccount(string id, AccountSummary req);
        public Task<AccountSummaryDto> UpdateAccountName(string id, string req);
        public Task<AccountSummaryDto> UpdateAccountDetails(string id, UpdateAccountSummaryDto req);
        public Task<List<AccountSummaryDto>> GetPageListOfAccounts(RequestParamForPaging req);

        public Task<AccountSummaryDto> PartialUpdateAccount(string id, JsonPatchDocument<UpdateAccountSummaryDto> req);
        public Task<bool> SaveChangesAsync();
    }
}
