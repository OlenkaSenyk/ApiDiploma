using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace api_diploma.Data
{
    public class TokenHelper
    {
        public static int GetClaimsFromToken(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(token) as JwtSecurityToken;

            if (jsonToken != null)
            {
                var userIdClaim = jsonToken.Claims.FirstOrDefault(claim => claim.Type == "unique_name");

                if (userIdClaim != null && int.TryParse(userIdClaim.Value, out int userId))
                {
                    return userId;
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                throw new ArgumentException("Invalid token", nameof(token));
            }
        }
    }
}
