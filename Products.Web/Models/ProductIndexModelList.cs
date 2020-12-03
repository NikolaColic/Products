using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Products.Web.Models
{
    public class ProductIndexModelList
    {
        public IEnumerable<ProductIndexModel> ProductList { get; set; }
        public ValidateModel Validate { get; set; }
    }
}
