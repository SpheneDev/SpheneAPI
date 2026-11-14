using MessagePack;

namespace Sphene.API.Dto.Announcement;

/// <summary>
/// One published, server-stored announcement · the canonical news article
/// pushed to clients and re-fetched for the Hub news page. <see cref="Body"/>
/// carries the canonical CommonMark-subset markdown; the hero image always
/// travels via <see cref="BannerImageUrl"/>, never inline.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record AnnouncementDto(long Id, string Title, string Summary, string Body,
    string Category, string? BannerImageUrl, string? LinkUrl,
    string AuthorDisplay, DateTime PublishedAt, bool IsPinned, bool IsDraft);
