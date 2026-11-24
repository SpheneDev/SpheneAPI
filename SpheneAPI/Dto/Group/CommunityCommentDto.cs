using Sphene.API.Data;
using Sphene.API.Data.Enum;
using MessagePack;

namespace Sphene.API.Dto.Group;

/// <summary>One comment row as served to a viewer - moderation fields
/// populated for staff only.</summary>
[MessagePackObject(keyAsPropertyName: true)]
public record CommunityCommentDto(
    long Id,
    CommentTargetKind TargetKind,
    long TargetId,
    string? GroupGID,
    UserData? Author,
    string? Body,
    CommentState State,
    long? ParentId,
    long? RootId,
    int ReplyCount,
    DateTime CreatedAt,
    DateTime? EditedAt,
    bool IsMine,
    bool CanModerate,
    /// <summary>Moderated-by scope (0 none, 1 blog owner, 2 community staff,
    /// 3 platform) - lets a blog owner distinguish their own hides.</summary>
    int ModeratedByScope = 0,
    string? ModerationReason = null
);

/// <summary>Keyset-paginated root comments + reply previews per root.</summary>
[MessagePackObject(keyAsPropertyName: true)]
public record CommentPageDto(
    CommentTargetKind TargetKind,
    long TargetId,
    List<CommunityCommentDto> Roots,
    /// <summary>root_id → up to 3 reply previews (ascending id).</summary>
    Dictionary<long, List<CommunityCommentDto>> ReplyPreviews,
    /// <summary>Cursor for the next page (last root id), null = exhausted.</summary>
    long? NextCursor,
    int TotalRootCount
);

/// <summary>Create/edit/reply/lock-write - one DTO mirrors EventRsvpDto's shape.</summary>
[MessagePackObject(keyAsPropertyName: true)]
public record CommentUpsertDto(
    CommentTargetKind TargetKind,
    long TargetId,
    /// <summary>Blog targets only - owning profile uid (routing + acl).</summary>
    string? OwnerUid,
    string? GroupGID,
    string Body,
    /// <summary>Set → reply to that comment (depth-2 flattening).</summary>
    long? ParentId,
    /// <summary>Set → edit that comment (author only).</summary>
    long? CommentId = null,
    /// <summary>Group-scoped routing for community targets.</summary>
    GroupData? Group = null
);

/// <summary>Keyset page request for roots or one root's replies.</summary>
[MessagePackObject(keyAsPropertyName: true)]
public record CommentPageRequestDto(
    CommentTargetKind TargetKind,
    long TargetId,
    string? OwnerUid = null,
    string? GroupGID = null,
    long? RootId = null,
    long? Cursor = null,
    int PageSize = 20
);

/// <summary>Staff/blog-owner moderation write on one comment.</summary>
[MessagePackObject(keyAsPropertyName: true)]
public record CommentModerationDto(
    CommentTargetKind TargetKind,
    long TargetId,
    long CommentId,
    /// <summary>hide=0 restore=1 remove=2 lockThread=3 unlockThread=4</summary>
    int Action,
    string? OwnerUid = null,
    string? Reason = null,
    GroupData? Group = null
);

/// <summary>Aggregate reaction state for one target + viewer's own kinds.</summary>
[MessagePackObject(keyAsPropertyName: true)]
public record ReactionSummaryDto(
    ReactionTargetKind TargetKind,
    long TargetId,
    Dictionary<int, int> Counts,
    List<int> ViewerKinds,
    int TotalCount,
    /// <summary>Counts keyed by emoji glyph - the post-migration reaction
    /// identity. Null on older servers; clients fall back to translating
    /// <see cref="Counts"/> through ReactionEmojiMap.</summary>
    Dictionary<string, int>? EmojiCounts = null,
    /// <summary>The viewer's own reaction glyphs.</summary>
    List<string>? ViewerEmojis = null
);

/// <summary>State-based reaction write - Set=true ensures the row exists,
/// Set=false ensures it doesn't. Idempotent; never a toggle.</summary>
[MessagePackObject(keyAsPropertyName: true)]
public record ReactionSetDto(
    ReactionTargetKind TargetKind,
    long TargetId,
    ReactionKind Kind,
    bool Set,
    /// <summary>Comment-targeted reactions carry the comment id plus its host.</summary>
    long? CommentTargetId = null,
    string? OwnerUid = null,
    GroupData? Group = null,
    /// <summary>The reacted emoji glyph (e.g. a chat-picker pick). Null means
    /// a legacy predefined kind write - the server translates it through
    /// ReactionEmojiMap, so both paths land on the same row.</summary>
    string? Emoji = null,
    /// <summary>Server-authoritative toggle: the direction is decided from
    /// the stored row, ignoring <see cref="Set"/> - immune to whatever stale
    /// viewer state the client computed its guess from. Older servers ignore
    /// the flag and stay state-based, so the client still sends its best
    /// guess in <see cref="Set"/> as the fallback.</summary>
    bool Toggle = false
);

/// <summary>Paginated who-reacted listing.</summary>
[MessagePackObject(keyAsPropertyName: true)]
public record ReactionUsersRequestDto(
    ReactionTargetKind TargetKind,
    long TargetId,
    ReactionKind? Kind = null,
    string? OwnerUid = null,
    int PageSize = 20,
    DateTime? Cursor = null,
    GroupData? Group = null,
    /// <summary>Emoji-glyph filter - wins over <see cref="Kind"/> when set.</summary>
    string? Emoji = null,
    /// <summary>Server-authoritative toggle: the direction is decided from
    /// the stored row, ignoring <see cref="Set"/> - immune to whatever stale
    /// viewer state the client computed its guess from. Older servers ignore
    /// the flag and stay state-based, so the client still sends its best
    /// guess in <see cref="Set"/> as the fallback.</summary>
    bool Toggle = false
);

[MessagePackObject(keyAsPropertyName: true)]
public record ReactionUsersDto(
    ReactionTargetKind TargetKind,
    long TargetId,
    List<UserData> Users,
    DateTime? NextCursor
);
