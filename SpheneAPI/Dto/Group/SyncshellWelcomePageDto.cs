using Sphene.API.Data;
using MessagePack;

namespace Sphene.API.Dto.Group;

[MessagePackObject(keyAsPropertyName: true)]
public record SyncshellWelcomePageDto(
    string GroupGID,
    string? WelcomeText,
    string? WelcomeImageBase64,
    string? ImageFileName,
    string? ImageContentType,
    long? ImageSize,
    bool IsEnabled,
    bool ShowOnJoin,
    bool ShowOnAreaBoundJoin,
    DateTime CreatedAt,
    DateTime UpdatedAt
);

[MessagePackObject(keyAsPropertyName: true)]
public record SyncshellWelcomePageUpdateDto(
    GroupData Group,
    string? WelcomeText,
    string? WelcomeImageBase64,
    string? ImageFileName,
    string? ImageContentType,
    long? ImageSize,
    bool IsEnabled,
    bool ShowOnJoin,
    bool ShowOnAreaBoundJoin
) : GroupDto(Group);