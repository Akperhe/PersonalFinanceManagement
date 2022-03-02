using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Newtonsoft.Json.Serialization;

namespace PersonalFinanceManagement.Configurations
{
    public static class ServiceExtensions
    {
        public static void ConfigureAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }

        public static void MyDbConfiguration(this IServiceCollection service, IConfiguration config)
        {
            service.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(config.GetConnectionString("connectionString")));
        }
    }
}
