
namespace Domain.Entities
{
    public class Game : BaseEntity
    {
        public Guid EventId { get; set; }
        public Guid? GamePrototypeId { get; set; }
        public string Type { get; set; } = null!; 
        
        // Navigation Property
        public Event Event { get; set; } = null!;       
        public GamePrototype? GamePrototype { get; set; } = null!;  
    }
}