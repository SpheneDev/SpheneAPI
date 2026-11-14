using Sphene.API.Data;
using Sphene.API.Data.Enum;
using MessagePack;

namespace Sphene.API.Dto.Group;

/// <summary>Apply for membership in an approval-gated syncshell.</summary>
[MessagePackObject(keyAsPropertyName: true)]
public record GroupApplyMembershipDto(GroupData Group, string? Message) : GroupDto(Group);

/// <summary>Owner decides the shell's join policy (moderator-or-owner gated).</summary>
[MessagePackObject(keyAsPropertyName: true)]
public record GroupJoinPolicyDto(GroupData Group, SyncshellJoinPolicy Policy) : GroupDto(Group);

/// <summary>Staff decision on a pending application.</summary>
[MessagePackObject(keyAsPropertyName: true)]
public record GroupMembershipDecisionDto(GroupData Group, long ApplicationId, bool Approve, string? Note)
    : GroupDto(Group);

/// <summary>One membership application row as served to applicants and staff.</summary>
[MessagePackObject(keyAsPropertyName: true)]
public record MembershipApplicationDto(
    long Id,
    GroupData Group,
    UserData Applicant,
    string? Message,
    MembershipApplicationStatus Status,
    DateTime CreatedAt,
    DateTime? ReviewedAt,
    UserData? ReviewedBy,
    string? ReviewNote
);
