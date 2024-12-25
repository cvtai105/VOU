using Application.Interfaces;
using Application.Services.AuthServices;
using Domain.Constants;
using Domain.Exceptions;
using Microsoft.Extensions.Logging;

namespace Application.Services.User
{
    public record CreateUserParam(string Email, string Password, string Role, string FullName, string Phone);
    public class CreateUserHandler
    {
        private readonly IApplicationDbContext _context;
        private ILogger<CreateUserHandler> _logger;

        public CreateUserHandler(IApplicationDbContext context, IJwtService identityService, ILogger<CreateUserHandler> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<Domain.Entities.User> ExecuteAsync(CreateUserParam param)
        {
            var user = new Domain.Entities.User
            {
                Id = Guid.NewGuid(),
                Email = param.Email,
                FullName = param.FullName,
                Phone = param.Phone,
                Role = param.Role
            };



            user.Hash = param.Password.Hash();

            var check = _context.Users.FirstOrDefault(x => x.Email == param.Email);

            if (check != null)
            {
                throw new Exception("Email already exists");
            }

            //check role
            var validRoles = typeof(Roles)
                .GetFields(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static)
                .Select(f => f.GetValue(null)?.ToString()?.ToLower())
                .ToList();

            for (int i = 0; i < validRoles.Count; i++)
            {
                if (param.Role.ToLower() == validRoles[i]?.ToLower())
                {
                    user.Role = validRoles[i] ?? throw new UnsupportedRoleException(param.Role);
                    break;
                }
                if (i == validRoles.Count - 1)
                {
                    throw new UnsupportedRoleException(param.Role);
                }
            }

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            // user.Hash = "";

            return user;
        }
    }
}