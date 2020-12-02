using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Products.Data.Entities
{
    public class Supplier
    {
        [Key]
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public string Adress { get; set;  }
        public string Mobile { get; set; }
        public string Email { get; set; }
    }
}
