
namespace Domain.Entities
{
    public class Game : BaseEntity
    {
        public Guid EventId { get; set; }
        public Guid? GamePrototypeId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Status { get; set; } = null!; // Pending, Running, Finished
        
        // Navigation Property
        public Event Event { get; set; } = null!;       
        public GamePrototype? GamePrototype { get; set; } = null!;  
    }
}