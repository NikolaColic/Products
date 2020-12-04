using Newtonsoft.Json;
using Products.Data.Entities;
using Products.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.ServicesJSON.Services
{
    public class ProductJsonService : IJsonService<Product>
    {
        public async Task<bool> Add(Product obj)
        {
            try
            {
                var products = await LoadJson();
                obj.ProductId = MaxId(products) + 1;
                products.Add(obj);
                var response = await WriteJson(products);
                return response;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public int MaxId(List<Product> products)
        {
            var maxId = products.Max((product) => product.ProductId);
            return maxId;
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var products = await LoadJson();
                var productDelete = products.SingleOrDefault((prod) => prod.ProductId == id);
                if (productDelete is null) return false;

                products.Remove(productDelete);
                var response = await WriteJson(products);
                return response;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async  Task<IEnumerable<Product>> GetAll()
        {
            try
            {
                var products = await LoadJson();
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
                var json = await LoadJson();
                var product = json.SingleOrDefault((prod) => prod.ProductId == id);
                return product;
            }
            catch (Exception)
            {
                return null;
            }

        }

        public async Task<bool> Update(Product obj)
        {
            try
            {
                var products = await LoadJson();
                var productDelete = products.SingleOrDefault((prod) => prod.ProductId == obj.ProductId);
                if (productDelete is null) return false;

                products.Remove(productDelete);
                products.Add(obj);
                var response = await WriteJson(products);
                return response;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<List<Product>> LoadJson()
        {
            using (StreamReader r = new StreamReader("../Products.ServicesJSON/JSON/products.json"))
            {
                string json = await r.ReadToEndAsync();
                List<Product> items = JsonConvert.DeserializeObject<List<Product>>(json);
                return items;
            }
        }
        public async Task<bool> WriteJson(List<Product> products)
        {
            try
            {
                using (StreamWriter r = new StreamWriter("../Products.ServicesJSON/JSON/products.json"))
                {
                    string json = JsonConvert.SerializeObject(products);
                    await r.WriteAsync(json);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
