using MoneySense.Core.Enums;
using MoneySense.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneySense.Core.Requests.Transactions
{
    public class CreateTransactionRequest
    {
        [Required(ErrorMessage = "Titulo invalido")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Valor inválido")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "Tipo invalido")]
        public ETransactionType Type { get; set; } = ETransactionType.Withdraw;
        [Required(ErrorMessage = "Categoria inválida")]
        public long CategoryId { get; set; }
        [Required(ErrorMessage = "Data inválida")]  
        public DateTime? PaidOrReceiveAt { get; set; }
    }
}
