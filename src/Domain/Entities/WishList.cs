namespace Domain.Entities
{
    public class WishList : BaseEntity
    {
        public Guid EventId { get; set; }
        public Guid UserId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Navigation Properties
        public Event? Event { get; set; } //có thể null, nếu event bị xóa thì vẫn cần để thông báo cho người dùng
        public User User { get; set; } = null!;
    }
}