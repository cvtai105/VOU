using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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