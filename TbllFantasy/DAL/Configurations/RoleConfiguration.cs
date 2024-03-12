using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TbllFantasy.Models;

namespace TbllFantasy.DAL.Configurations;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
	public void Configure(EntityTypeBuilder<Role> builder)
	{
		builder.HasMany(r => r.Permissions)
			.WithMany(p => p.Roles)
			.UsingEntity<RolePermission>(
				l => l.HasOne<Permission>().WithMany().HasForeignKey(rp => rp.PermissionId),
				r => r.HasOne<Role>().WithMany().HasForeignKey(rp => rp.RoleId));

		var roles = Enum.GetValues<RoleType>().Select((r) => new Role() { Id = (int)r, Name = r.ToString() });
		builder.HasData(roles);
	}
}