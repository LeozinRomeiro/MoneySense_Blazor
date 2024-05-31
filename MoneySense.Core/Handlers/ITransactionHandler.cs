using MoneySense.Core.Models;
using MoneySense.Core.Requests.Transactions;
using MoneySense.Core.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneySense.Core.Handler
{
    public interface ITransactionHandler
    {
        Task<Response<Transaction?>> CreateAsync(CreateTransactionRequest request);
        Task<Response<Transaction?>> UpdateAsync(UpdateTransactionRequest request);
        Task<Response<Transaction?>> DeleteAsync(DeleteTransactionRequest request);
        Task<Response<Transaction?>> GetByIdAsync(GetByIdTransactionRequest request);
        Task<PagedResponse<List<Transaction>?>> GetByPeriodAsync(GetByPeriodTransactionsRequest request);
    }
}
