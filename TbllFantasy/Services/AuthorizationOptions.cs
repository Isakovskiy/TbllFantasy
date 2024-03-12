namespace TbllFantasy.Services;

public class AuthorizationOptions
{
	public RolePermissions[] RolePermissions { get; set; } = { };
}


public class RolePermissions
{
	public string Role { get; set; } = null!;
	public string[] Permissions { get; set; } = { };
}