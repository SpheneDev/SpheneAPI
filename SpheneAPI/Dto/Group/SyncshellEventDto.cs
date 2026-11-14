using Sphene.API.Data;
using MessagePack;

namespace Sphene.API.Dto.Group;

[MessagePackObject(keyAsPropertyName: true)]
public record SyncshellEventDto(
    long Id,
    string GroupGID,
    string Title,
    string? Description,
    DateTime StartUtc,
    DateTime? EndUtc,
    string? Location,
    string? Url,
    string? ImageBase64,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    string? ImageMediaHash = null,
    /// <summary>Event author + co-organizers (first entry = creator).</summary>
    List<string>? OrganizerUids = null,
    string? AuthorUid = null,
    /// <summary>null = unbounded capacity.</summary>
    int? MaxAttendees = null,
    /// <summary><see cref="Sphene.API.Data.Enum.EventVisibility"/> as int.</summary>
    int Visibility = 0,
    /// <summary><see cref="Sphene.API.Data.Enum.EventLifecycleStatus"/> as int.</summary>
    int EventStatus = 0,
    /// <summary><see cref="Sphene.API.Data.Enum.ContentPublishStatus"/> as int.</summary>
    int PublishStatus = 0,
    /// <summary>TimeZoneInfo.Id for display + DST-correct recurrence.</summary>
    string? TimezoneId = null,
    string? RecurrenceRule = null,
    /// <summary>Minutes-before-start reminder offsets.</summary>
    List<int>? Reminders = null,
    int AttendingCount = 0,
    int WaitlistCount = 0,
    /// <summary>Viewer's own RSVP - <see cref="Sphene.API.Data.Enum.EventRsvpStatus"/> as int, null = none.</summary>
    int? ViewerRsvpStatus = null,
    string? ReviewedByUid = null,
    string? ReviewNote = null,
    /// <summary>Denormalized comment count + thread lock (Phase 4).</summary>
    int CommentCount = 0,
    bool CommentsLocked = false,
    /// <summary>Optional structured travel destination - additive; null on
    /// older payloads and on events without one.</summary>
    EventDestinationDto? Destination = null,
    /// <summary>Identity projection of <see cref="OrganizerUids"/> (same
    /// order, first = creator) - additive; null on older payloads. UI renders
    /// names from this and never falls back to the raw UID.</summary>
    List<UserData>? OrganizerUsers = null,
    /// <summary>16:9 preview image (800×450) for list/card contexts -
    /// media-store hash; null falls back to the banner image.</summary>
    string? PreviewMediaHash = null,
    /// <summary>Unsaved/live-preview carry for <see cref="PreviewMediaHash"/>
    /// - client-side only, never persisted by the server.</summary>
    string? PreviewBase64 = null
);

[MessagePackObject(keyAsPropertyName: true)]
public record SyncshellEventUpdateDto(
    long Id,
    GroupData Group,
    string Title,
    string? Description,
    DateTime StartUtc,
    DateTime? EndUtc,
    string? Location,
    string? Url,
    string? ImageBase64,
    string? ImageMediaHash = null,
    List<string>? OrganizerUids = null,
    int? MaxAttendees = null,
    int Visibility = 0,
    int EventStatus = 0,
    /// <summary>Publishing intent - resolved server-side, never trusted.</summary>
    int? StatusIntent = null,
    string? TimezoneId = null,
    string? RecurrenceRule = null,
    List<int>? Reminders = null,
    /// <summary>Edit an exception occurrence instead of the series (staff/organizer).</summary>
    DateTime? OccurrenceStartUtc = null,
    /// <summary>Optional structured destination write - validated server-side;
    /// on occurrence edits <see cref="Sphene.API.Data.Enum.EventDestinationKind.None"/>
    /// explicitly clears the destination for that date.</summary>
    EventDestinationDto? Destination = null,
    /// <summary>16:9 preview image for list/card contexts - media-store hash
    /// only; additive, null keeps <see cref="ImageMediaHash"/> as the card image.</summary>
    string? PreviewMediaHash = null
) : GroupDto(Group);
