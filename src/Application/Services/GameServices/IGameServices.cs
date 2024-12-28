using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.DTOs;
using Application.DTOs.Game;
using Domain.Entities;

namespace Application.Services.GameServices
{
    public interface IGameServices
    {
        //no authentication required
        Task<List<GamePrototype>> GetActiveGames();
        Task<List<Game>> GetEventGamesByGameBaseId(Guid gameBaseId);
        Task<List<Game>> GetEventGamesByEventId(Guid eventId);

        // brand authentication required
        Task GetGameDetail(Guid gameId);
        Task<bool> AddGamesToEventAsync(CreateEventGameRequest param);
        Task<bool> StopEventGame(Guid gameId);

        // admin authentication required
    }
}
