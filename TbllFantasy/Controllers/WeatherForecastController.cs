using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Threading;
using TbllFantasy.DAL;
using TbllFantasy.Models;

namespace TbllFantasy.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class WeatherForecastController : ControllerBase
	{
		private ApplicationDbContext _dbContext;

		public WeatherForecastController(ApplicationDbContext context)
		{
			_dbContext = context;
			Console.WriteLine("hi2");
		}

		[HttpGet, Route("PlayersInit")]
		public int Get()
		{
			var sindicat = new Team() { Name = "Sindikat" };
			var phoenix = new Team() { Name = "Phoenix" };

			var andrew = new Player() { FirstName = "Andrew", LastName = "Isakovskiy", GamePosition = GamePosition.PowerForward, Team = sindicat };
			var kazinak = new Player() { FirstName = "Kazinak", LastName = "Kazinakievich", GamePosition = GamePosition.PointGuard, Team = phoenix };
			
			var match = new Match() { Date = new DateOnly(2024, 03, 02), HomeTeam = sindicat, HomeTeamScore = 32, GuestTeam = phoenix, GuestTeamScore = 72 };

			var stats = new PlayerMatchStats() { Match = match, Player = andrew, Points = 100 };
			var statsk = new PlayerMatchStats() { Match = match, Player = kazinak, Points = 1 };

			_dbContext.Teams.Add(sindicat);
			_dbContext.Teams.Add(phoenix);

			_dbContext.Players.Add(kazinak);
			_dbContext.Players.Add(andrew);

			_dbContext.Matches.Add(match);
			_dbContext.PlayerMatchStats.Add(stats);
			_dbContext.PlayerMatchStats.Add(statsk);

			_dbContext.SaveChanges();

			return 1;
		}

		[HttpGet, Route("Players")]
		public int Get2()
		{
			var s = _dbContext.Players.First();
			_dbContext.SaveChanges();

			return 1;
		}
	}
}