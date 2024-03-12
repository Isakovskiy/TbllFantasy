namespace TbllFantasy.Services;

public interface IUsersAuthService
{
	Task<bool> RegisterAsync(string userName, string password);
	Task<string?> LoginAsync(string userName, string password);
}
