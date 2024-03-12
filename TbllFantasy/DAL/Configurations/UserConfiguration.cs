using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TbllFantasy.Models;

namespace TbllFantasy.DAL.ModelConfigurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
	public void Configure(EntityTypeBuilder<User> builder)
	{
		builder.HasMany(u => u.Roles)
			.WithMany(u => u.Users)
			.UsingEntity<UserRole>(
				l => l.HasOne<Role>().WithMany().HasForeignKey(r => r.RoleId),
				r => r.HasOne<User>().WithMany().HasForeignKey(r => r.UserId));
	}
}
