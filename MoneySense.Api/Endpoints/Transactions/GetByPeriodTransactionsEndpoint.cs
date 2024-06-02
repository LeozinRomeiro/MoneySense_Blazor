using Microsoft.AspNetCore.Mvc;
using MoneySense.Api.Common.Api;
using MoneySense.Core;
using MoneySense.Core.Handler;
using MoneySense.Core.Models;
using MoneySense.Core.Requests.Transactions;
using MoneySense.Core.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneySense.Api.Endpoints.Transactions
{
    public class GetByPeriodTransactionsEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapGet("/", HandleAsync)
                .WithName("Transactions: Get All")
                .WithSummary("Recupera todas as transações")
                .WithDescription("Recupera todas as transações")
                .WithOrder(5)
                .Produces<PagedResponse<List<Transaction>?>>();

        private static async Task<IResult> HandleAsync(
            ITransactionHandler handler,
            [FromQuery] DateTime? startDate = null,
            [FromQuery] DateTime? endDate = null,
            [FromQuery] int pageNumber = Configuration.DefaultPageNumber,
            [FromQuery] int pageSize = Configuration.DefaultPageSize)
        {
            var request = new GetByPeriodTransactionsRequest
            {
                UserId = ApiConfiguration.UserId,
                PageNumber = pageNumber,
                PageSize = pageSize,
                StartDate = startDate,
                EndDate = endDate
            };

            var result = await handler.GetByPeriodAsync(request);
            return result.IsSuccess
                ? TypedResults.Ok(result)
                : TypedResults.BadRequest(result);
        }
    }
}
