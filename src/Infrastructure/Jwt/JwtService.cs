using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Jwt;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Identity
{
    public class JwtService : IJwtService
    {
        private readonly JwtOptions _options;

        public JwtService(IOptions<JwtOptions> options)
        {
            _options = options.Value;
        }

        public string GenerateAccessToken(User user)
        {
            return GenerateToken(user, DateTime.UtcNow.AddHours(1));
        }

        public string GenerateRefreshToken(User user)
        {
            return GenerateToken(user, DateTime.UtcNow.AddDays(7));
        }

        public string GenerateToken(User user, DateTime? expires = null)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_options.Secret);

            var claims = new List<Claim>()
            {
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new(JwtRegisteredClaimNames.Email, user.Email),
                new(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim("User Id", user.Id.ToString()),
                new(ClaimTypes.Role, user.Role??string.Empty),
                new Claim("fullname", user.FullName),
                new Claim("picture", user.ImageUrl??string.Empty),
                new Claim("phone", user.Phone),
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = expires,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = _options.Issuer,
                Audience = _options.Audience
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public string GetRolesFromToken(string token)
        {
            throw new NotImplementedException();
        }
        public string GetUserIdFromToken(string token)
        {
            throw new NotImplementedException();
        }

        public string RefreshToken(string refreshToken)
        {
            throw new NotImplementedException();
        }
       
    }
}