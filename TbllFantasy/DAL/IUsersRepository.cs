using TbllFantasy.Models;

namespace TbllFantasy.DAL;

public interface IUsersRepository
{
	Task AddUserAsync(User user);
	Task<User?> GetUserAsync(Guid userId);
	Task<User?> GetUserAsync(string userName);
}
