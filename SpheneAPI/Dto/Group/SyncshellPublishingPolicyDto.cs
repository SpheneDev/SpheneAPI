using Sphene.API.Data;
using Sphene.API.Data.Enum;
using MessagePack;

namespace Sphene.API.Dto.Group;

/// <summary>
/// Per-syncshell publishing policy - which publish mode applies per content
/// kind and which staff bits bypass the review queue.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record SyncshellPublishingPolicyDto(
    GroupData Group,
    SyncshellPublishMode NewsMode = SyncshellPublishMode.ApprovalRequired,
    SyncshellPublishMode GalleryMode = SyncshellPublishMode.ApprovalRequired,
    /// <summary><see cref="SyncshellStaffPermission"/> mask - holders publish
    /// directly even when the mode is <see cref="SyncshellPublishMode.ApprovalRequired"/>.</summary>
    long DirectPublishBits = 0,
    /// <summary>Schema version inside the stored JSON · unknown versions fall
    /// back to safe defaults server-side.</summary>
    int Version = 2,
    /// <summary>Publish mode for member-created events - defaults to
    /// <see cref="SyncshellPublishMode.StaffOnly"/> which preserves the
    /// pre-Phase-3 staff-only event creation.</summary>
    SyncshellPublishMode EventsMode = SyncshellPublishMode.StaffOnly,
    /// <summary>Per-shell comment write policy - defaults to Open (members may comment).</summary>
    CommunityCommentsMode CommentsMode = CommunityCommentsMode.Open
) : GroupDto(Group);

/// <summary>Server-resolved snapshot of an entity reference token.</summary>
[MessagePackObject(keyAsPropertyName: true)]
public record EntityCardDto(
    EntityRefKind Kind,
    /// <summary>Echoed token (<c>@uid</c>, <c>#gid</c>, <c>event:1</c>...) for client chips.</summary>
    string Token,
    bool Resolved,
    string? Title,
    string? Snippet,
    /// <summary>Opaque client navigation key (e.g. <c>user:{uid}</c>, <c>community:{gid}</c>).</summary>
    string? NavKey,
    string? AvatarHash = null
);

/// <summary>One pending item in the community review queue.</summary>
[MessagePackObject(keyAsPropertyName: true)]
public record CommunityReviewItemDto(
    /// <summary>"news" | "gallery"</summary>
    string ContentKind,
    long ContentId,
    string GroupGID,
    string Title,
    string? Snippet,
    UserData? Author,
    DateTime SubmittedAt
);

[MessagePackObject(keyAsPropertyName: true)]
public record CommunityReviewQueueDto(
    GroupData Group,
    List<CommunityReviewItemDto> Items
) : GroupDto(Group);

/// <summary>Staff decision on a queued item.</summary>
[MessagePackObject(keyAsPropertyName: true)]
public record CommunityReviewDecisionDto(
    GroupData Group,
    string ContentKind,
    long ContentId,
    bool Approve,
    string? Note = null
) : GroupDto(Group);

/// <summary>Upload channel info for community media - null BaseUrl = feature not configured.</summary>
[MessagePackObject(keyAsPropertyName: true)]
public record CommunityMediaUploadInfoDto(
    bool Configured,
    string? UploadUrlTemplate,
    long MaxBytes,
    List<string> AllowedContentTypes,
    /// <summary>GET template for rendering - <c>{base}/community/media/{hash}</c>.</summary>
    string? FetchUrlTemplate = null
);
