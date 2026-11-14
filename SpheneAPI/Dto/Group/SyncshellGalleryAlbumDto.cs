using Sphene.API.Data;
using Sphene.API.Data.Enum;
using MessagePack;

namespace Sphene.API.Dto.Group;

/// <summary>
/// A named photo album on a syncshell community page. Albums can be linked to a
/// community event (memories of a past or running event) and pick any uploaded
/// gallery image as their cover.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record SyncshellGalleryAlbumDto(
    long Id,
    string GroupGID,
    string Name,
    string? Description,
    long? LinkedEventId,
    long? CoverImageId,
    int SortOrder,
    DateTime CreatedAt,
    SyncshellGalleryAudience Audience = SyncshellGalleryAudience.Everyone,
    List<string>? AllowedUids = null
);

/// <summary>
/// Album write - <paramref name="Audience"/>/<paramref name="AllowedUids"/>
/// are null for keep-current updates (rename, cover, reorder).
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record SyncshellGalleryAlbumUpdateDto(
    long Id,
    GroupData Group,
    string Name,
    string? Description,
    long? LinkedEventId,
    long? CoverImageId,
    int SortOrder,
    int? Audience = null,
    List<string>? AllowedUids = null
) : GroupDto(Group);
