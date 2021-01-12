
using WebApplication6.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication6.Data;

namespace WebApplication6.Controllers
{
    public class CarController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CarController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Car> objList = _db.Cars;
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
        public IActionResult Create(Car obj)
        {
            //obj.PassengersCount = 0;
            if (ModelState.IsValid)
            {
                
                _db.Cars.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            return View(obj);
        }

        //GET for EDIT
        public IActionResult Edit(Guid id)
        {
            
            var obj = _db.Cars.Find(id);
            if(obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        //POST for EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Car car)
        {
            //obj.PassengersCount = 0;
            if (ModelState.IsValid)
            {

                _db.Cars.Update(car);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(car);
        }
        //GET for DELETE
        public IActionResult Delete(Guid id)
        {

            var obj = _db.Cars.Find(id);
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
            var obj = _db.Cars.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Cars.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
