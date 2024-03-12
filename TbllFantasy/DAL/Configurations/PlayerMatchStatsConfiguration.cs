using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TbllFantasy.Models;

namespace TbllFantasy.DAL.ModelConfigurations;

public class PlayerMatchStatsConfiguration : IEntityTypeConfiguration<PlayerMatchStats>
{
	public void Configure(EntityTypeBuilder<PlayerMatchStats> builder)
	{
		builder.HasOne(s => s.Player).WithMany(p => p.Stats);
		builder.HasOne(s => s.Match).WithMany(m => m.Stats);
	}
}
