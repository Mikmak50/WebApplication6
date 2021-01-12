using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication6.Data;
using WebApplication6.Models;

namespace WebApplication6.Controllers
{
    public class TestController : Controller
    {
        private readonly ApplicationDbContext _db;
        public TestController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            ApplicationUser user;
            user = _db.ApplicationUsers.Where(u => u.FirstName == "Mikael").SingleOrDefault();
            //Car car;
            //car = _db.Cars.Where(u => u.Name == "Tesla MH").SingleOrDefault();

            //=====================

            //UserCar e = new UserCar
            //{
            //    UserId = "e5cdfb21-1f14-4105-822b-5b9c8eb01989",
            //    CarId = Guid.Parse("9272eb49-2c98-40bc-483b-08d8ab5d2606"),
            //    Owner = true
            //};

                //var userCarInDataBase = _db.UserCars.Where(
                //    s =>
                //            s.UserId == "e5cdfb21-1f14-4105-822b-5b9c8eb01989" &&
                //            s.CarId == Guid.Parse("9272eb49-2c98-40bc-483b-08d8ab5d2606"));
                //if (userCarInDataBase == null)
                //{
                    //_db.UserCars.Add(e);
            //}


            //=====================

            //user.UsersCars.Add(car);


            //var carEntityManager = new CarEntityManager(_db);

            var car = CarEntityManager.Create(_db).GetByName("Tesla MH");

            //user.UsersCars.Add(new UserCar() { UserId = user.Id, CarId = car.Id });
            user.UsersCars.Add(new UserCar() { ApplicationUser=user,Car=car,Owner=true });

            _db.SaveChanges();

            return View();
        }
    }
}
