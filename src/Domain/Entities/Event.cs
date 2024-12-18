
namespace Domain.Entities
{
    public class Event
    {
        public Guid Id { get; set; }
        public Guid? BrandId { get; set; }
        public Guid? GameId { get; set; }
        public string Name { get; set; } = null!;
        public string ImageUrl { get; set; } = "";
        public DateTime StartAt { get; set; }
        public DateTime EndAt { get; set; }

        // Navigation Properties
        public Brand? Brand { get; set; }
        public Game? Game { get; set; } 
        public ICollection<UserEvent> UserEvents { get; set; } = new List<UserEvent>();
        public ICollection<EventVoucher> EventVouchers { get; set; } = new List<EventVoucher>();
        public ICollection<WishList> WishLists { get; set; } = new List<WishList>();
    }
}