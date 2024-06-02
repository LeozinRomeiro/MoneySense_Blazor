using Microsoft.EntityFrameworkCore;
using MoneySense.Api;
using MoneySense.Api.Common.Api;
using MoneySense.Api.Data;
using MoneySense.Api.Handlers;
using MoneySense.Core.Endpoints;
using MoneySense.Core.Handler;

var builder = WebApplication.CreateBuilder(args);

builder.AddConfiguration();
builder.AddDataContexts();
builder.AddCrossOrigin();
builder.AddDocumentation();
builder.AddServices();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.ConfigureDevEnvironment();
}

app.UseCors(ApiConfiguration.CorsPolicyName);
app.MapEndpoints();

app.Run();
