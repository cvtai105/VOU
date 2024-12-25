namespace Domain.Entities
{
    public class VoucherPiece : BaseEntity
    {
        public Guid VoucherId { get; set; }
        public int PieceNumber { get; set; }
        public string ImageUrl { get; set; } = null!;

        // Navigation Properties
        public Voucher Voucher { get; set; } = null!;
    }
}