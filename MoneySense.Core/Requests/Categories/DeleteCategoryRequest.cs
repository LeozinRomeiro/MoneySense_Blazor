using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneySense.Core.Requests.Categories
{
    public class DeleteCategoryRequest : Request
    {
        public long Id { get; set; }

    }
}
