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
    public class ManufacturerServices : IDataService<Manufacturer>
    {
        private readonly ProductDbContext _db;
        public ManufacturerServices(ProductDbContext db)
        {
            _db = db;
        }
        public Task<bool> Add(Manufacturer obj)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Manufacturer>> GetAll()
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

        public Task<Manufacturer> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Manufacturer obj)
        {
            throw new NotImplementedException();
        }
    }
}
