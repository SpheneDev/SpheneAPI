using MessagePack;

namespace Sphene.API.Dto.Group;

/// <summary>Kind of activity a feed entry represents.</summary>
public enum SyncshellFeedItemKind
{
    News = 0,
    Event = 1,
    Photo = 2,
    /// <summary>Published blog post by a mutual pair or shell co-member (v39).</summary>
    Blog = 3,
    /// <summary>Comment on content the caller authored (v39).</summary>
    Comment = 4,
    /// <summary>Reaction on content the caller authored (v39).</summary>
    Reaction = 5,
    /// <summary>First RSVP or waitlist promotion on an event the caller authored (v39).</summary>
    Rsvp = 6,
}

/// <summary>
/// One entry of the aggregated community feed: newest published news posts,
/// upcoming events and recent gallery photos across every syncshell the
/// caller belongs to  ·  enough payload to render a row and deep-link into
/// the owning shell's community page.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record SyncshellCommunityFeedItemDto(
    string GroupGID,
    string? GroupAlias,
    string? AccentColor,
    SyncshellFeedItemKind Kind,
    long Id,
    string Title,
    string? Snippet,
    DateTime TimestampUtc,
    string? ThumbnailBase64 = null,
    /// <summary>Community tab the item deep-links into; null for non-shell items (blog).</summary>
    SyncshellCommunitySection? Section = null,
    /// <summary>Drill-in target inside <see cref="Section"/> (event/news/photo id).</summary>
    long? ItemId = null,
    /// <summary>Actor that produced the activity - commenter, reactor, RSVP holder,
    /// blog author. Null for self-authored content rows.</summary>
    string? ActorUid = null,
    /// <summary>Resolved display name of <see cref="ActorUid"/> (alias-or-UID) -
    /// saves the client a lookup per row.</summary>
    string? ActorDisplayName = null,
    /// <summary>Hash-addressed thumbnail for media kinds - events carry
    /// PreviewMediaHash→ImageMediaHash. Resolved client-side through the
    /// community media cache; <see cref="ThumbnailBase64"/> stays the inline
    /// fallback for photo payloads.</summary>
    string? ThumbnailMediaHash = null,
    /// <summary>Inner target inside <see cref="ItemId"/> - the comment id when
    /// the activity happened on a comment (comment rows and comment-target
    /// reactions), so clients can deep-link into the thread.</summary>
    long? SubItemId = null,
    /// <summary>Owner of the host thread for chronicle activity - the blog
    /// post author for comment/reaction rows on blog targets. Differs from
    /// <see cref="ActorUid"/> (the interactor), so clients route clicks to the
    /// discussion's home instead of the interactor's profile.</summary>
    string? TargetOwnerUid = null,
    /// <summary>Server-internal ordering discriminator - unique per emitted
    /// row and ascending inside the shared sort tuple, so two rows whose
    /// timestamp/kind/item/actor all match still sort deterministically and
    /// the page cursor can tell them apart. Clients may ignore it.</summary>
    string? FeedRowKey = null,
    /// <summary>The content owner's profile carries an NSFW flag - the
    /// Following feed stamps it so viewers honouring the
    /// <c>ProfilesAllowNsfw</c> setting can redact title/snippet/thumb
    /// without a per-author profile lookup.</summary>
    bool OwnerIsNsfw = false,
    /// <summary>When the item entered the feed (created/published). Event
    /// rows carry their scheduled start in <see cref="TimestampUtc"/> for
    /// ordering, so this disambiguates activity time from event start;
    /// null on other kinds and on rows from older servers.</summary>
    DateTime? ActivityUtc = null,
    /// <summary>Visible comments on the row's own content (News/Event from
    /// the grouped count, Blog from the denormalized post column). Null on
    /// activity rows, photo rows and rows from older servers.</summary>
    int? CommentCount = null,
    /// <summary>Reactions on the row's own content (News/Event/Blog grouped
    /// count). Null on activity rows, photo rows and older servers.</summary>
    int? ReactionCount = null,
    /// <summary>Unique non-owner viewers - blogs only
    /// (<see cref="ViewCount"/> is the denormalized post column). Null on
    /// every other kind and on rows from older servers.</summary>
    int? ViewCount = null,
    /// <summary>Full-resolution media hash when it differs from
    /// <see cref="ThumbnailMediaHash"/> - event rows ship a preview hash as
    /// the thumbnail, so the viewer needs the original for the opened
    /// image. Null on other kinds and rows from older servers.</summary>
    string? FullMediaHash = null,
    /// <summary>The caller holds a Like reaction on this row's own content
    /// - drives the red heart in the engagement strip and the toggle
    /// direction of a feed like click. False on activity rows, photo rows
    /// and rows from older servers.</summary>
    bool LikedByMe = false,
    /// <summary>Thumbs-up reactions only (toned variants included) - the
    /// engagement strip's like count. Null on rows from older servers;
    /// clients fall back to <see cref="ReactionCount"/> there.</summary>
    int? LikeCount = null,
    /// <summary>Per-emoji reaction counts EXCLUDING thumbs-up variants,
    /// ordered by count descending. Drives the emoji chips in feed rows;
    /// null on rows from older servers.</summary>
    List<FeedReactionEmojiDto>? ReactionEmojis = null);

/// <summary>One emoji's reaction count on a feed row's own content.</summary>
[MessagePackObject(keyAsPropertyName: true)]
public record FeedReactionEmojiDto(
    string Emoji,
    int Count,
    /// <summary>The caller holds this reaction - feed chips render active
    /// and toggle off on click. False on rows from older servers.</summary>
    bool ByMe = false);

/// <summary>Aggregated activity feed for the caller's syncshells.</summary>
[MessagePackObject(keyAsPropertyName: true)]
public record SyncshellCommunityFeedDto(
    List<SyncshellCommunityFeedItemDto> Items);

/// <summary>
/// Keyset page request for the aggregated feed. <see cref="Cursor"/> is the
/// opaque token the previous page returned (<c>null</c> = first page);
/// <see cref="Take"/> clamps to a server-side maximum.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record FeedPageRequestDto(
    string? Cursor = null,
    int Take = 30);

/// <summary>
/// One feed page plus the opaque continuation cursor - <c>null</c> when the
/// page reached the end. The cursor encodes the exact sort tuple
/// (TimestampUtc DESC, Kind ASC, ItemId DESC, ActorUid ASC) so identical
/// timestamps can neither drop nor duplicate rows across a page boundary.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record SyncshellCommunityFeedPageDto(
    List<SyncshellCommunityFeedItemDto> Items,
    string? NextCursor);
