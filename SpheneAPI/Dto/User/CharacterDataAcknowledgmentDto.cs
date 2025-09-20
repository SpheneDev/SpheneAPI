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
public record CharacterDataAcknowledgmentDto(UserData User, string DataHash) : UserDto(User)
{
    public bool Success { get; init; } = true;
    public string? ErrorMessage { get; init; }
    public AcknowledgmentErrorCode ErrorCode { get; init; } = AcknowledgmentErrorCode.None;
    public DateTime AcknowledgedAt { get; init; } = DateTime.UtcNow;
}

[MessagePackObject(keyAsPropertyName: true)]
public record CharacterDataHashValidationRequest
{
    public string UserUID { get; init; } = string.Empty;
    public string DataHash { get; init; } = string.Empty;
}

[MessagePackObject(keyAsPropertyName: true)]
public record CharacterDataHashValidationResponse
{
    public bool IsValid { get; init; }
    public string? CurrentHash { get; init; }
}