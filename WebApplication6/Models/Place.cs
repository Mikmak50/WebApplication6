using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication6.Models
{
    public class Place
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Street { get; set; }
        public string Country { get; set; }
        public string City { get; set; }

        [DisplayName("Postal Code")]
        public string PostalCode { get; set; }
    }
}
