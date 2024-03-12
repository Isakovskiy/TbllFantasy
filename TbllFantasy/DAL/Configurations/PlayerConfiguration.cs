using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TbllFantasy.Models;

namespace TbllFantasy.DAL.ModelConfigurations;

public class PlayerConfiguration : IEntityTypeConfiguration<Player>
{
	public void Configure(EntityTypeBuilder<Player> builder)
	{
	}
}