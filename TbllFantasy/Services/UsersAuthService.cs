using TbllFantasy.DAL;
using TbllFantasy.Models;
using TbllFantasy.Services.JwtService;

namespace TbllFantasy.Services;

public class UsersAuthService : IUsersAuthService
{
	public UsersAuthService(IUsersRepository usersRepository, IPasswordHasher passwordHasher, IJwtProvider jwtProvider)
	{
		_usersRepository = usersRepository;
		_passwordHasher = passwordHasher;
		_jwtProvider = jwtProvider;
	}

	private IUsersRepository _usersRepository;
	private IPasswordHasher _passwordHasher;
	private IJwtProvider _jwtProvider;

	public async Task<bool> RegisterAsync(string userName, string password)
	{
		if (await _usersRepository.GetUserAsync(userName) != null)
		{
			return false;
		}

		var hashedPassword = _passwordHasher.GenerateHash(password);
		var user = new User() { Id = Guid.NewGuid(), UserName = userName, PasswordHash = hashedPassword };
		await _usersRepository.AddUserAsync(user);
		return true;
	}

	public async Task<string?> LoginAsync(string userName, string password)
	{
		var user = await _usersRepository.GetUserAsync(userName);

		if (user == null || !_passwordHasher.Verify(password, user.PasswordHash))
		{
			return null;
		}

		return _jwtProvider.GenerateToken(user);
	}
}
