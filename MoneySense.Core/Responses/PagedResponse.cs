using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MoneySense.Core.Responses
{
    public class PagedResponse<TResponse> : Response<TResponse>
    {
        [JsonConstructor]
        public PagedResponse(TResponse? data, int totalCount, int currentPage = 1,
            int pageSize = Configuration.DefaultPageSize) : base(data)
        {
            Data = data;
            ToralCount = totalCount;
            CurrentPage = currentPage;
            PageSize = pageSize;
        }
        public PagedResponse(TResponse? data, int code = Configuration.DefaultStatusCode, string? message = null) : base(data, code, message)
        {

        }
        public int CurrentPage { get; set; }
        public int TotalPages => (int)Math.Ceiling(ToralCount / (double)PageSize);
        public int PageSize { get; set; } = Configuration.DefaultPageSize;
        public int ToralCount { get; set; }
    }
}
