namespace Domain.Entities
{
    public class User : BaseEntity
    {
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string ImageUrl { get; set; } = "";
        public string Hash { get; set; } = null!;
        public string Role { get; set; } = null!;
        public string Phone { get; set; } = null!;

        public ICollection<Brand>? Brands { get; set; }
        public ICollection<UserEvent> UserEvents { get; set; } = new List<UserEvent>();
        public ICollection<UserVoucher> UserVouchers { get; set; } = new List<UserVoucher>();
        public ICollection<WishList> WishLists { get; set; } = new List<WishList>();
    }
}