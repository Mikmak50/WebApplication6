using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication6.Models.ViewModels
{
    public class RideVM
    {
        public Ride Ride { get; set; }

        public IEnumerable<SelectListItem> CarSelectList { get; set; }
        public IEnumerable<SelectListItem> PlaceStartSelectList { get; set; }
        public IEnumerable<SelectListItem> PlaceEndSelectList { get; set; }
    }
}
