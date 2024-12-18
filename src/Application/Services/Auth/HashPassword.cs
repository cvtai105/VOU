using System.Security.Cryptography;
using System.Text;

namespace Application.Services.AuthServices;

public static class HashPasswordExtension
{
    public static string Hash(this string password)
    {
        if (string.IsNullOrEmpty(password))
        {
            throw new ArgumentException("Password cannot be null or empty.", nameof(password));
        }
        using var sha256 = SHA256.Create();
        var passwordHash = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
        return Convert.ToBase64String(passwordHash);
    }
}