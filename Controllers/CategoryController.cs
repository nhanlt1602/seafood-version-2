using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using seafood_version_2.Models;

namespace seafood_version_2.Controllers
{
    public class CategoryController : Controller
    {
        SeafoodContext context = new SeafoodContext();

        // GET: CategoryController
        public ActionResult Index()
        {
            return View(context.Categories.ToList());
        }

        // GET: CategoryController/Details/5
        public ActionResult Details(int id)
        {
            return View(context.Categories.Where(s => s.ProTypeId == id).FirstOrDefault());
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string ProTypeName)
        {
            try
            {
                Category category = new Category();
                category.ProTypeName = ProTypeName;
                context.Categories.Add(category);
                context.SaveChanges();
                ViewBag.Msg = "Create Success!!!";
                return View();
            }
            catch
            {
                ViewBag.Msg = "Create Fail!!!";
                return View();
            }
        }

        // GET: CategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(context.Categories.Where(s => s.ProTypeId == id).FirstOrDefault());
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string ProTypeId, string ProTypeName)
        {
            try
            {
                Category category = new Category();
                category.ProTypeId = int.Parse(ProTypeId);
                category.ProTypeName = ProTypeName;
                context.Entry(category).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
                ViewBag.Msg = "Update Success!!!";
                return View();
            }
            catch
            {
                ViewBag.Msg = "Update Fail!!!";
                return View();
            }
        }

        // GET: CategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(context.Categories.Where(s => s.ProTypeId == id).FirstOrDefault());
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                Category category = new Category();
                category = context.Categories.Where(s => s.ProTypeId == id).FirstOrDefault();
                context.Categories.Remove(category);
                context.SaveChanges();
                ViewBag.Msg = "Delete Success!!!";
                return View();
            }
            catch
            {
                ViewBag.Msg = "Delete Fail!!!";
                return View();
            }
        }
    }
}
