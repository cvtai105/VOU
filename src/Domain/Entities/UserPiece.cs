using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UserPiece : BaseEntity
    {
        public Guid UserId { get; set; }
        public Guid VoucherPieceId { get; set; }
        public Guid GameId { get; set; }


        // Navigation Properties
        public User User { get; set; } = null!;
        public VoucherPiece VoucherPiece { get; set; } = null!;
        public Game Game { get; set; } = null!;
        
    }
}