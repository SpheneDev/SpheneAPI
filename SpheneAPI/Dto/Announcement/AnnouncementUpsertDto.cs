using MessagePack;

namespace Sphene.API.Dto.Announcement;

/// <summary>
/// Write contract for announcements · <see cref="Id"/> = 0 creates a new row,
/// otherwise the matching row is updated. Drafts never surface in
/// <c>GetAnnouncements</c> and never push <c>Client_AnnouncementPublished</c>
/// until they are first saved as published.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record AnnouncementUpsertDto(long Id, string Title, string Summary, string Body,
    string Category, string? BannerImageUrl, string? LinkUrl,
    bool IsPinned, bool IsDraft);
