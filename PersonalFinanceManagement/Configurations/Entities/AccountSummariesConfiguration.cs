using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalFinanceManagement.Data;

namespace PersonalFinanceManagement.Configurations.Entities
{
    public class AccountSummariesConfiguration : IEntityTypeConfiguration<AccountSummary>
    {
       
            public void Configure(EntityTypeBuilder<AccountSummary> builder)
            {
                builder.HasData(
                    new AccountSummary
                    {
                        Id = Guid.NewGuid().ToString(),
                        AccountNo = "2119174850",
                        FirstName = "Akperhe",
                        LastName = "Smith",
                         Address = "Sangotedo",
                         Balance = 8036844238,
                         DateCreated = DateTime.Now,
                         DateModified = DateTime.Now
                    }  
                );
            }
        
    }
}
