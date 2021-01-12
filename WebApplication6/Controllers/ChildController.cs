
using WebApplication6.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication6.Data;

namespace WebApplication6.Controllers
{
    public class ChildController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ChildController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Child> childList = _db.Childs;
            return View(childList);
        }

        //GET for CREATE
        public IActionResult Create()
        {

            return View();
        }
        //POST for CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Child child)
        {
            //obj.PassengersCount = 0;
            if (ModelState.IsValid)
            {

                _db.Childs.Add(child);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(child);
        }

        //GET for EDIT
        public IActionResult Edit(Guid id)
        {

            var child = _db.Childs.Find(id);
            if (child == null)
            {
                return NotFound();
            }

            return View(child);
        }

        //POST for EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Child child)
        {
            //obj.PassengersCount = 0;
            if (ModelState.IsValid)
            {

                _db.Childs.Update(child);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(child);
        }
        //GET for DELETE
        public IActionResult Delete(Guid id)
        {

            var child = _db.Childs.Find(id);
            if (child == null)
            {
                return NotFound();
            }

            return View(child);
        }

        //POST for DELETE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(Guid id)
        {
            var child = _db.Childs.Find(id);
            if (child == null)
            {
                return NotFound();
            }
            _db.Childs.Remove(child);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
