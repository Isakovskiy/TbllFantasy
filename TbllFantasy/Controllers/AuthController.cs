using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TbllFantasy.Models;
using TbllFantasy.Services;

namespace TbllFantasy.Controllers;

public class AuthController : ControllerBase
{
	public AuthController(IUsersAuthService authService)
	{
		_authService = authService;
	}

	private IUsersAuthService _authService;

	[HttpPost, Route("register")]
	public async Task<IActionResult> Register([FromBody] UserDto user)
	{
		if(await _authService.RegisterAsync(user.userName, user.password))
		{
			return Ok();
		}
		
		return BadRequest();
		
	}

	[HttpPost, Route("login")]
	public async Task<IActionResult> Login([FromBody] UserDto user)
	{
		var token = await _authService.LoginAsync(user.userName, user.password);

		if(token != null)
		{
			HttpContext.Response.Cookies.Append("useless-cookie", token);
			return Ok();
		}
		
		return BadRequest();
	}

	[HttpGet, Route("getsmtg")]
	[Authorize()]
	public async Task<IActionResult> Get()
	{
		return Ok();

	}

}