using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.GameDTOs;

namespace Application.Interfaces.GameBehaviors
{
    public interface IGameRewarder
    {
        Task<GameRewardBase> RewardPrizesAsync(Guid playerId, Guid gameId, IApplicationDbContext context);
    }
}