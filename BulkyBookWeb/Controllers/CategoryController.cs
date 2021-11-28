using BulkyBookWeb.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BulkyBookWeb.Models;

namespace BulkyBookWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly EFContext _db;

        public CategoryController(EFContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var dbResult = _db.Categories.ToList();
            return View(dbResult);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            //obj neni prazdny 
            //obj ma validni model

            if (obj.DisplayOrder.ToString() == obj.Name)
                ModelState.AddModelError("DiffValueRequested", "Please set different values for Name and Dispaly Order.");


            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();

                TempData["success"] = "Category created successfully.";
                return RedirectToAction("Index");
            }

            return View(obj);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id is null || id == 0)
                return NotFound();

            var item = _db.Categories.FirstOrDefault(i => i.Id == id);

            if (item is null)
            {
                return NotFound();
            }

            return View("Edit", item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            //obj neni prazdny 
            //obj ma validni model

            if (obj.DisplayOrder.ToString() == obj.Name)
                ModelState.AddModelError("DiffValueRequested", "Please set different values for Name and Dispaly Order.");


            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Category edited successfully.";
                return RedirectToAction("Index");
            }

            return View(obj);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id is null || id == 0)
                return NotFound();

            var item = _db.Categories.FirstOrDefault(i => i.Id == id);

            if (item is null)
            {
                return NotFound();
            }

            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public IActionResult Delete2(int? id)
        {
            //if (id == 0 || id is null)
            //    return NotFound();

            var itemToDelete = _db.Categories.FirstOrDefault(o => o.Id == id);

            if (itemToDelete is null)
                return NotFound();


            _db.Categories.Remove(itemToDelete);
            _db.SaveChanges();
            TempData["success"] = "Category deleted successfully.";
            return RedirectToAction("Index");
        }
    }
}
