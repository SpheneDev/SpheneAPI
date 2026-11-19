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
    string? FeedRowKey = null);

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
