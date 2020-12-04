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
    public class ManufacturerJsonService : IJsonService<Manufacturer>
    {
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
                var manufacturerList = await LoadJson();
                return manufacturerList;
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
        public async Task<List<Manufacturer>> LoadJson()
        {
            using (StreamReader r = new StreamReader("../Products.ServicesJSON/JSON/manufacturer.json"))
            {
                string json = await r.ReadToEndAsync();
                List<Manufacturer> items = JsonConvert.DeserializeObject<List<Manufacturer>>(json);
                return items;
            }
        }

    }
}
