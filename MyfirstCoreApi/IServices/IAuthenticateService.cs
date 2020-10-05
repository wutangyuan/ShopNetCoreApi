using System;
namespace MyfirstCoreApi.IServices
{
    public interface IAuthenticateService
    {

        bool IsAuthenticated(out string token);

        bool RefreshToken(out string newtoken);
    }
}