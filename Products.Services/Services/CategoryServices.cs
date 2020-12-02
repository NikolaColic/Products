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
    public class CategoryServices : IDataService<Category>
    {
        private readonly ProductDbContext _db;
        public CategoryServices(ProductDbContext db)
        {
            _db = db;
        }
        public Task<bool> Add(Category obj)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Category>> GetAll()
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

        public Task<Category> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Category obj)
        {
            throw new NotImplementedException();
        }
    }
}
