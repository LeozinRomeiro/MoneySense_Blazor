using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneySense.Core.Requests.Categories
{
    public class CreateCategoryRequest : Request
    {
        [Required(ErrorMessage ="Titulo invalido")]
        [MaxLength(80, ErrorMessage = "O titulo dever conter ate 80 caracteres")]
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
