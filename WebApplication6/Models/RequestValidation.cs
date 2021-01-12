using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication6.Models
{
    public class RequestValidation
    {
        [Key]
        public Guid Id { get; set; }

        public Guid Trustee { get; set; }

        public Guid Trusted { get; set; }
        public List<Child> GetSetChild { get; set; } = new List<Child>();

    }
}
