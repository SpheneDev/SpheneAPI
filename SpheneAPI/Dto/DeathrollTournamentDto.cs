using MessagePack;
using Sphene.API.Data;

namespace Sphene.API.Dto;

public enum DeathrollTournamentStage
{
    NotStarted,
    InProgress,
    Completed
}

[MessagePackObject(keyAsPropertyName: true)]
public class DeathrollTournamentMatchDto
{
    public string MatchId { get; set; } = string.Empty;
    public int Round { get; set; }
    public UserData? PlayerA { get; set; }
    public UserData? PlayerB { get; set; }
    public UserData? Winner { get; set; }
    public UserData? Loser { get; set; }
    public bool IsCompleted { get; set; }
}

[MessagePackObject(keyAsPropertyName: true)]
public class DeathrollTournamentStateDto
{
    public string GameId { get; set; } = string.Empty;
    public string TournamentId { get; set; } = string.Empty;
    public DeathrollTournamentStage Stage { get; set; } = DeathrollTournamentStage.NotStarted;
    public int CurrentRound { get; set; }
    public List<UserData> Participants { get; set; } = new();
    public List<DeathrollTournamentMatchDto> Matches { get; set; } = new();
    public UserData? Champion { get; set; }
}