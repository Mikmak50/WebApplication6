using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication6.Models
{
    public class UserCar
    {

        public string UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public Guid CarId { get; set; }
        public Car Car { get; set; }

        public bool Owner { get; set; }
    }
}
