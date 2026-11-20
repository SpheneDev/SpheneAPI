using MessagePack;

namespace Sphene.API.Dto.User;

/// <summary>
/// The public Community-Hub view of a profile - deliberately narrower than
/// <see cref="UserProfileDto"/>: display name/identity, avatar, banner, bio,
/// tags and the publicly visible owned Chronicles. Gallery, albums, status
/// message, row art, links, live location and syncshell data never ship.
/// Field-level <c>ProfileVisibility</c> masks, NSFW and moderation state are
/// already applied server-side; a null return means "not available".
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record PublicProfileDto(
    Data.UserData User,
    bool IsNsfw,
    string? ProfilePictureBase64,
    string? BannerImageBase64,
    string? Description,
    string? Tags,
    bool Following,
    List<UserProfileBlogPostDto> Chronicles);

/// <summary>Immediate, unilateral follow/unfollow of a public profile.
/// <paramref name="Follow"/> = desired edge state; the call is idempotent.</summary>
[MessagePackObject(keyAsPropertyName: true)]
public record UserProfileFollowDto(Data.UserData User, bool Follow);
