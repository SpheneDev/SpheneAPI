using Sphene.API.Data;
using Sphene.API.Data.Enum;
using MessagePack;

namespace Sphene.API.Dto.Group;

/// <summary>
/// A custom staff job on a syncshell community (Owner, Moderator, Barkeeper,
/// Photographer, …) - shown as the affiliation on staff rows and carrying the
/// capability flags in <see cref="SyncshellStaffRoleDto.Permissions"/>.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record SyncshellStaffRoleDto(
    long Id,
    string GroupGID,
    string Name,
    uint ColorArgb,
    string? Icon,
    SyncshellStaffPermission Permissions,
    int SortOrder
);

/// <summary>Writes a staff role; Id 0 creates a new role.</summary>
[MessagePackObject(keyAsPropertyName: true)]
public record SyncshellStaffRoleUpdateDto(
    long Id,
    GroupData Group,
    string Name,
    uint ColorArgb,
    string? Icon,
    SyncshellStaffPermission Permissions,
    int SortOrder
) : GroupDto(Group);

/// <summary>
/// One member-role link. <paramref name="Id"/> is the assignment row id -
/// ascending in grant order, so it doubles as the seniority tie-break when
/// several members hold the same rank.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record SyncshellStaffAssignmentDto(
    string UserUID,
    long RoleId,
    long Id
);

/// <summary>
/// Sets a member's staff roles. When <paramref name="RoleIds"/> is non-null it
/// replaces the member's complete role set (empty clears all). Otherwise the
/// legacy single-role semantics apply: <paramref name="RoleId"/> selects the
/// one role the member holds, null clears every assignment.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record SyncshellStaffAssignmentUpdateDto(
    GroupData Group,
    string UserUID,
    long? RoleId,
    List<long>? RoleIds = null
) : GroupDto(Group);
