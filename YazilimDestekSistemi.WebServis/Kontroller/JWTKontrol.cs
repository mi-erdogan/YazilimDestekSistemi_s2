using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace YazilimDestekSistemi.WebServis.Kontroller
{
    public class JWTKontrol
    {
        public static List<Claim> ValidateToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("Jwt:Key");
            var Issuer = "Jwt:Issuer";
            // Token'ı doğrula ve bilgilerini elde et
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidIssuer = Issuer,
                    ValidateAudience = true,
                    ValidAudience = Issuer,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                //var userId = jwtToken.Claims.First(x => x.Type == "id").Value;
                //var username = jwtToken.Claims.First(x => x.Type == "username").Value;

                // TODO: Token'dan elde edilen bilgileri kullanarak API logic'inizi gerçekleştirin.

                return jwtToken.Claims.ToList();
            }
            catch (SecurityTokenException)
            {
                return null;
            }
        }
    }
}