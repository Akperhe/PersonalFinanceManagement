using Newtonsoft.Json.Serialization;
using PersonalFinanceManagement.Configurations;
using PersonalFinanceManagement.Repositories.Implementations;
using PersonalFinanceManagement.Repositories.Interfaces;
using PersonalFinanceManagement.Services.Implementations;
using PersonalFinanceManagement.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.ConfigureAutoMapper();
builder.Services.MyDbConfiguration(builder.Configuration);





builder.Services.AddControllers().AddNewtonsoftJson(s =>
{ s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver(); });
//configure the above because of the patch operation we intend doing

builder.Services.AddScoped<IAccountSummaryServices, AccountSummaryServices>();
builder.Services.AddScoped<IAccountSummaryRepo, AccountSummaryRepo>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
