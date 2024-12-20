using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class EventResponseDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = "";
        public string ImageUrl { get; set; } = "";
        public DateTime StartAt { get; set; }
        public DateTime EndAt { get; set; }
        public Brand? Brand { get; set; }
        public Game? Game { get; set; }
    }
}
