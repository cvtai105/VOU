namespace Domain.Entities
{
    public class BrandBranch : BaseEntity
    {
        public Guid BrandId { get; set; }
        public string Title { get; set; } = null!;
        public string Address { get; set; } = null!;
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        // Navigation Property
        public Brand Brand { get; set; } = null!;
    }
}