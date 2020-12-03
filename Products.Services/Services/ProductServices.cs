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
    public class ProductServices : IDataService<Product>
    {
        private readonly ProductDbContext _db;
        public ProductServices(ProductDbContext db)
        {
            _db = db;
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

        public async Task<IEnumerable<Product>> GetAll()
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

        public async Task<Product> GetById(int id)
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

        public async Task<bool> Add(Product obj)
        {
            try
            {
                obj = await SetObjects(obj);
                if (obj is null) return false;
                await _db.AddAsync(obj);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> Update(Product obj)
        {
            try
            {
                var productUpdate = await GetById(obj.ProductId);
                if (productUpdate is null) return false;

                obj = await SetObjects(obj);
                if (obj is null) return false;

                //_db.Entry(productUpdate).CurrentValues.SetValues(obj);
                _db.Entry(productUpdate).State = EntityState.Detached;

                _db.Update(obj);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                throw;
                return false;
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var productDelete = await GetById(id);
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
    }
}
