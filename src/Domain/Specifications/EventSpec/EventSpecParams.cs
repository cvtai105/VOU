using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Specifications.EventSpec
{
    public class EventSpecParams : BaseSpecParams
    {
        public String? BrandId { get; set; } = "";
        public String? BrandName { get; set; } = "";
        public BrandField? Field { get; set; } = BrandField.All;
    }
}
