using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ShakeGame : BaseEntity
    {
        public Guid GameId { get; set; }
        public int VoucherPieceCount { get; set; }

        // Navigation Properties
        public Game Game { get; set; } = null!;
        
    }
}