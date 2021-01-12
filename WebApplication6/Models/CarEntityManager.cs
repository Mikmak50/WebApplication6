using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication6.Data;

namespace WebApplication6.Models
{
    public class CarEntityManager
    {
        public ApplicationDbContext DbContext { get; private set; }
        public CarEntityManager(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public static CarEntityManager Create(ApplicationDbContext dbContext)
        {
            var carEntityManager = new CarEntityManager(dbContext);
            return carEntityManager;
        }

        internal Car GetByName(string name)
        {
            var car = DbContext.Cars.Where(c => c.Name == name).FirstOrDefault();
            if(car == null)
            {
                car = new Car() { Name = name, Seats = 0 };
                DbContext.Cars.Add(car);
                DbContext.SaveChanges();
                
            }

            return car;
        }
    }
}
