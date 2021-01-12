using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication6.Models
{
    public class Ride
    {
        [Key]
        public Guid Id { get; set; }
        public string Description { get; set; }

        [DisplayName("Car")]
        public Guid CarId { get; set; }
        [ForeignKey("CarId")]
        public virtual Car Car { get; set; }
        [DisplayName("Start place")]
        public Guid PlaceStartId { get; set; }
        [ForeignKey("PlaceStartId")]
        public virtual Place PlaceStart { get; set; }
        [DisplayName("End place")]
        public Guid PlaceEndId { get; set; }
        [ForeignKey("PlaceEndId")]
        public virtual Place PlaceEnd { get; set; }
        [DisplayName("Start Date")]
        public DateTime DateStart { get; set; }
        [DisplayName("Start Time")]
        public DateTime TimeStart { get; set; }
        [DisplayName("End Date")]
        public DateTime DateEnd { get; set; }
        [DisplayName("End Time")]
        public DateTime TimeEnd { get; set; }
    }
}
