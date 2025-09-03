using Sphene.API.Data;
using MessagePack;

namespace Sphene.API.Dto.User;

[MessagePackObject(keyAsPropertyName: true)]
public record CharacterDataAcknowledgmentDto(UserData User, string AcknowledgmentId) : UserDto(User)
{
    public bool Success { get; init; } = true;
    public string? ErrorMessage { get; init; }
    public DateTime AcknowledgedAt { get; init; } = DateTime.UtcNow;
}