using Domain.Entities;

namespace Application.DTOs
{
    public class EventResponseDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = "";
        public string ImageUrl { get; set; } = "";
        public DateTime StartAt { get; set; }
        public DateTime EndAt { get; set; }
        public int Status { get; set; }
        public Brand? Brand { get; set; }
    }
}
