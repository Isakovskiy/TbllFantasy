namespace TbllFantasy.Models;

public class Role
{
	public int Id { get; set; }
	public string Name { get; set; } = default!;
	public List<Permission> Permissions { get; set; } = new();
	public List<User> Users { get; set; } = new();
}