using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TbllFantasy.Models;

namespace TbllFantasy.DAL.Configurations;

public class PermissionConfiguration : IEntityTypeConfiguration<Permission>
{
	public void Configure(EntityTypeBuilder<Permission> builder)
	{
		var permissions = Enum.GetValues<PermissionType>().Select(pt => new Permission() { Id = (int)pt, Name = pt.ToString() });

		builder.HasData(permissions);
	}
}
