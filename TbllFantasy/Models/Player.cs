namespace TbllFantasy.Models;

public class Player
{
	public int Id { get; set; }
	public string FirstName { get; set; } = default!;
	public string LastName { get; set; } = default!;

	public Team Team { get; set; } = default!;
	public GamePosition GamePosition { get; set; }
	public List<PlayerMatchStats> Stats { get; set; } = default!;
}

public enum GamePosition
{
	PointGuard,
	ShootingGuard,
	SmallForward,
	PowerForward,
	Center
}

public class Team
{
	public int Id { get; set; }
	public string Name { get; set; } = default!;

	public List<Player> Players { get; set; } = new();

	public List<Match> Matches { get; set; } = new();
}

public class Match
{
	public int Id { get; set; }
	public DateOnly Date { get; set; }

	public Team HomeTeam { get; set; } = default!;
	public int HomeTeamScore { get; set; }

	public Team GuestTeam { get; set; } = default!;
	public int GuestTeamScore { get; set; }

	public List<PlayerMatchStats> Stats { get; set; } = default!;
}


public class PlayerMatchStats
{
	public int Id { get; set; }
	public Player Player { get; set; } = default!;
	public Match Match { get; set; } = default!;

	public int SecondsPlayed { get; set; }

	public int Points { get; set; }

	public int ThreePointersMade { get; set; }
	public int ThreePointersReliased { get; set; }

	public int FreeThrowsMade { get; set; }
	public int FreeThrowsReliased { get; set; }

	public int DefRebounds { get; set; }
	public int AttRebounds { get; set; }

	public int Assists { get; set; }
	public int Steels { get; set; }
	public int Loses { get; set; }
	public int Blocks { get; set; }
	public int Fouls { get; set; }
	public int EnemyFouls { get; set; }
	public int PlusMinus { get; set; }
}
