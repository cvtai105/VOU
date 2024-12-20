using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UserEvent : BaseEntity
    {
        public Guid EventId { get; set; }
        public Guid UserId { get; set; }
        public int TurnsLeft { get; set; }

        // Navigation Properties
        public Event Event { get; set; } = null!;
        public User User { get; set; } = null!;
    }
}