using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.DTOs.GameDTOs
{
    public class GameRewardBase
    {
        public Game? Game { get; set; } = null;
        public Guid PlayerId { get; set; }
        public Guid GameId { get; set; }
    }
}