using Domain.Enums;

namespace Domain.Specifications.EventSpec
{
    public class EventSpecParams : BaseSpecParams
    {
        public String? BrandId { get; set; } = "";
        public String? BrandName { get; set; } = "";
        public BrandField? Field { get; set; } = BrandField.All;
    }
}
