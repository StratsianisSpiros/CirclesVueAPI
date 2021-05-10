using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Circle
    {
        public int Id { get; set; }
        public string UniqueCode { get; set; }
        public string HostUrl { get; set; }
        public DateTime? Date { get; set; }
        public double CoordX { get; set; }
        public double CoordY { get; set; }
        public double Diameter { get; set; }
        public string Color { get; set; }

    }
}
