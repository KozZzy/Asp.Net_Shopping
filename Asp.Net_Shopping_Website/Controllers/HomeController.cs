using MvcGenelTekrar4.Models;
using MvcGenelTekrar4.Models.EntityFramework;
using MvcGenelTekrar4.Models.Managers;
using MvcGenelTekrar4.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcGenelTekrar.Controllers
{
    public class HomeController : Controller
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
        public ActionResult AddMyCart(int id)
        {
            CartManager cartManager;

            if (Session["cart"] != null)
            {
                cartManager = Session["cart"] as CartManager;
            }
            else
            {
                cartManager = new CartManager();
            }

            Product product = _db.Products.Find(id);

            Cart cart = new Cart
            {
                ID = product.ProductID,
                Name = product.ProductName,
                Price = (decimal)product.UnitPrice
            };

            cartManager.Add(cart);
            Session["cart"] = cartManager;

            return RedirectToAction("ListMyProducts");
        }

        [HttpGet]
        public ActionResult ListMyCarts()
        {
            CartManager cartManager;

            if (Session["cart"] != null)
            {
                cartManager = Session["cart"] as CartManager;
            }
            else
            {
                cartManager = new CartManager();
            }

            ListCartsViewModel model = new ListCartsViewModel
            {
                Carts = cartManager.Carts,
                TotalPrice = cartManager.TotalPrice
            };

            return View(model);
        }

        [HttpGet]
        public ActionResult DeleteMyCart(int id)
        {
            CartManager cartManager = Session["cart"] as CartManager;

            cartManager.Delete(id);

            return RedirectToAction("ListMyCarts");
        }

        [HttpPost]
        public ActionResult UpdateMyCarts(params short[] amounts)
        {
            CartManager cartManager = Session["cart"] as CartManager;

            cartManager.Update(amounts);

            return RedirectToAction("ListMyCarts");
        }
    }
}