using Products.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Products.Data.Interfaces
{
    public interface IProduct
    {
        Task<IEnumerable<Product>> GetAllProducts();
        Task<Product> GetProductById(int id);
        Task<bool> AddProduct(Product product);
        Task<bool> UpdateProduct(Product product);
        Task<bool> DeleteProduct(int id);
        Task<IEnumerable<Category>> GetAllCategories();
        Task<IEnumerable<Manufacturer>> GetAllManufactureres();
        Task<IEnumerable<Supplier>> GetAllSupplier();

    }
}
