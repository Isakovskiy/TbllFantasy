using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TbllFantasy.DAL;
using TbllFantasy.Services;
using TbllFantasy.Services.JwtService;

namespace TbllFantasy;

public static class ServiceRegistry
{ 
	public static void Register(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddSingleton<IPasswordHasher, PasswordHasher>();
		services.AddScoped<IUsersRepository, UsersRepository>();
		services.AddScoped<IUsersAuthService, UsersAuthService>();
		services.AddScoped<IJwtProvider, JwtProvider>();

		services.Configure<JwtOptions>(configuration.GetSection(nameof(JwtOptions)));
		services.Configure<AuthorizationOptions>(configuration.GetSection(nameof(AuthorizationOptions)));
	}

	public static void RegistryDbContext<DbCtx>(this IServiceCollection services, IConfiguration configuration) where DbCtx : DbContext
	{
		services.AddDbContext<DbCtx>(options => options.UseNpgsql(configuration["ConnectionString"]));
	}

	public static void AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
	{
		var jwtOptions = configuration.GetSection(nameof(JwtOptions)).Get<JwtOptions>();

		services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
			.AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
			{
				options.TokenValidationParameters = new()
				{
					ValidateLifetime = true,
					ValidateIssuerSigningKey = true,
					IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.JwtSecretKey)),
					ValidateIssuer = false,
					ValidateAudience = false,
				};

				options.Events = new JwtBearerEvents()
				{
					OnMessageReceived = (context) =>
					{
						context.Token = context.Request.Cookies["useless-cookie"];
						return Task.CompletedTask;
					}
				};
			});
	}
}