namespace Sphene.API.Data.Enum;

/// <summary>
/// Category of a durable user notification. Producers for the community
/// kinds land with their phases (membership P1, mentions/comments P2/P4,
/// events P3, reactions P4); <see cref="System"/> exists for service
/// notices today. Values are stable - never reorder.
/// </summary>
public enum UserNotificationKind
{
    System = 0,
    MembershipApplicationReceived = 1,
    MembershipApplicationAccepted = 2,
    MembershipApplicationRejected = 3,
    MembershipApplicationWithdrawn = 4,
    CommentAdded = 5,
    CommentReply = 6,
    Mention = 7,
    EventInvitation = 8,
    EventReminder = 9,
    EventChanged = 10,
    Reaction = 11,
    CommunityNewsPublished = 12,
    /// <summary>Staff-only: a member submission is waiting in the review queue.</summary>
    ContentPendingReview = 13,
    /// <summary>Author: a queued submission was rejected (see ReviewNote).</summary>
    ContentRejected = 14,
    /// <summary>Attendee/interested user: the event was cancelled.</summary>
    EventCancelled = 15,
    /// <summary>Waitlisted user: a seat opened and they were promoted to Attending.</summary>
    EventWaitlistPromoted = 16,
    /// <summary>Comment author: a moderator hid/restored/removed their comment.</summary>
    CommentModerated = 17,
    /// <summary>Reporter: their content report was resolved or dismissed.</summary>
    ReportOutcome = 18,
}
