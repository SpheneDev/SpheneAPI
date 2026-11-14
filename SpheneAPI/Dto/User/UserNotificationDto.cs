using Sphene.API.Data;
using Sphene.API.Data.Enum;
using MessagePack;

namespace Sphene.API.Dto.User;

/// <summary>
/// One durable notification row for the inbox. ContentKind/ContentId are
/// the generic link target ("event", "post", "comment", "application")
/// resolved by the client when the row is opened.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record UserNotificationDto(
    long Id,
    UserNotificationKind Kind,
    UserData? Actor,
    string? GroupGID,
    string? ContentKind,
    string? ContentId,
    string Title,
    string? Snippet,
    bool IsRead,
    DateTime CreatedAt
);
