using MessagePack;
using Sphene.API.Data;

namespace Sphene.API.Dto;

public enum LobbyVisibility
{
    Private,
    Public
}

[MessagePackObject(keyAsPropertyName: true)]
public class DeathrollInvitationDto
{
    public string InvitationId { get; set; } = string.Empty;
    public UserData Sender { get; set; } = new("", null);
    public UserData Recipient { get; set; } = new("", null);
    public DateTime SentAt { get; set; } = DateTime.UtcNow;
    public DateTime ExpiresAt { get; set; } = DateTime.UtcNow.AddMinutes(5);
    public string GameId { get; set; } = string.Empty;
    public int MaxPlayers { get; set; } = 2;
    public string Message { get; set; } = "You've been invited to a Deathroll game!";
}

[MessagePackObject(keyAsPropertyName: true)]
public class DeathrollInvitationResponseDto
{
    public string InvitationId { get; set; } = string.Empty;
    public UserData Responder { get; set; } = new("", null);
    public bool Accepted { get; set; }
    public DateTime RespondedAt { get; set; } = DateTime.UtcNow;
    public string? DeclineReason { get; set; }
}

[MessagePackObject(keyAsPropertyName: true)]
public class DeathrollGameStateDto
{
    public string GameId { get; set; } = string.Empty;
    public DeathrollGameState State { get; set; }
    public List<UserData> Players { get; set; } = new();
    public UserData? CurrentPlayer { get; set; }
    public int CurrentRollMax { get; set; } = 1000;
    public int LastRoll { get; set; }
    public UserData? Winner { get; set; }
    public UserData? Loser { get; set; }
    public DateTime? GameStartTime { get; set; }
    public DateTime? GameEndTime { get; set; }
    public DateTime LastRollTime { get; set; }
    public List<string> RollHistory { get; set; } = new();
    
    // Players currently marked as Ready in lobby
    public List<UserData>? ReadyPlayers { get; set; }
    
    // New lobby-related properties
    public string LobbyName { get; set; } = string.Empty;
    public UserData? Host { get; set; }
    public int MaxPlayers { get; set; } = 8;
    public LobbyVisibility Visibility { get; set; } = LobbyVisibility.Private;
    public DateTime? LobbyCreatedTime { get; set; }
}

public enum DeathrollGameState
{
    Inactive,
    LobbyCreated,        // New: Lobby exists but waiting for players
    WaitingForPlayers,   // Lobby is open and accepting players
    ReadyToStart,        // Enough players joined, waiting for host to start
    InProgress,          // Game is actively running
    Finished
}