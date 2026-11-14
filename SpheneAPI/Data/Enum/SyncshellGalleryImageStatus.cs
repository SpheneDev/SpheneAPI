namespace Sphene.API.Data.Enum;

/// <summary>
/// Publication state of a community gallery image. Staff uploads publish
/// directly; member submissions (contests, event photographers) land in
/// <see cref="PendingApproval"/> until a moderator accepts them.
/// </summary>
public enum SyncshellGalleryImageStatus
{
    Published = 0,
    PendingApproval = 1,
}
