namespace Domain.Exceptions;

public class UnsupportedRoleException : Exception
{
    public UnsupportedRoleException(string code)
        : base($"Role \"{code}\" is unsupported.")
    {
    }
 
}