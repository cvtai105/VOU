using Domain.Entities;

namespace Domain.Specifications.BrandSpec
{
    public class BrandCountSpecification : BaseSpecification<Brand>
    {
        public BrandCountSpecification(BrandSpecParams brandSpecParams)
            : base(o => o.Name.Contains(brandSpecParams.SearchTerm))
        {
        }
    }
}