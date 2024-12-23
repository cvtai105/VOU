using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ExchangePiece : BaseEntity
    {
        public Guid FromUserId { get; set; }
        public Guid? ToUserId { get; set; }
        public Guid? VoucherPieceId { get; set; }

        public string Status { get; set; } = null!; // Pending, Accepted, Rejected
        public DateTime CreatedAt { get; set; } // use for get the time of request piece
        public DateTime UpdatedAt { get; set; } // use for get the time of accept or reject

        // Navigation Properties
        public User FromUser { get; set; } = null!;
        public User ToUser { get; set; } = null!;
        public VoucherPiece VoucherPiece { get; set; } = null!;
    }
}