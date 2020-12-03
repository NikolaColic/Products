using Products.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Products.Web.Help
{
    public class Validation
    {
        private static Validation instance;
        private Validation()
        {

        }
        public static Validation Instance
        {
            get
            {
                if (instance == null) instance = new Validation();
                return instance;
            }
        }

        public bool ValidateProduct(Product product)
        {
            try
            {
                if (String.IsNullOrEmpty(product.ProductName) || String.IsNullOrEmpty(product.Description)
                        || product.Cost <= 0) return false;
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
