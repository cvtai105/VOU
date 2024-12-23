
namespace Domain.Entities
{
    public class Game : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string Type { get; set; } = null!;
        public string ImageUrl { get; set; } = String.Empty;
        public string GameplayInstruction { get; set; } = String.Empty;
        public bool CanExchangeVoucherPieces { get; set; } 
        public string Status { get; set; } = String.Empty;
        public Guid EventId { get; set; }

        // Navigation Property
        public Event Event { get; set; } = null!;       //1 game belongs to 1 event

    }
}