using Sphene.API.Data;
using MessagePack;

namespace Sphene.API.Dto.Group;

/// <summary>RSVP write - <see cref="Status"/> is a
/// <see cref="Sphene.API.Data.Enum.EventRsvpStatus"/> int; the server may
/// coerce Attending → Waitlist at capacity. <see cref="Remove"/> deletes the
/// participant row (staff or self-withdrawal).</summary>
[MessagePackObject(keyAsPropertyName: true)]
public record EventRsvpDto(
    GroupData Group,
    long EventId,
    int Status,
    string? Note = null,
    /// <summary>Staff override: target a specific member instead of caller.</summary>
    string? TargetUid = null,
    bool Remove = false
) : GroupDto(Group);

/// <summary>One participant row - trimmed for members, full for staff.</summary>
[MessagePackObject(keyAsPropertyName: true)]
public record EventParticipantDto(
    long EventId,
    string UserUID,
    int Status,
    int? WaitlistPosition,
    string? Note,
    DateTime UpdatedAt,
    /// <summary>Identity projection (alias/display name) - additive; null on
    /// older payloads. UI renders <see cref="UserData.PreferredName"/> and
    /// never falls back to the raw UID.</summary>
    UserData? User = null
);

/// <summary>Participant summary for an event - counts + caller row always;
/// the attendee list only for the audience the event allows.</summary>
[MessagePackObject(keyAsPropertyName: true)]
public record EventParticipantsDto(
    GroupData Group,
    long EventId,
    int? MaxAttendees,
    int AttendingCount,
    int InterestedCount,
    int WaitlistCount,
    /// <summary>Caller's own RSVP, null when not participating.</summary>
    int? ViewerRsvpStatus,
    int? ViewerWaitlistPosition,
    /// <summary>Full rows for staff; Attending-only list for members.</summary>
    List<EventParticipantDto> Participants
) : GroupDto(Group);

/// <summary>One expanded occurrence of an event (series instances share the
/// event's fields, exceptions may override).</summary>
[MessagePackObject(keyAsPropertyName: true)]
public record SyncshellEventOccurrenceDto(
    long EventId,
    string GroupGID,
    /// <summary>Canonical occurrence start - dedupe/exception key.</summary>
    DateTime OccurrenceStartUtc,
    DateTime? OccurrenceEndUtc,
    string Title,
    string? Location,
    /// <summary>Series index (0 = first instance).</summary>
    int SeriesIndex,
    bool IsCancelled,
    bool IsException,
    /// <summary>Resolved structured destination for this occurrence - series
    /// destination unless an exception overrides or clears it.</summary>
    EventDestinationDto? Destination = null,
    /// <summary>Raw exception destination - null = inherit the series, a
    /// <see cref="Sphene.API.Data.Enum.EventDestinationKind.None"/> DTO =
    /// explicitly cleared, anything else = this date's override. Editors use
    /// this to seed the scope; viewers only need <see cref="Destination"/>.</summary>
    EventDestinationDto? DestinationOverride = null
);

/// <summary>Calendar feed request - expanded occurrences in [FromUtc, ToUtc].</summary>
[MessagePackObject(keyAsPropertyName: true)]
public record SyncshellEventCalendarRequestDto(
    GroupData Group,
    DateTime FromUtc,
    DateTime ToUtc
) : GroupDto(Group);

/// <summary>Occurrence exception read/write - cancelled or field-overridden
/// instance of a recurring series.</summary>
[MessagePackObject(keyAsPropertyName: true)]
public record SyncshellEventExceptionDto(
    GroupData Group,
    long EventId,
    DateTime OccurrenceStartUtc,
    bool Cancelled = false,
    string? Title = null,
    DateTime? StartUtc = null,
    DateTime? EndUtc = null,
    string? Location = null,
    string? Description = null,
    /// <summary>Delete the exception instead of upserting it.</summary>
    bool Remove = false,
    /// <summary>Occurrence destination override - null inherits the series;
    /// <see cref="Sphene.API.Data.Enum.EventDestinationKind.None"/> explicitly
    /// clears it for this date; otherwise replaces it (validated server-side).</summary>
    EventDestinationDto? Destination = null
) : GroupDto(Group);
