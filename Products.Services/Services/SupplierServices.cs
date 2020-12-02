using Microsoft.EntityFrameworkCore;
using Products.Data.Context;
using Products.Data.Entities;
using Products.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Products.Services.Services
{
    public class SupplierServices : IDataService<Supplier>
    {
        private readonly ProductDbContext _db;
        public SupplierServices(ProductDbContext db)
        {
            _db = db;
        }
        public Task<bool> Add(Supplier obj)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Supplier>> GetAll()
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

        public Task<Supplier> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Supplier obj)
        {
            throw new NotImplementedException();
        }
    }
}
