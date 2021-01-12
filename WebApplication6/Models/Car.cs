using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication6.Models
{
    public class Car
    {
        [Key]
        public Guid Id { get; set; }

        [DisplayName("Passengers Count")]
        [DefaultValue(0)]
        public int PassengersCount { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Range(1,10,ErrorMessage ="Min 1, Max 10")]
        public int Seats { get; set; }
        public ICollection<UserCar> UsersCars { get; set; } = new List<UserCar>();
    }
}
