using Sphene.API.Data;
using Sphene.API.Data.Enum;
using MessagePack;

namespace Sphene.API.Dto.Group;

[MessagePackObject(keyAsPropertyName: true)]
public record SyncshellCommunityLinkDto(
    string Label,
    string Url,
    string? Icon
);

/// <summary>
/// Aggregate read model for a syncshell community page: the profile identity plus
/// static blocks (rules, links, section visibility) and the typed content feeds
/// (news, events, gallery) fetched in one call.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record SyncshellCommunityDto(
    SyncshellProfileDto Profile,
    string? RulesText,
    List<SyncshellCommunityLinkDto>? Links,
    List<SyncshellCommunitySection>? VisibleSections,
    bool IsListedPublicly,
    List<SyncshellEventDto>? Events,
    List<SyncshellNewsPostDto>? News,
    List<SyncshellGalleryImageDto>? Gallery,
    List<SyncshellGalleryAlbumDto>? Albums,
    List<SyncshellStaffRoleDto>? StaffRoles,
    List<SyncshellStaffAssignmentDto>? StaffAssignments,
    List<string>? OverviewWidgets = null,
    /// <summary>Shell display alias - fills the name slot for viewers who have
    /// no <c>GroupFullInfoDto</c> (non-members, area-bound previews).</summary>
    string? GroupAlias = null,
    /// <summary>Effective join policy for the preview's join CTA - server
    /// resolves <c>InvitesEnabled=false</c> to <c>Closed</c>. Null on old
    /// servers; clients fall back to a generic label.</summary>
    SyncshellJoinPolicy? EffectiveJoinPolicy = null,
    /// <summary>Published permanent community destination - populated only
    /// when the shell published it and the viewer may see it, or always for
    /// staff with page-management rights (draft included). Null otherwise.</summary>
    EventDestinationDto? CommunityDestination = null,
    /// <summary>Whether a community destination is currently published -
    /// honest for every viewer; only staff see the unpublished draft.</summary>
    bool CommunityDestinationPublished = false,
    /// <summary>Authoritative total member count (GroupPair rows) - identical
    /// for every authorized viewer. -1 on old servers; clients fall back to
    /// their local presence estimate.</summary>
    int MemberCount = -1,
    /// <summary>Identity rows for every uid the aggregate references (staff
    /// assignments, content authors, organizers) - Alias/DisplayName so
    /// surfaces render names, never raw uids.</summary>
    List<UserData>? MemberIdentities = null,
    /// <summary>Caller bookmarked the shell - the community page renders a
    /// Follow/Unfollow affordance off this flag.</summary>
    bool CallerFavorited = false,
    /// <summary>Area-bound shell: join CTAs must read "in area only" - viewing
    /// stays open to everyone.</summary>
    bool IsAreaBound = false,
    /// <summary>Members currently inside the bound area (live GroupPair
    /// rows) as identity rows - name/avatar only, never appearance data.
    /// Populated for members, staff and followers; null on anonymous
    /// previews and non-area-bound shells.</summary>
    List<UserData>? PresentMembers = null,
    /// <summary>How many users bookmarked this shell - rides with the
    /// shell's public stats (member count is already public).</summary>
    int FollowerCount = 0
);

/// <summary>
/// Writes the static community parts (identity, rules, links, visibility, listing).
/// Feed content is managed through the dedicated event/news/gallery CRUD calls.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record SyncshellCommunityUpdateDto(
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
    string? RulesText,
    List<SyncshellCommunityLinkDto>? Links,
    List<SyncshellCommunitySection>? VisibleSections,
    bool IsListedPublicly,
    bool IsEnabled,
    bool ShowOnJoin,
    bool ShowOnAreaBoundJoin,
    List<string>? OverviewWidgets = null,
    /// <summary>Hash-based media writes - take precedence over the base64 fields.</summary>
    string? BannerMediaHash = null,
    string? AvatarMediaHash = null,
    /// <summary>Explicit "no banner/avatar" intent - a plain null hash can't
    /// be told apart from a client that doesn't model the field, so removal
    /// needs its own signal to clear a stored media hash.</summary>
    bool ClearBanner = false,
    bool ClearAvatar = false
) : GroupDto(Group);

/// <summary>
/// Dedicated write for the permanent community location - kept off
/// <see cref="SyncshellCommunityUpdateDto"/> so unrelated profile updates can
/// never touch it. <paramref name="Destination"/>: null = keep the stored
/// snapshot, <c>Kind.None</c> = clear it (also unpublishes), a valid
/// <c>HousingAddress</c> = replace the snapshot. Public locations are not
/// accepted here.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record SyncshellCommunityDestinationUpdateDto(
    GroupData Group,
    EventDestinationDto? Destination,
    bool Publish
) : GroupDto(Group);

/// <summary>Shared delete contract for community feed items (events, news, gallery).</summary>
[MessagePackObject(keyAsPropertyName: true)]
public record SyncshellCommunityItemDeleteDto(
    GroupData Group,
    long Id
) : GroupDto(Group);
