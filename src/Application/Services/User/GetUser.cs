using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.UserUsecases
{
    public class GetUserHandler
    {
        private readonly IApplicationDbContext _context;
        public GetUserHandler (IApplicationDbContext context)
        {
            _context = context;
        }
        
        public async Task<User?> GetById(string userId)
        {
            var user = await _context.Users.FindAsync(userId);
            return user;
        }

        public async Task<User?> GetByEmail(string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
            return user;
        }

    }
}