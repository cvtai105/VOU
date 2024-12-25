using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Specifications.BrandSpec
{
    public class BrandSpecParams : BaseSpecParams
    {
        public Guid? UserId { get; set; } 
    }
}