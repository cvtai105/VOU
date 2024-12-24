using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Specifications.WishlistSpec
{
    public class WishlistSpecification : BaseSpecification<WishList>
    {
        public WishlistSpecification(Guid eventId, Guid userId)
            : base(o => o.UserId == userId && o.EventId == eventId)
        {
            AddInclude(o => o.Event);
        }
    }
}
