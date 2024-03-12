using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TbllFantasy.Models;

namespace TbllFantasy.Services.JwtService;

public class JwtProvider : IJwtProvider
{
    public JwtProvider(IOptions<JwtOptions> options)
    {
        _options = options.Value;
    }

    private JwtOptions _options;

    public string GenerateToken(User user)
    {
        var claims = new Claim[]
        {
            new(CustomClaims.UserId, user.Id.ToString()),
        };

        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.JwtSecretKey)),
            SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            claims: claims,
            signingCredentials: signingCredentials,
            expires: DateTime.UtcNow.AddHours(_options.ExpireHours)
            );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}