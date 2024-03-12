using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Net;
using TbllFantasy.DAL.Configurations;
using TbllFantasy.DAL.ModelConfigurations;
using TbllFantasy.Models;
using TbllFantasy.Services;

namespace TbllFantasy.DAL;

public class ApplicationDbContext : DbContext
{
	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IOptions<AuthorizationOptions> authOptions) : base(options)
	{
		_authOptions = authOptions;
	}

	private IOptions<AuthorizationOptions> _authOptions;

	public DbSet<Player> Players { get; set; } = null!;
	public DbSet<Team> Teams { get; set; } = null!;
	public DbSet<Match> Matches { get; set; } = null!;
	public DbSet<PlayerMatchStats> PlayerMatchStats { get; set; } = null!;
	public DbSet<User> Users { get; set; } = null!;

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfiguration(new PlayerConfiguration());
		modelBuilder.ApplyConfiguration(new TeamConfiguration());
		modelBuilder.ApplyConfiguration(new MatchConfiguration());
		modelBuilder.ApplyConfiguration(new PlayerMatchStatsConfiguration());
		modelBuilder.ApplyConfiguration(new UserConfiguration());
		modelBuilder.ApplyConfiguration(new RoleConfiguration());
		modelBuilder.ApplyConfiguration(new PermissionConfiguration());
		modelBuilder.ApplyConfiguration(new RolePermissionConfiguration(_authOptions.Value));
	}
} 