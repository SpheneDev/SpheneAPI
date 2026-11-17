using Sphene.API.Data;
using MessagePack;

namespace Sphene.API.Dto.User;

/// <summary>One image in a user's profile gallery.</summary>
[MessagePackObject(keyAsPropertyName: true)]
public record UserProfileGalleryImageDto(
    long Id,
    string? ImageBase64,
    string? FileName,
    string? ContentType,
    long? Size,
    string? Caption,
    int SortOrder,
    DateTime CreatedAt,
    long? AlbumId,
    int LikeCount,
    bool LikedByMe
);

/// <summary>A named photo album on a user's profile gallery.</summary>
[MessagePackObject(keyAsPropertyName: true)]
public record UserProfileGalleryAlbumDto(
    long Id,
    string Name,
    int SortOrder,
    int ImageCount
);

/// <summary>One blog post on a user's profile.</summary>
[MessagePackObject(keyAsPropertyName: true)]
public record UserProfileBlogPostDto(
    long Id,
    string Title,
    string? Body,
    bool Pinned,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    /// <summary><see cref="Sphene.API.Data.Enum.ContentPublishStatus"/> as int.</summary>
    int Status = 0,
    /// <summary><see cref="Sphene.API.Data.Enum.BlogVisibilityScope"/> as int.</summary>
    int VisibilityScope = 0,
    DateTime? ScheduledForUtc = null,
    List<string>? CoAuthorUids = null,
    /// <summary>Denormalized comment count + owner/platform thread lock (Phase 4).</summary>
    int CommentCount = 0,
    bool CommentsLocked = false,
    /// <summary>Optional community-media hash of the entry's cover image.</summary>
    string? CoverMediaHash = null,
    /// <summary>Unique non-owner viewers - deduplicated on
    /// (post, viewer) server-side; the owner's own reads never count.</summary>
    int ViewCount = 0
);

/// <summary>
/// On-demand extras for the profile page - heavier content (gallery images,
/// blog posts) fetched lazily instead of riding the hot <see cref="UserProfileDto"/>.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record UserProfileExtrasDto(
    UserData User,
    List<UserProfileGalleryImageDto>? Gallery,
    List<UserProfileBlogPostDto>? Blog,
    List<UserProfileGalleryAlbumDto>? Albums = null
) : UserDto(User);

/// <summary>Upserts a profile gallery image; Id 0 creates a new image.</summary>
[MessagePackObject(keyAsPropertyName: true)]
public record UserProfileGalleryImageUpdateDto(
    UserData User,
    long Id,
    string? ImageBase64,
    string? FileName,
    string? ContentType,
    long? Size,
    string? Caption,
    int SortOrder,
    long? AlbumId = null
) : UserDto(User);

/// <summary>Upserts a profile gallery album; Id 0 creates a new album.</summary>
[MessagePackObject(keyAsPropertyName: true)]
public record UserProfileGalleryAlbumUpdateDto(
    UserData User,
    long Id,
    string Name,
    int SortOrder
) : UserDto(User);

/// <summary>Toggles the caller's like on someone else's profile photo.</summary>
[MessagePackObject(keyAsPropertyName: true)]
public record UserProfileGalleryImageLikeDto(
    UserData User,
    long ImageId
) : UserDto(User);

/// <summary>Resulting like state after a toggle - count plus caller state.</summary>
[MessagePackObject(keyAsPropertyName: true)]
public record UserProfileGalleryImageLikeResultDto(
    long ImageId,
    bool LikedByMe,
    int LikeCount
);

/// <summary>Upserts a blog post; Id 0 creates a new post.</summary>
[MessagePackObject(keyAsPropertyName: true)]
public record UserProfileBlogPostUpdateDto(
    UserData User,
    long Id,
    string Title,
    string? Body,
    bool Pinned,
    /// <summary>Requested intent - effective status is computed server-side.</summary>
    int? StatusIntent = null,
    DateTime? ScheduledForUtc = null,
    int? VisibilityScope = null,
    List<string>? CoAuthorUids = null,
    /// <summary>null keeps the stored cover, "" clears it, a hash replaces it.</summary>
    string? CoverMediaHash = null
) : UserDto(User);

/// <summary>Deletes a profile extra (gallery image or blog post) by id.</summary>
[MessagePackObject(keyAsPropertyName: true)]
public record UserProfileItemDeleteDto(
    UserData User,
    long Id
) : UserDto(User);
