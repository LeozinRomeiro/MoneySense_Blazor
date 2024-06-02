using MoneySense.Api.Common.Api;
using MoneySense.Core.Handler;
using MoneySense.Core.Models;
using MoneySense.Core.Requests.Transactions;
using MoneySense.Core.Responses;

namespace MoneySense.Api.Endpoints.Transactions
{
    public class CreateTransactionEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapPost("/", HandleAsync)
                .WithName("Transactions: Create")
                .WithSummary("Cria uma nova transação")
                .WithDescription("Cria uma nova transação")
                .WithOrder(1)
                .Produces<Response<Transaction?>>();

        private static async Task<IResult> HandleAsync(
            ITransactionHandler handler,
            CreateTransactionRequest request)
        {
            request.UserId = ApiConfiguration.UserId;
            var result = await handler.CreateAsync(request);
            return result.IsSuccess
                ? TypedResults.Created($"/{result.Data?.Id}", result)
                : TypedResults.BadRequest(result.Data);
        }
    }
}
