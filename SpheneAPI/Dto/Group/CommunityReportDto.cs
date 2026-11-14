using Sphene.API.Data;
using Sphene.API.Data.Enum;
using MessagePack;

namespace Sphene.API.Dto.Group;

/// <summary>Reporter-side report creation.</summary>
[MessagePackObject(keyAsPropertyName: true)]
public record ReportCreateDto(
    ReportTargetKind TargetKind,
    long TargetId,
    ReportReason Reason,
    string? OwnerUid = null,
    string? Details = null,
    GroupData? Group = null
);

/// <summary>One open/resolved report as shown in a resolver queue.</summary>
[MessagePackObject(keyAsPropertyName: true)]
public record CommunityReportDto(
    long Id,
    ReportTargetKind TargetKind,
    long TargetId,
    string? GroupGID,
    UserData? Reporter,
    ReportReason Reason,
    string? Details,
    ReportState State,
    UserData? ResolvedBy,
    DateTime? ResolvedAt,
    string? ResolutionNote,
    DateTime CreatedAt,
    /// <summary>Snippet of the reported content - resolver-only.</summary>
    string? TargetSnippet = null
);

/// <summary>Resolver decision - Resolve=true (action taken) or false (dismiss).</summary>
[MessagePackObject(keyAsPropertyName: true)]
public record ReportDecisionDto(
    long ReportId,
    bool Resolve,
    string? Note = null,
    GroupData? Group = null
);

/// <summary>Community-scoped moderation queue (group reports).</summary>
[MessagePackObject(keyAsPropertyName: true)]
public record ModerationQueueDto(
    GroupData Group,
    List<CommunityReportDto> Items
) : GroupDto(Group);

/// <summary>Platform-scoped queue - blog reports (User.IsModerator only).</summary>
[MessagePackObject(keyAsPropertyName: true)]
public record PlatformReportQueueDto(
    List<CommunityReportDto> Items
);
