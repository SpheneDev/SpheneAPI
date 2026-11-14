using Sphene.API.Data;
using MessagePack;

namespace Sphene.API.Dto.Group;

[MessagePackObject(keyAsPropertyName: true)]
public record SyncshellProfileSectionDto(string Title, string Body);

[MessagePackObject(keyAsPropertyName: true)]
public record SyncshellProfileDto(
    string GroupGID,
    string? Tagline,
    string? Description,
    string? BannerImageBase64,
    string? BannerFileName,
    string? BannerContentType,
    long? BannerSize,
    string? AvatarImageBase64,
    string? AvatarFileName,
    string? AvatarContentType,
    long? AvatarSize,
    string? AccentColor,
    List<SyncshellProfileSectionDto>? Sections,
    bool IsEnabled,
    bool ShowOnJoin,
    bool ShowOnAreaBoundJoin,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    /// <summary>File-server media hash - set instead of base64 once migrated.</summary>
    string? BannerMediaHash = null,
    string? AvatarMediaHash = null
);

[MessagePackObject(keyAsPropertyName: true)]
public record SyncshellProfileUpdateDto(
    GroupData Group,
    string? Tagline,
    string? Description,
    string? BannerImageBase64,
    string? BannerFileName,
    string? BannerContentType,
    long? BannerSize,
    string? AvatarImageBase64,
    string? AvatarFileName,
    string? AvatarContentType,
    long? AvatarSize,
    string? AccentColor,
    List<SyncshellProfileSectionDto>? Sections,
    bool IsEnabled,
    bool ShowOnJoin,
    bool ShowOnAreaBoundJoin,
    /// <summary>Hash-based media writes - take precedence over the base64 fields.</summary>
    string? BannerMediaHash = null,
    string? AvatarMediaHash = null,
    /// <summary>Explicit "no banner/avatar" intent - lets the server clear a
    /// stored media hash that a bare null can't express (older clients just
    /// don't model the field).</summary>
    bool ClearBanner = false,
    bool ClearAvatar = false
) : GroupDto(Group);
