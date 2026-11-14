using MessagePack;
using Sphene.API.Data.Enum;

namespace Sphene.API.Dto.Group;

/// <summary>
/// Lightweight listing entry for the public syncshell community directory -
/// enough to render a card without shipping the full community payload.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record SyncshellDirectoryEntryDto(
    string GroupGID,
    string? GroupAlias,
    string? Tagline,
    string? AccentColor,
    string? AvatarImageBase64,
    string? BannerImageBase64,
    int MemberCount,
    DateTime UpdatedAt,
    /// <summary>Server-resolved <see cref="SyncshellJoinPolicy"/> -
    /// <c>InvitesEnabled=false</c> already folded to <see cref="SyncshellJoinPolicy.Closed"/>.
    /// Cards render the join CTA from this one field; default <c>Closed</c>
    /// keeps old-server listings from offering a join path they never had.</summary>
    SyncshellJoinPolicy EffectiveJoinPolicy = SyncshellJoinPolicy.Closed,
    /// <summary>True when the caller already belongs to the shell.</summary>
    bool CallerIsMember = false,
    /// <summary>Content-addressed media hashes for banner/avatar - the card
    /// resolves them through <c>community/media/{hash}</c>; null when the
    /// shell still ships inline base64 media.</summary>
    string? BannerMediaHash = null,
    string? AvatarMediaHash = null,
    /// <summary>Area-bound shell: viewing is open to everyone, but joining
    /// only works while the user stands inside the bound area.</summary>
    bool IsAreaBound = false,
    /// <summary>The caller bookmarked this shell - it stays reachable from
    /// their Followed list even when they cannot currently join.</summary>
    bool IsFavorite = false
);
