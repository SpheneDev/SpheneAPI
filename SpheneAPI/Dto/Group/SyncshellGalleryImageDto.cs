using Sphene.API.Data;
using Sphene.API.Data.Enum;
using MessagePack;

namespace Sphene.API.Dto.Group;

[MessagePackObject(keyAsPropertyName: true)]
public record SyncshellGalleryImageDto(
    long Id,
    string GroupGID,
    string? ImageBase64,
    string? FileName,
    string? ContentType,
    long? Size,
    string? Caption,
    int SortOrder,
    DateTime CreatedAt,
    long? AlbumId,
    string? UploadedByUid,
    SyncshellGalleryImageStatus Status,
    int LikeCount = 0,
    bool LikedByMe = false,
    SyncshellGalleryAudience Audience = SyncshellGalleryAudience.Everyone,
    List<string>? AllowedUids = null,
    /// <summary>Content-addressed media hash - set instead of
    /// <see cref="ImageBase64"/> once the payload lives on the file server.</summary>
    string? ImageMediaHash = null
);

/// <summary>
/// Gallery like toggle - the request carries group + image id (Liked/Count
/// ignored), the response returns the resulting state for that image.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record SyncshellGalleryImageLikeDto(
    GroupData Group,
    long ImageId,
    bool Liked,
    int Count
) : GroupDto(Group);

/// <summary>
/// Image write - <paramref name="ImageBase64"/> travels only on upload.
/// <paramref name="Audience"/>/<paramref name="AllowedUids"/> are null for
/// keep-current updates (e.g. album assignment) so partial callers cannot
/// wipe a configured audience.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record SyncshellGalleryImageUpdateDto(
    long Id,
    GroupData Group,
    string? ImageBase64,
    string? FileName,
    string? ContentType,
    long? Size,
    string? Caption,
    int SortOrder,
    long? AlbumId,
    int? Audience = null,
    List<string>? AllowedUids = null,
    string? ImageMediaHash = null
) : GroupDto(Group);
