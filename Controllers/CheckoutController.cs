using MagazinOnlineImbracaminte.Helpers;
using MagazinOnlineImbracaminte.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagazinOnlineImbracaminte.Controllers
{
    public class CheckoutController : Controller
    {
        public IActionResult Index()
        {
            var cart = SessionHelper.GetObjectFromJson<DbSet<Product>>(HttpContext.Session, "cart");
            ViewData["cart"] = cart;
            ViewData["total"] = cart.Sum(item => item.Price);
            return View();
        }
    }
}
