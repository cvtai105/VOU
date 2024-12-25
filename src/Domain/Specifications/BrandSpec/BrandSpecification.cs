using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Specifications.BrandSpec
{
    public class BrandSpecification : BaseSpecification<Brand>
    {
        public BrandSpecification(BrandSpecParams brandSpecParams, bool include = true)
            : base(o => o.Name.Contains(brandSpecParams.SearchTerm))
        {
            if (include)
            {
                AddInclude(o => o.Events);
            }

            ApplyPaging(brandSpecParams.PageSize * (brandSpecParams.PageIndex - 1), brandSpecParams.PageSize);
        } 

        public BrandSpecification(Guid userId) : base(o => o.UserId == userId) 
        {
            
        }
    }
}