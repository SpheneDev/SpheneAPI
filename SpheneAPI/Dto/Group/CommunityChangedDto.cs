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
    long? ContentId
);
