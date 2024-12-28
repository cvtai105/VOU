using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Common
{
    public class GameBase
    {
        public Guid Id { get; set; }
        public Guid EventGameId { get; set; }
        public Guid GamePrototypeId { get; set; }

        // Navigation Properties
        public Game EventGame { get; set; } = null!;
        public GamePrototype GamePrototype { get; set; } = null!;
    }
}