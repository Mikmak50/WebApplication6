using WebApplication6.Data;
using WebApplication6.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication6.Controllers
{
    public class PlaceController : Controller
    {
        private readonly ApplicationDbContext _db;
        public PlaceController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Place> objList = _db.Places;
            return View(objList);
        }

        //GET for CREATE
        public IActionResult Create()
        {
            
            return View();
        }
        //POST for CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Place obj)
        {
            _db.Places.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        //GET for EDIT
        public IActionResult Edit(Guid id)
        {

            var obj = _db.Places.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        //POST for EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Place obj)
        {
            //obj.PassengersCount = 0;
            if (ModelState.IsValid)
            {

                _db.Places.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(obj);
        }
        //GET for DELETE
        public IActionResult Delete(Guid id)
        {

            var obj = _db.Places.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        //POST for DELETE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(Guid id)
        {
            var obj = _db.Places.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Places.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
