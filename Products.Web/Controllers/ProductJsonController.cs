using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Products.Data.Entities;
using Products.Data.Interfaces;
using Products.Web.Help;
using Products.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Products.Web.Controllers
{
    public class ProductJsonController : Controller
    {
        private IJsonService<Product> _product;
        private IJsonService<Category> _category;
        private IJsonService<Manufacturer> _manufacturer;
        private IJsonService<Supplier> _supplier;
        private IMapper _mapper;
        public ProductJsonController(IJsonService<Product> product, IMapper mapper, IJsonService<Category> category,
            IJsonService<Manufacturer> manufacturer, IJsonService<Supplier> supplier)
        {
            _product = product;
            _mapper = mapper;
            _category = category;
            _manufacturer = manufacturer;
            _supplier = supplier;

        }
        public async Task<ActionResult<ProductIndexModelList>> Index()
        {
            var products = await _product.GetAll();
            if (products is null || products.Count() == 0)
            {
                var modelError = new ProductIndexModelList() { Validate = new ValidateModel { Poruka = "Lose ucitani proizvodi", Signal = false } };
                return View(modelError);
            }
            var model = CreateIndexModel(products);
            return View(model);
        }
        public async Task<ActionResult<ProductCreateModel>> Create()
        {
            var model = await CreateProductModel(new Product());
            return View(model);
        }
        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ProductCreateModel productCreate)
        {

            var model = await CreateProductModel(productCreate.Product);
            if (!Validation.Instance.ValidateProduct(productCreate.Product))
            {
                model.Validate = new ValidateModel() { Poruka = "Pogresno ste uneli neku vrednost", Signal = false };
                return View(model);
            }
            if (!(await ProductNameExist(productCreate.Product.ProductName, 0)))
            {
                model.Validate = new ValidateModel() { Poruka = "Postoji vec proizvod sa datim imenom!", Signal = false };
                return View(model);
            }

            productCreate.Product = await CreateProduct(productCreate.Product); 
            var response = await _product.Add(productCreate.Product);

            if (!response)
            {
                model.Validate = new ValidateModel() { Poruka = "Doslo je do greske prilikom unosa proizvoda!", Signal = false };
                return View(model);
            }
            model.Validate = new ValidateModel() { Poruka = "Uspesno ste dodali proizvod!", Signal = false };
            return View(model);
        }

        public async Task<ActionResult> Update(int id)
        {
            var product = await _product.GetById(id);
            var model = await CreateProductModel(product);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Update(int id, ProductCreateModel productCreate)
        {
            productCreate.Product.ProductId = id;
            var model = await CreateProductModel(productCreate.Product);

            if (!Validation.Instance.ValidateProduct(productCreate.Product))
            {
                model.Validate = new ValidateModel() { Poruka = "Pogresno ste unenli neku vrednost", Signal = false };
                return View(model);
            }
            if (!(await ProductNameExist(productCreate.Product.ProductName, id)))
            {
                model.Validate = new ValidateModel() { Poruka = "Postoji vec proizvod sa datim imenom!", Signal = false };
                return View(model);
            }

            productCreate.Product = await CreateProduct(productCreate.Product);
            var response = await _product.Update(productCreate.Product);

            if (!response)
            {
                model.Validate = new ValidateModel() { Poruka = "Doslo je do greske prilikom izmene proizvoda!", Signal = false };
                return View(model);
            }

            model.Validate = new ValidateModel() { Poruka = "Uspesno ste izmenili proizvod", Signal = true };
            return View(model);

        }

        public async Task<ActionResult> Delete(int id)
        {
            var response = await _product.Delete(id);
            if (response) return RedirectToAction(nameof(Index));
            return RedirectToAction(nameof(Index));
        }
        //Ispod su prikazane funkcije za kreiranje modela i proveru da li proizvod postoji u bazi
        private async Task<bool> ProductNameExist(string name, int? id)
        {
            var products = await _product.GetAll();
            var product = products.SingleOrDefault((prod) => prod.ProductName == name && prod.ProductId != id);
            if (product is null) return true;
            return false;
        }
        private async Task<Product> CreateProduct(Product product)
        {
            try
            {
                var categoryList = await _category.GetAll();
                var supplierList = await _supplier.GetAll();
                var manufacturerList = await _manufacturer.GetAll();

                var category = categoryList.SingleOrDefault((cat) => cat.CategoryId == product.Category.CategoryId);
                var supplier = supplierList.SingleOrDefault((sup) => sup.SupplierId == product.Supplier.SupplierId);
                var manufacturer = manufacturerList.SingleOrDefault((man) => man.Id == product.Manufacturer.Id);
                if (category is null || supplier is null || manufacturer is null) return null;
                product.Category = category;
                product.Supplier = supplier;
                product.Manufacturer = manufacturer;
                return product;

            }
            catch (Exception)
            {
                return null;
            }
        }
        private ProductIndexModelList CreateIndexModel(IEnumerable<Product> products)
        {
            var productList = new List<ProductIndexModel>();
            foreach (var product in products)
            {
                var productModel = _mapper.Map<Product, ProductIndexModel>(product);
                productList.Add(productModel);
            }
            var model = new ProductIndexModelList() { ProductList = productList };
            return model;
        }
        private async Task<ProductCreateModel> CreateProductModel(Product product)
        {
            var category = await _category.GetAll();
            var supplier = await _supplier.GetAll();
            var manufacturer = await _manufacturer.GetAll();
            var model = new ProductCreateModel()
            {
                Categories = category,
                Manufactureres = manufacturer,
                Product = product,
                Suppliers = supplier
            };
            return model;
        }

    }
}
