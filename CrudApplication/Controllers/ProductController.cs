using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudApplication.Data;
using CrudApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace CrudApplication.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationContext context;

        public Product Products { get; private set; }

        public ProductController(ApplicationContext context)
        {
            this.context = context;
        }

        public IActionResult Index(int pg=1)
            const int pageSize = 10;
        int recsCount = Product.Count();
        
        Pager =new Pager(recsCount, pagesize);
        int recSkip=(int)pageSize;  
        Data = Product.Skip(recSkip).Take()
                
        {
            return View((List<Models.Product>?)context.Products.ToList());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product model)
        {
            if (ModelState.IsValid)
            {
                var product = new Product()
                {
                    ProductId = model.ProductId,
                    ProductName = model.ProductName,
                    CatagoryId = model.CatagoryId,
                    CategoryName = model.CategoryName
                };
                context.Products.Add(product);
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                TempData["error"] = "Empty field Cant Submit";
                return View(model);
            }
        }
        public IActionResult Delete(int ProductId)
        {
            var emp = context.Products.SingleOrDefault(p => p.ProductId == ProductId);
            context.Products.Remove(Products);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int ProductId)
        {
            var product = context.Products.SingleOrDefault(p => p.ProductId == ProductId);
            var result = new Product()
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                CatagoryId = product.CatagoryId,
                CategoryName = product.CategoryName

            };

            return View( result);
        }
        [HttpPost]
        public IActionResult Edit(Product model)
        {
            var product = new Product()
            {
                ProductId = model.ProductId,
                ProductName = model.ProductName,
                CatagoryId = model.CatagoryId,
                CategoryName = model.CategoryName
            };
            context.Products.Update(product);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }

}

