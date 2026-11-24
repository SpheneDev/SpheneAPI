using Sphene.API.Data;
using MessagePack;

namespace Sphene.API.Dto.Group;

/// <summary>
/// Pushed to syncshell members when community content changed · Section null
/// means the whole page (profile/static update), ContentId carries the
/// affected row for section-scoped changes.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record CommunityChangedDto(
    GroupData Group,
    SyncshellCommunitySection? Section,
    long? ContentId,
    /// <summary>The change is a reaction toggle only - counts/summaries move,
    /// no content. Feeds patch reactions locally and threads reload summaries
    /// lazily, so neither needs a wholesale invalidation for these.</summary>
    bool ReactionsOnly = false,
    /// <summary>For <see cref="ReactionsOnly"/> pushes: the reaction target
    /// kind/id pair, so clients can refetch just that item's summary instead
    /// of guessing. Null on comment-level reactions (no feed row exists for
    /// them) and on pushes from older servers.</summary>
    int? ReactionTargetKind = null,
    long? ReactionTargetId = null
);
