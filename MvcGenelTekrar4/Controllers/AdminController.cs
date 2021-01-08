using MvcGenelTekrar4.Models;
using MvcGenelTekrar4.Models.Attribute;
using MvcGenelTekrar4.Models.EntityFramework;
using MvcGenelTekrar4.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcGenelTekrar4.Controllers
{
    [EmployeeAuthorize]
    public class AdminController : Controller
    {
        NorthwindContext _db = new NorthwindContext();

        [HttpGet]
        public ActionResult ListMyProducts()
        {
            ListProductsViewModel model = new ListProductsViewModel
            {
                Products = _db.Products.ToList()
            };

            return View(model);
        }

        [HttpGet]
        public ActionResult AddMyProduct()
        {
            ProductManipulationViewModel model = new ProductManipulationViewModel
            {
                Product = new Product(),
                Categories = _db.Categories.ToList(),
                Suppliers = _db.Suppliers.ToList(),
                ButtonText = "Add Product"
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult AddMyProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                ProductManipulationViewModel model = new ProductManipulationViewModel
                {
                    Product = new Product(),
                    Categories = _db.Categories.ToList(),
                    Suppliers = _db.Suppliers.ToList(),
                    ButtonText = "Add Product"
                };

                return View(model);
            }

            _db.Entry<Product>(product).State = System.Data.Entity.EntityState.Added;
            _db.SaveChanges();

            return RedirectToAction("ListMyProducts");
        }
        [HttpGet]
        public ActionResult UpdateMyProduct(int id)
        {
            ProductManipulationViewModel model = new ProductManipulationViewModel
            {
                Product = _db.Products.Find(id),
                Categories = _db.Categories.ToList(),
                Suppliers = _db.Suppliers.ToList(),
                ButtonText = "Update Product"
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult UpdateMyProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                ProductManipulationViewModel model = new ProductManipulationViewModel
                {
                    Product = _db.Products.Find(product.ProductID),
                    Categories = _db.Categories.ToList(),
                    Suppliers = _db.Suppliers.ToList(),
                    ButtonText = "Update Product"
                };

                return View(model);
            }

            _db.Entry<Product>(product).State = System.Data.Entity.EntityState.Modified;
            _db.SaveChanges();

            return RedirectToAction("ListMyProducts");
        }

        [HttpGet]
        public ActionResult DeleteMyProduct(int id)
        {
            _db.Entry<Product>(new Product { ProductID = id }).State = System.Data.Entity.EntityState.Deleted;
            _db.SaveChanges();

            return RedirectToAction("ListMyProducts");
        }
    }
}