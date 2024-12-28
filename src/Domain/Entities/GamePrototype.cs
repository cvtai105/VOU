using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class GamePrototype : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string Type { get; set; } = null!;
        public string ImageUrl { get; set; } = String.Empty;
        public string GameplayInstruction { get; set; } = String.Empty;
        public bool CanExchangeVoucherPieces { get; set; }
        public string Status { get; set; } = String.Empty;
    }
}