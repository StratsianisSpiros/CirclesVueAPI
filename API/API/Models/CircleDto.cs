using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class CircleDto
    {
        [Required]
        public string UniqueCode { get; set; }
        [Required]
        public string HostUrl { get; set; }
        [Required]
        public DateTime? Date { get; set; }
        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Value must be greater than zero")]
        public double CoordX { get; set; }
        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Value must be greater than zero")]
        public double CoordY { get; set; }
        [Required]
        public double Diameter { get; set; }
        [Required]
        public string Color { get; set; }
    }
}
