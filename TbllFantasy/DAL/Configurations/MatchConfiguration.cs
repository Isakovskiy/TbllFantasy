using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TbllFantasy.Models;

namespace TbllFantasy.DAL.ModelConfigurations;


public class MatchConfiguration : IEntityTypeConfiguration<Match>
{
	public void Configure(EntityTypeBuilder<Match> builder)
	{
		builder.HasOne(m => m.HomeTeam).WithMany(t => t.Matches);
	}
}
