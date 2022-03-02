//using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PersonalFinanceManagement.Configurations.Entities;
using PersonalFinanceManagement.Data;

namespace PersonalFinanceManagement.Configurations
{
    public class AppDbContext : DbContext // IdentityDbContext<UserSpecificClass> 
    {
        public AppDbContext(DbContextOptions<AppDbContext> option) : base(option)
        {

        }

       
        public DbSet<AccountSummary> AccountSummaries { get; set; }
       

       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new AccountSummariesConfiguration()); // this seeds the table base on our configurations

        }

    }
}
