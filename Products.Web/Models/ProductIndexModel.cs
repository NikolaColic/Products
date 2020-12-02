using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Products.Web.Models
{
    public class ProductIndexModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public double Cost { get; set; }
        public string ManufacturerName { get; set; }
        public string SupplierName { get; set; }
        public string CategoryName { get; set; }
    }
}
