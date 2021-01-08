using MvcGenelTekrar4.Models;
using MvcGenelTekrar4.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcGenelTekrar4.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Employee employee)
        {
            NorthwindContext db = new NorthwindContext();
            Employee loginEmployee = db.Employees.FirstOrDefault(x => x.FirstName == employee.FirstName && x.LastName == employee.LastName);

            if (loginEmployee != null)
            {
                Session["login"] = loginEmployee;
                return RedirectToAction("ListMyProducts", "Admin");
            }

            ModelState.AddModelError("", "Kullinici adi veya sifre yanlistir");

            return View();
        }

        [HttpGet]
        public ActionResult Logout()
        {
            if (Session["login"] != null)
            {
                Session.Remove("login");
            }

            return View("Login");
        }
    }
}