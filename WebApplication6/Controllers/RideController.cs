using WebApplication6.Data;
using WebApplication6.Models;
using WebApplication6.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication6.Controllers
{
    public class RideController : Controller
    {
        private readonly ApplicationDbContext _db;
        public RideController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Ride> rideList = _db.Rides.Include(x => x.Car).Include(x => x.PlaceStart).Include(x => x.PlaceEnd);

            //foreach (var obj in objList)
            //{
            //    obj.Car = _db.Cars.FirstOrDefault(x => x.Id == obj.CarId);
            //};
            return View(rideList);
        }

        //GET for UPSERT
        public IActionResult Upsert(Guid? id)
        {
            //Ride ride = new Ride();
            RideVM rideVM = new RideVM()
            {
                Ride = new Ride(),
                CarSelectList = _db.Cars.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }),
                PlaceStartSelectList = _db.Places.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }),
                PlaceEndSelectList = _db.Places.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                })
            };


            if (id == null)
            {
                return View(rideVM);
            }
            else
            {
                rideVM.Ride = _db.Rides.Find(id);
                if(rideVM.Ride == null)
                {
                    return NotFound();
                }
            }
            return View(rideVM);
        }
        //POST for UPSERT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(RideVM rideVM)
        {
            if (ModelState.IsValid)
            {
                if (rideVM.Ride.Id == Guid.Empty)
            {
                

                    _db.Rides.Add(rideVM.Ride);
                    
                
            }
            else
            {
                //var rideFromDb = _db.Rides.AsNoTracking().FirstOrDefault(x => x.Id == rideVM.Ride.Id);
                //if (rideFromDb == null)
                //{
                //    return NotFound();
                //}
                _db.Rides.Update(rideVM.Ride);
            }

            _db.SaveChanges();
            return RedirectToAction("Index");
            }
            rideVM.CarSelectList = _db.Cars.Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });
            rideVM.PlaceStartSelectList = _db.Places.Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });
            rideVM.PlaceEndSelectList = _db.Places.Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });

            return View(rideVM);
        }

        //GET for DELETE
        public IActionResult Delete(Guid id)
        {

            var ride = _db.Rides.Include(x=>x.Car).Include(x => x.PlaceStart).Include(x => x.PlaceEnd).FirstOrDefault(x=>x.Id == id);
            if (ride == null)
            {
                return NotFound();
            }

            return View(ride);
        }

        //POST for DELETE
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(Guid id)
        {
            var ride = _db.Rides.Find(id);
            if (ride == null)
            {
                return NotFound();
            }
            _db.Rides.Remove(ride);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
