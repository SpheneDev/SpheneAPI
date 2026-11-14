namespace Sphene.API.Data.Enum;

/// <summary>
/// Shared publication state machine for community content (syncshell news,
/// profile blog posts and future content kinds). Transitions are validated
/// server-side by the PublishingService - clients never write this directly.
/// </summary>
public enum ContentPublishStatus
{
    /// <summary>Work in progress · author and editors only.</summary>
    Draft = 0,
    /// <summary>Submitted for staff review · queue pending.</summary>
    PendingApproval = 1,
    /// <summary>Approved but not live until ScheduledForUtc.</summary>
    Scheduled = 2,
    /// <summary>Live and visible per audience rules.</summary>
    Published = 3,
    /// <summary>Reviewed and declined · author may revise back to Draft.</summary>
    Rejected = 4,
    /// <summary>Formerly live, pulled down · staff/author only.</summary>
    Archived = 5,
}
