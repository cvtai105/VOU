namespace Domain.Entities
{
    public class EventVoucher : BaseEntity
    {
        public Guid EventId { get; set; }
        public Guid VoucherId { get; set; }
        public int Quantity { get; set; }

        // Navigation Properties
        public Event Event { get; set; } = null!;
        public Voucher Voucher { get; set; } = null!;
    }
}