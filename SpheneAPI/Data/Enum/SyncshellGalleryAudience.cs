namespace Sphene.API.Data.Enum;

/// <summary>
/// Who may see a community gallery image or album. Staff (moderator/owner or
/// any assigned staff role) always see everything; uploaders always see their
/// own images. <see cref="SelectedMembers"/> additionally opens the item to the
/// member UIDs carried in the DTO's AllowedUids list.
/// </summary>
public enum SyncshellGalleryAudience
{
    Everyone = 0,
    StaffOnly = 1,
    SelectedMembers = 2,
}
