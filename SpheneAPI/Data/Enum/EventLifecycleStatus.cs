namespace Sphene.API.Data.Enum;

/// <summary>Lifecycle state of a community event - orthogonal to its
/// <see cref="ContentPublishStatus"/> moderation state.</summary>
public enum EventLifecycleStatus
{
    Scheduled = 0,
    Cancelled = 1,
    Completed = 2,
}
