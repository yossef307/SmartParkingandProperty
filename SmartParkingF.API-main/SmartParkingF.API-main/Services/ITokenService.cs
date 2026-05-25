using SmartParkingF.API.Models;

namespace SmartParkingF.API.Services
{
    public interface ITokenService
    {
        string GenerateAccessToken(AppUser user);
        string GenerateRefreshToken();
    }
}