using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Application.DTOs
{
    public class BrandRequestDTO
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; } = null!;
        public IFormFile BrandImage { get; set; } = null!;
        public string? Field { get; set; } = null!;
        public string? Phone {get; set; } = null!;
        public string? Email {get; set; } = null!;
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
    }
}