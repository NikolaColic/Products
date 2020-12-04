using Newtonsoft.Json;
using Products.Data.Entities;
using Products.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Products.ServicesJSON.Services
{
    public class CategoryJsonService : IJsonService<Category>

    {
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
                var categoryList = await LoadJson();
                return categoryList;
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

        public async Task<List<Category>> LoadJson()
        {
            using (StreamReader r = new StreamReader("../Products.ServicesJSON/JSON/category.json"))
            {
                string json = await r.ReadToEndAsync();
                List<Category> items = JsonConvert.DeserializeObject<List<Category>>(json);
                return items;
            }
        }

        public Task<bool> Update(Category obj)
        {
            throw new NotImplementedException();
        }
    }
}
