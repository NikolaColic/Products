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
    public class CategoryJsonServices : IJsonService<Category>

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
            var lista = LoadJson();
            return lista;
        }

        public Task<Category> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Category> LoadJson()
        {
            using (StreamReader r = new StreamReader("../Products.ServicesJSON/JSON/category.json"))
            {
                string json = r.ReadToEnd();
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
