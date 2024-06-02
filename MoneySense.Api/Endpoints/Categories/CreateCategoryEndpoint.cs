using MoneySense.Api.Common.Api;
using MoneySense.Core.Handler;
using MoneySense.Core.Models;
using MoneySense.Core.Requests.Categories;
using MoneySense.Core.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneySense.Api.Endpoints.Categories
{
    public class CreateCategoryEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapPost("/", HandleAsync)
                .WithName("Categories: Create")
                .WithSummary("Cria uma nova categoria")
                .WithDescription("Cria uma nova categoria")
                .WithOrder(1)
                .Produces<Response<Category?>>();

        private static async Task<IResult> HandleAsync(
            ICategoryHandler handler,
            CreateCategoryRequest request)
        {
            request.UserId = ApiConfiguration.UserId;
            var response = await handler.CreateAsync(request);
            return response.IsSuccess
                ? TypedResults.Created($"v1/categories/{response.Data?.Id}", response)
                : TypedResults.BadRequest(response);
        }
    }
}
