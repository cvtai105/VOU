using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class BrandResponseDTO
    {
        public Guid Id { get; set; } 
        public string Name { get; set; } = "";
        public string ImageUrl { get; set; } = null!;
        public string Field { get; set; } = null!;
        public string Phone {get; set; } = null!;
        public string Email {get; set; } = null!;
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}