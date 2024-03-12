namespace TbllFantasy.Models;

public class Permission
{
	public int Id { get; set; }
	public string Name { get; set; } = default!;
	public List<Role> Roles { get; set; } = new();
}