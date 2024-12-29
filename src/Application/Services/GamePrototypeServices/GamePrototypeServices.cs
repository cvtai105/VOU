using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.GamePrototypeServices
{
    public class GamePrototypeServices : IGamePrototypeServices
    {
        private readonly IApplicationDbContext _context;

        public GamePrototypeServices(IApplicationDbContext context)
        {
            _context = context;
        }

        public Task<List<GamePrototype>> GetActiveGamePrototypesAsync()
        {
            return _context.GamePrototypes.ToListAsync();
        }

        public Task<List<GamePrototype>> GetGamePrototypesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateGamePrototypeStatusAsync(Guid gamePrototypeId, string status)
        {
            throw new NotImplementedException();
        }
    }
    
}