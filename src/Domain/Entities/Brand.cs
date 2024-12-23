namespace Domain.Entities
{
    public class Brand : BaseEntity
    {
        public Guid? UserId { get; set; }
        public string Name { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public string Field { get; set; } = null!;
        public string Phone {get; set; } = null!;
        public string Email {get; set; } = null!;
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        // Navigation Properties
        public User? User { get; set; } 
        public ICollection<QuestionSet> QuestionSets { get; set; } = [];
        public ICollection<Event> Events { get; set; } = [];
        public ICollection<BrandBranch> BrandBranches { get; set; } = [];
        public ICollection<Voucher> Vouchers { get; set; } = [];
    }
}