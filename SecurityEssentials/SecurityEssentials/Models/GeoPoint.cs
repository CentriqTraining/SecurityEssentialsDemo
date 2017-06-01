using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SecurityEssentials.Models
{
    public class GeoPoint
    {
        [Range(-180, 180)]
        [Required]
        public decimal Longitude { get; set; }
        [Required]
        [Range(-180, 180)]
        public decimal Latitude { get; set; }
        [Required]
        public string Description { get; set; }
    }
}