using Sphene.API.Data;
using Sphene.API.Data.Enum;
using MessagePack;

namespace Sphene.API.Dto.Group;

[MessagePackObject(keyAsPropertyName: true)]
public record GroupFullInfoDto(GroupData Group, UserData Owner, GroupPermissions GroupPermissions,
    GroupUserPreferredPermissions GroupUserPermissions, GroupPairUserInfo GroupUserInfo,
    Dictionary<string, GroupPairUserInfo> GroupPairUserInfos, int MemberCount = -1,
    /// <summary>uid → <see cref="UserData"/> identities for every uid the
    /// privileged roster and staff assignments reference - carries Alias and
    /// DisplayName so surfaces render names, never raw uids.</summary>
    Dictionary<string, UserData>? MemberIdentities = null) : GroupInfoDto(Group, Owner, GroupPermissions)
{
    public GroupUserPreferredPermissions GroupUserPermissions { get; set; } = GroupUserPermissions;
    public GroupPairUserInfo GroupUserInfo { get; set; } = GroupUserInfo;
    /// <summary>Authoritative total member count (GroupPair rows) - the same
    /// number for every viewer. -1 on old servers; clients fall back to their
    /// local presence estimate.</summary>
    public int MemberCount { get; set; } = MemberCount;
    /// <summary>Identity rows for roster/assignment uids - absent on old servers.</summary>
    public Dictionary<string, UserData>? MemberIdentities { get; set; } = MemberIdentities;
}
