namespace Domain.Entities
{
    public class Voucher : BaseEntity
    {
        public Guid BrandId { get; set; }
        public string Code { get; set; } = null!;
        public string QrCodeUrl { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public int Value { get; set; }
        public string Description { get; set; } = null!;
        public DateTime ExpiredAt { get; set; }
        public int Quantity { get; set; }
        public int PieceCount { get; set; }     //for game that need to collect pieces, require brand to set this value

        // Navigation Properties
        public Brand Brand { get; set; } = null!;
        public ICollection<UserVoucher> UserVouchers { get; set; } = new List<UserVoucher>();
        public ICollection<EventVoucher> EventVouchers { get; set; } = new List<EventVoucher>();
    }
}