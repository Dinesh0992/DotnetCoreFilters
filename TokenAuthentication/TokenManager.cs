using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace DotnetCoreFilters.TokenAuthentication
{


    public class TokenManager : ITokenManager
    {
        private JwtSecurityTokenHandler tokenHandler;
        private byte[] secretKey;
        // private List<Token> listTokens;
        public TokenManager()
        {
            // listTokens = new List<Token>();
            tokenHandler = new JwtSecurityTokenHandler();
            secretKey = Encoding.ASCII.GetBytes("12345678901234567890123456789012");
        }

        public bool Authenticate(string userName, string password)
        {

            if (!string.IsNullOrWhiteSpace(userName) && !string.IsNullOrWhiteSpace(password)
                && userName.ToLower() == "admin" && password == "password"
            )
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public string NewToken()
        {
            #region old
            /*
             Token token1 = new Token
            {
             Value = Guid.NewGuid().ToString(),
                ExpiryDate = DateTime.Now.AddMinutes(4)
             };
             listTokens.Add(token1);
             return token1; */
            #endregion


            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.Name, "DineshV") }),
                Expires = DateTime.UtcNow.AddMinutes(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(secretKey),
                    SecurityAlgorithms.HmacSha256)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var jwtString = tokenHandler.WriteToken(token);
            return jwtString;

        }
        public ClaimsPrincipal VerifyToken(string Token)
        {

            #region oldcode
            /*
            if (listTokens.Any(x => x.Value == Token && x.ExpiryDate > DateTime.Now))
            {
                return true;
            }
            return false;
            */
            #endregion
            var claims = tokenHandler.ValidateToken(Token   ,
                new TokenValidationParameters
                {
                    ValidateIssuerSigningKey=true,
                    IssuerSigningKey = new SymmetricSecurityKey(secretKey),
                    ValidateLifetime=true,
                    ValidateAudience=false,
                    ValidateIssuer=false,
                    ClockSkew=TimeSpan.Zero
                },out SecurityToken validatedToken
            );
          //  bool value = true;
            return claims;

        }
    }
}
