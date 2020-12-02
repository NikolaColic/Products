using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Products.Data.Entities;
using Products.Data.Interfaces;
using Products.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Products.Web.Controllers
{
    public class ProductController : Controller
    {
        private IDataService<Product> _product;
        private IDataService<Category> _category;
        private IDataService<Manufacturer> _manufacturer;
        private IDataService<Supplier> _supplier;

        private IMapper _mapper;
        public ProductController(IDataService<Product> product, IMapper mapper, IDataService<Category> category,
            IDataService<Manufacturer> manufacturer, IDataService<Supplier> supplier)
        {
            _product = product;
            _mapper = mapper;
            _category = category;
            _manufacturer = manufacturer;
            _supplier = supplier;

        }
        // GET: ProductController
        public async Task<ActionResult<ProductIndexModelList>> Index()
        {
            var products = await _product.GetAll();

            var productList = new List<ProductIndexModel>();
            foreach(var product in products)
            {
                var productModel = _mapper.Map<Product, ProductIndexModel>(product);
                productList.Add(productModel);
            }
            var model = new ProductIndexModelList() { ProductList = productList };
            return View(model);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductController/Create
        public async Task<ActionResult<ProductCreateModel>>Create()
        {
            var category = await _category.GetAll();
            var supplier = await _supplier.GetAll();
            var manufacturer = await _manufacturer.GetAll();
            var model = new ProductCreateModel()
            {
                Categories = category,
                Manufactureres = manufacturer,
                Product = new Product(),
                Suppliers = supplier
            };
            return View(model);
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public async Task<ActionResult> Update(int id)
        {
            var category = await _category.GetAll();
            var supplier = await _supplier.GetAll();
            var manufacturer = await _manufacturer.GetAll();
            var product = await _product.GetById(id);
            var model = new ProductCreateModel()
            {
                Categories = category,
                Manufactureres = manufacturer,
                Product = product,
                Suppliers = supplier
            };
            return View(model);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
