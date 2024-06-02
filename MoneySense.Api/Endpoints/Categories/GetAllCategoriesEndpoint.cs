using Microsoft.AspNetCore.Mvc;
using MoneySense.Core.Handler;
using MoneySense.Core.Models;
using MoneySense.Core.Requests.Categories;
using MoneySense.Core.Responses;
using MoneySense.Core;
using MoneySense.Api.Common.Api;

namespace MoneySense.Api.Endpoints.Categories
{
    public class GetAllCategoriesEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapGet("/", HandleAsync)
                .WithName("Categories: Get All")
                .WithSummary("Recupera todas as categorias")
                .WithDescription("Recupera todas as categorias")
                .WithOrder(5)
                .Produces<PagedResponse<List<Category>?>>();

        private static async Task<IResult> HandleAsync(
            ICategoryHandler handler,
            [FromQuery] int pageNumber = Configuration.DefaultPageNumber,
            [FromQuery] int pageSize = Configuration.DefaultPageSize)
        {
            var request = new GetAllCategoriesRequest
            {
                UserId = ApiConfiguration.UserId,
                PageNumber = pageNumber,
                PageSize = pageSize,
            };

            var result = await handler.GetAllAsync(request);
            return result.IsSuccess
                ? TypedResults.Ok(result)
                : TypedResults.BadRequest(result);
        }
    }
}
