using Microsoft.EntityFrameworkCore;
using TbllFantasy.Models;

namespace TbllFantasy.DAL;

public class UsersRepository : IUsersRepository
{
	public UsersRepository(ApplicationDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	private ApplicationDbContext _dbContext;

	public async Task AddUserAsync(User user)
	{
		_dbContext.Users.Add(user);
		await _dbContext.SaveChangesAsync();
	}

	public async Task<User?> GetUserAsync(Guid userId) => await _dbContext.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == userId);
	public async Task<User?> GetUserAsync(string userName) => await _dbContext.Users.AsNoTracking().FirstOrDefaultAsync(u => u.UserName == userName);
}
