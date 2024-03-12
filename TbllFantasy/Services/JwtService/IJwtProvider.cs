using TbllFantasy.Models;

namespace TbllFantasy.Services.JwtService;

public interface IJwtProvider
{
    string GenerateToken(User user);
}
