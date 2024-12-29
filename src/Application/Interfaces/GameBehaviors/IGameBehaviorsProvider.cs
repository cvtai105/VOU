using Application.DTOs.GameDTOs;

namespace Application.Interfaces.GameBehaviors;

public interface IGameBehaviorsProvider : IGameCreator, IGameRewarder
{
    Task<List<GameRewardBase>> GetPlayerRewardByGame(Guid gameId, Guid playerId, IApplicationDbContext context);
}