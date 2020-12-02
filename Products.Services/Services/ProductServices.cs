using Microsoft.EntityFrameworkCore;
using Products.Data.Context;
using Products.Data.Entities;
using Products.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Services.Services
{
    public class ProductServices : IProduct
    {
        private readonly ProductDbContext _db;
        public ProductServices(ProductDbContext db)
        {
            _db = db;
        }
        public async Task<bool> AddProduct(Product product)
        {
            try
            {
                product = await SetObjects(product);
                if (product is null) return false;
                await _db.AddAsync(product);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        private async Task<Product> SetObjects(Product product)
        {
            try
            {
                var manufacturer = await _db.Manufacturer.SingleOrDefaultAsync((m) => m.Id == product.Manufacturer.Id);
                var supplier = await _db.Supplier.SingleOrDefaultAsync(s => s.SupplierId == product.Supplier.SupplierId);
                var category = await _db.Category.SingleOrDefaultAsync((c) => c.CategoryId == product.Category.CategoryId);
                if (manufacturer is null || supplier is null || category is null) return null;
                product.Manufacturer = manufacturer;
                product.Supplier = supplier;
                product.Category = category;
                return product;
            }
            catch (Exception)
            {
                return null;
            }

        }

        public async Task<bool> DeleteProduct(int id)
        {
            try
            {
                var productDelete = await GetProductById(id);
                if (productDelete is null) return false;
                _db.Entry(productDelete).State = EntityState.Deleted;
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            try
            {
                var products = await _db.Product
                        .Include((p) => p.Category)
                        .Include((p) => p.Manufacturer)
                        .Include((p) => p.Supplier)
                        .ToListAsync();
                return products;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Product> GetProductById(int id)
        {
            try
            {
                var products = await _db.Product
                        .Include((p) => p.Category)
                        .Include((p) => p.Manufacturer)
                        .Include((p) => p.Supplier)
                        .SingleOrDefaultAsync((p) => p.ProductId == id);
                return products;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<bool> UpdateProduct(Product product)
        {
            try
            {
                var productUpdate = await GetProductById(product.ProductId);
                if (productUpdate is null) return false;

                product = await SetObjects(product);
                if (product is null) return false;

                _db.Entry(productUpdate).CurrentValues.SetValues(product);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            try
            {
                var categories = await _db.Category.ToListAsync();
                return categories;
            }
            catch (Exception)
            {
                return null;
            }

        }

        public async Task<IEnumerable<Manufacturer>> GetAllManufactureres()
        {
            try
            {
                var manu = await _db.Manufacturer.ToListAsync();
                return manu;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<IEnumerable<Supplier>> GetAllSupplier()
        {
            try
            {
                var supp = await _db.Supplier.ToListAsync();
                return supp;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
