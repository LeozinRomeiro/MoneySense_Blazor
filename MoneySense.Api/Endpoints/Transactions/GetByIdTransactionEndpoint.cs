using MoneySense.Api.Common.Api;
using MoneySense.Core.Handler;
using MoneySense.Core.Models;
using MoneySense.Core.Requests.Transactions;
using MoneySense.Core.Responses;

namespace MoneySense.Api.Endpoints.Transactions
{
    public class GetTransactionByIdEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapGet("/{id}", HandleAsync)
                .WithName("Transactions: Get By Id")
                .WithSummary("Recupera uma transação")
                .WithDescription("Recupera uma transação")
                .WithOrder(4)
                .Produces<Response<Transaction?>>();

        private static async Task<IResult> HandleAsync(
            ITransactionHandler handler,
            long id)
        {
            var request = new GetByIdTransactionRequest
            {
                UserId = ApiConfiguration.UserId,
                Id = id
            };

            var result = await handler.GetByIdAsync(request);
            return result.IsSuccess
                ? TypedResults.Ok(result)
                : TypedResults.BadRequest(result);
        }
    }
}
