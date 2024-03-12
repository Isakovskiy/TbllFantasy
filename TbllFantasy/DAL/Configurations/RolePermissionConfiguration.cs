using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TbllFantasy.Models;
using TbllFantasy.Services;

namespace TbllFantasy.DAL.Configurations;

public class RolePermissionConfiguration : IEntityTypeConfiguration<RolePermission>
{
	public RolePermissionConfiguration(AuthorizationOptions options)
	{
		_authorizationOptions = options;
	}

	private AuthorizationOptions _authorizationOptions;

	public void Configure(EntityTypeBuilder<RolePermission> builder)
	{
		builder.HasData(GetRolePermissions());
	}

	private RolePermission[] GetRolePermissions() => _authorizationOptions.RolePermissions
		.SelectMany(rps => rps.Permissions
			.Select(p => new RolePermission()
			{
				RoleId = (int)Enum.Parse<RoleType>(rps.Role),
				PermissionId = (int)Enum.Parse<PermissionType>(p)
			})
		).ToArray();
}
