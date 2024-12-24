using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class EventRequestDTO
    {
        public Guid? Id { get; set; }
        public string Name { get; set; } = "";
        public Guid BrandId { get; set; }
        public Guid? GameId { get; set; }
        public DateTime StartAt { get; set; }
        public DateTime EndAt { get; set; }
        public int Status { get; set; }
        public IFormFile? Picture { get; set; }
    }
}
