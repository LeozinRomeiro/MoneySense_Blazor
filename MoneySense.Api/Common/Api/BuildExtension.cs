using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MoneySense.Api.Data;
using MoneySense.Api.Handlers;
using MoneySense.Core.Handler;
using MoneySense.Core;

namespace MoneySense.Api.Common.Api
{
    public static class BuildExtension
    {
        public static void AddConfiguration(this WebApplicationBuilder builder)
        {
            Configuration.ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? string.Empty;
            Configuration.BackendUrl = builder.Configuration.GetValue<string>("BackendUrl") ?? string.Empty;
            Configuration.FrontendUrl = builder.Configuration.GetValue<string>("FrontendUrl") ?? string.Empty;
        }

        public static void AddDocumentation(this WebApplicationBuilder builder)
        {
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(x =>
            {
                x.CustomSchemaIds(n => n.FullName);
            });
        }

        public static void AddDataContexts(this WebApplicationBuilder builder)
        {
            builder
                .Services
                .AddDbContext<AppDbContext>(
                    x =>
                    {
                        x.UseSqlServer(Configuration.ConnectionString);
                    });
        }

        public static void AddCrossOrigin(this WebApplicationBuilder builder)
        {
            builder.Services.AddCors(
                options => options.AddPolicy(
                    ApiConfiguration.CorsPolicyName,
                    policy => policy
                        .WithOrigins([
                            Configuration.BackendUrl,
                        Configuration.FrontendUrl
                        ])
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials()
                ));
        }

        public static void AddServices(this WebApplicationBuilder builder)
        {
            builder
                .Services
                .AddTransient<ICategoryHandler, CategoryHandler>();

            builder
                .Services
                .AddTransient<ITransactionHandler, TransactionHandler>();
        }
    }
}
