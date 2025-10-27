using MessagePack;
using Sphene.API.Data;

namespace Sphene.API.Dto;

[MessagePackObject(keyAsPropertyName: true)]
public class DeathrollJoinLobbyDto
{
    public string GameId { get; set; } = string.Empty;
    public string PlayerName { get; set; } = string.Empty;
    public UserData? PlayerData { get; set; }
    public DateTime RequestedAt { get; set; } = DateTime.UtcNow;
}

[MessagePackObject(keyAsPropertyName: true)]
public class DeathrollLobbyAnnouncementDto
{
    public string GameId { get; set; } = string.Empty;
    public string LobbyName { get; set; } = string.Empty;
    public UserData Host { get; set; } = new("", null);
    public int CurrentPlayers { get; set; }
    public int MaxPlayers { get; set; }
    public LobbyVisibility Visibility { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}