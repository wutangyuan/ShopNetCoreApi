using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MyfirstCoreApi.IServices;
using MyfirstCoreApi.Models;

namespace MyfirstCoreApi.Services
{
    public class TokenAuthenticationService: IAuthenticateService
    {
        private readonly JwtTokenManagerMent _tokenment;
        public TokenAuthenticationService(IOptions<JwtTokenManagerMent>tokenment)
        {
            _tokenment = tokenment.Value;
        }

        public bool IsAuthenticated(out string token)
        {
            token = string.Empty;
            var calaims = new[]
            {
                new Claim(ClaimTypes.Name,"wutangyuan")
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenment.Secret));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var jwttoken = new JwtSecurityToken(_tokenment.Issuer, _tokenment.Audience, calaims, expires: DateTime.Now.AddMinutes(_tokenment.AccessExpiration),
                signingCredentials: credentials);
            token = new JwtSecurityTokenHandler().WriteToken(jwttoken);
            return true;
        }

        /// <summary>
        ///增加刷新token的方法
        /// </summary>
        /// <param name="newtoken"></param>
        /// <returns></returns>
        public bool RefreshToken(out string newtoken)
        {
            //newtoken = string.Empty;
            return IsAuthenticated(out newtoken);
        }
    }
}
