using Microsoft.AspNetCore.Authorization;
using TbllFantasy.Models;

namespace TbllFantasy.Services.JwtService;

public class PermissionRequirement : IAuthorizationRequirement
{
	public Permission[] Permissions { get; set; } = { };
}