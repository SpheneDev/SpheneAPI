using Sphene.API.Data;
using MessagePack;

namespace Sphene.API.Dto.User;

[MessagePackObject(keyAsPropertyName: true)]
public record UserProfileDto(UserData User, bool Disabled, bool? IsNSFW, string? ProfilePictureBase64, string? Description, string? StatusMessage = null, string? Tags = null, string? BannerImageBase64 = null, string? Theme = null, int? Visibility = null, string? RowImageBase64 = null) : UserDto(User);
