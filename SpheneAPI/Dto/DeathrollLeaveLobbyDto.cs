using MessagePack;
using Sphene.API.Data;

namespace Sphene.API.Dto;

[MessagePackObject(keyAsPropertyName: true)]
public class DeathrollLeaveLobbyDto
{
    public string GameId { get; set; } = string.Empty;
    public string PlayerName { get; set; } = string.Empty;
    public UserData? PlayerData { get; set; }
    public DateTime LeftAt { get; set; } = DateTime.UtcNow;
}