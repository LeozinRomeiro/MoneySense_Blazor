using MoneySense.Core.Models;
using MoneySense.Core.Requests.Categories;
using MoneySense.Core.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneySense.Core.Handler
{
    public interface ICateforyHandler
    {
        Task<Response<Category?>> CreateAsync(CreateCategoryRequest request);
        Task<Response<Category?>> UpdateAsync(UpdateCategoryRequest request);
        Task<Response<Category?>> DeleteAsync(DeleteCategoryRequest request);
        Task<Response<Category?>> GetByIdAsync(GetByIdCategoryRequest request);
        Task<PagedResponse<List<Category?>>> GetAllAsync(GetAllCategoriesRequest request);
    }
}
