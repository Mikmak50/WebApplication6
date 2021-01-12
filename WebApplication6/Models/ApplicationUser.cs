using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace WebApplication6.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string Denomination { get; set; }
        public virtual ICollection<UserCar> UsersCars { get; set; } = new List<UserCar>();
        //public virtual List<Child> Child { get; set; }
        //public List<Child> Child { get; set; } = new List<Child>();
        //public virtual List<Car> Cars { get; set; } = new List<Car>();
        //public List<Car> Car { get; set; } = new List<Car>();
        //public List<Place> Place { get; set; } = new List<Place>();
        //public List<Ride> Ride { get; set; } = new List<Ride>();

    }
}
