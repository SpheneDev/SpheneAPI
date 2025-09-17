using Sphene.API.Data;
using MessagePack;

namespace Sphene.API.Dto.User;

public enum AcknowledgmentErrorCode
{
    None = 0,
    Timeout = 1,
    NetworkError = 2,
    InvalidData = 3,
    UserNotFound = 4,
    ServerError = 5,
    RateLimited = 6,
    AuthenticationFailed = 7,
    DataCorrupted = 8,
    InsufficientPermissions = 9,
    ServiceUnavailable = 10,
    HashVerificationFailed = 11
}

[MessagePackObject(keyAsPropertyName: true)]
public record CharacterDataAcknowledgmentDto(UserData User, string AcknowledgmentId) : UserDto(User)
{
    public bool Success { get; init; } = true;
    public string? ErrorMessage { get; init; }
    public AcknowledgmentErrorCode ErrorCode { get; init; } = AcknowledgmentErrorCode.None;
    public DateTime AcknowledgedAt { get; init; } = DateTime.UtcNow;
}