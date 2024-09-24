using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace tracer_backend.Utilities;
public class JwtUtilities
{
    // set secret data
    private readonly int _expiryInMinutes;
    private readonly string _secret;

    public JwtUtilities(string secret,int expiryInMinutes)
    {
        //set options
        _expiryInMinutes = expiryInMinutes;
        _secret = secret;
    }

    // public string GenerateToken(string username){
    //     var tokenHandler = new JwtSecurityTokenHandler();
    //     var key = Encoding.ASCII.GetBytes(_secret);
    //     var tokenDescriptor = new SecurityTokenDescriptor;
    //     {
    //         Subject = new ClaimsIdentity(new[]
    //         {
    //             new Claim(ClaimTypes.Name, username)
    //         }),
    //         Expires = DateTime.UtcNow.AddMinutes(_expiryInMinutes);
    //         SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);
    //     };
    //     var token = tokenHandler.CreateToken(tokenDescriptor);
    //     return tokenHandler.WriteToken(token);
    // }

}