using Microsoft.IdentityModel.Tokens;
using MoneyWatcher.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MoneyWatcher.Businness.JwtTools
{
    public class JwtManager : IJwtService
    {

        public JwtToken GenerateToken(User user)
        {
            SecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtConstants.SecretKey));   
            SigningCredentials signingCredentials = new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha256);

            JwtSecurityToken token = new JwtSecurityToken(JwtConstants.Issuer, JwtConstants.Audience,SetClaims(user), DateTime.Now,
                DateTime.Now.AddMinutes(JwtConstants.Expires),signingCredentials );

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            JwtToken jwtToken = new JwtToken();

            jwtToken.Token = handler.WriteToken(token);

            return jwtToken;

        }

        private List<Claim> SetClaims(User user)
        {
            List<Claim> claims = new List<Claim> {
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim(ClaimTypes.Email,user.Email),
            };

            return claims;
        }
    }
}
