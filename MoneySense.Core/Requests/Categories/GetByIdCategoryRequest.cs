﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneySense.Core.Requests.Categories
{
    public class GetByIdCategoryRequest : Request
    {
        public long Id { get; set; }
    }
}
