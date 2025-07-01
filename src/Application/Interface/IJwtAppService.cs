namespace MetroPass.Application.Interface
{
    public interface IJwtService
    {
        string GenerateToken(string account);
    }
}