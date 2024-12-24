
using Domain.Enums;

namespace Domain.Entities
{
    public class Event : BaseEntity
    {
        public Guid? BrandId { get; set; }
        public string Name { get; set; } = null!;
        public string ImageUrl { get; set; } = "";
        public DateTime StartAt { get; set; }
        public DateTime EndAt { get; set; }
        public EventStatus Status { get; set; }

        // Navigation Properties
        public Brand? Brand { get; set; }
        public ICollection<Game> Games { get; set; } = [];
        public ICollection<UserEvent> UserEvents { get; set; } = [];
        public ICollection<EventVoucher> EventVouchers { get; set; } = [];
        public ICollection<WishList> WishLists { get; set; } = [];
    }
}