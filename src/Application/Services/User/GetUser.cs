using Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.User
{
    public class GetUserHandler
    {
        private readonly IApplicationDbContext _context;
        public GetUserHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Domain.Entities.User?> GetById(string userId)
        {
            var user = await _context.Users.FindAsync(userId);
            return user;
        }

        public async Task<Domain.Entities.User?> GetByEmail(string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
            return user;
        }

    }
}