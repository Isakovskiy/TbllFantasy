namespace TbllFantasy.Services.JwtService;

public class JwtOptions
{
    public string JwtSecretKey { get; set; } = string.Empty;
    public int ExpireHours { get; set; }
}
