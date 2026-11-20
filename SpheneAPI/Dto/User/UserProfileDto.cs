using Sphene.API.Data;
using MessagePack;

namespace Sphene.API.Dto.User;

/// <summary>One link chip on a user's profile - same shape as the
/// community-page link so the client renders both with one preset map.
/// <paramref name="Icon"/> carries the brand preset key, null = custom.</summary>
[MessagePackObject(keyAsPropertyName: true)]
public record UserProfileLinkDto(
    string Label,
    string Url,
    string? Icon
);

[MessagePackObject(keyAsPropertyName: true)]
public record UserProfileDto(UserData User, bool Disabled, bool? IsNSFW, string? ProfilePictureBase64, string? Description, string? StatusMessage = null, string? Tags = null, string? BannerImageBase64 = null, string? Theme = null, int? Visibility = null, string? RowImageBase64 = null, List<UserProfileLinkDto>? Links = null, bool? PublicProfile = null) : UserDto(User);
