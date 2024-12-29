using Application.DTOs.GameDTOs;

namespace Application.Interfaces.GameBehaviors;

public interface IGameCreator
{
    Task<bool> CreateGameAsync(CreateGameParamsBase createGameParams, IApplicationDbContext context);
}