using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneySense.Core.Requests.Transactions
{
    public class GetByPeriodTransactionRequest : Request
    {
        public DateTime? StarDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
