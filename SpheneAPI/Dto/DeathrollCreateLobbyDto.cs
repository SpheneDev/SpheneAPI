using MessagePack;
using Sphene.API.Data;

namespace Sphene.API.Dto;

[MessagePackObject(keyAsPropertyName: true)]
public class DeathrollCreateLobbyDto
{
    public string LobbyName { get; set; } = string.Empty;
    public UserData Host { get; set; } = new("", null);
    public int MaxPlayers { get; set; } = 8;
    public LobbyVisibility Visibility { get; set; } = LobbyVisibility.Private;
    public DeathrollGameMode GameMode { get; set; } = DeathrollGameMode.Standard;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}