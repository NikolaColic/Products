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
    public class SupplierJsonService : IJsonService<Supplier>
    {
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
                var supplierList = await LoadJson();
                return supplierList;
            }
            catch (Exception)
            {
                return null;
            }
        }
    
        public async Task<List<Supplier>> LoadJson()
        {
            using (StreamReader r = new StreamReader("../Products.ServicesJSON/JSON/supplier.json"))
            {
                string json = await r.ReadToEndAsync();
                List<Supplier> items = JsonConvert.DeserializeObject<List<Supplier>>(json);
                return items;
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
