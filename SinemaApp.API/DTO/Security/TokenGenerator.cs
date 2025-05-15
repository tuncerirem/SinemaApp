using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SinemaApp.API.Security
{
    
    public class TokenGenerator
    {
        private readonly IConfiguration _configuration;

        public TokenGenerator(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public JWT GenerateToken(string userName, string role)
        {
            var jwtSettings = _configuration.GetSection("Jwt");

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, userName),
                new Claim(ClaimTypes.Role, role)
            };

            var expireMinutes = Convert.ToInt32(jwtSettings["ExpireMinutes"]);

            var token = new JwtSecurityToken(
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(60),
                signingCredentials: credentials
            );

            var dateUTC = DateTime.UtcNow.AddSeconds(60);
            var dateTR = DateTime.Now.AddSeconds(60);

            long timestamputv = ((DateTimeOffset)dateUTC).ToUnixTimeSeconds(); //convet datetime to timestamp
            long timestamptr = ((DateTimeOffset)dateTR).ToUnixTimeSeconds(); //convet datetime to timestamp

            return new JWT
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = token.ValidTo
            };
        }
    }
}
