using Microsoft.EntityFrameworkCore;
using MoneySense.Api.Data;
using MoneySense.Api.Handlers;
using MoneySense.Core.Handler;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

const string connectionString = "Server=localhost,1433;Database=DataTemTrampo;User ID=sa;Password=Leoadmin32@#$;Trusted_Connection=False;TrustServerCertificate=True;";

builder.Services.AddDbContext<AppDbContext>(x=>x.UseSqlServer(connectionString));

builder.Services.AddTransient<ICategoryHandler, CategoryHandler>();
builder.Services.AddTransient<ITransactionHandler, TransactionHandler>();

app.MapEndpoints();

app.Run();
