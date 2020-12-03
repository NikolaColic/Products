using Products.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Products.Web.Models
{
    public class ProductCreateModel
    {
        public Product Product { get; set;  }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Manufacturer> Manufactureres { get; set; }
        public IEnumerable<Supplier> Suppliers { get; set; }
        public ValidateModel Validate { get; set; }
    }
}
