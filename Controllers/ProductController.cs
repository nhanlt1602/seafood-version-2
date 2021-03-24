using Microsoft.AspNetCore.Mvc;
using seafood_version_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeafoodV4.Controllers
{
    public class ProductController : Controller
    {
        SeafoodContext db = new SeafoodContext();
        public IActionResult ListProducts()
        {
            return View(db.Products.ToList());
        }
    }
}
