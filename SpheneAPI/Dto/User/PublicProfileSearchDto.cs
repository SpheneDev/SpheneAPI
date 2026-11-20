using MessagePack;

namespace Sphene.API.Dto.User;

/// <summary>Bounded public-profile search request - display-name / alias
/// contains match over profiles that opted into Community Hub visibility.
/// Results intentionally stay slim: no images, no profile payload.</summary>
[MessagePackObject(keyAsPropertyName: true)]
public record PublicProfileSearchDto(string? Query, int Skip = 0, int Take = 20);

/// <summary>One public-profile search hit - only what the result row needs.</summary>
[MessagePackObject(keyAsPropertyName: true)]
public record PublicProfileSummaryDto(
    Data.UserData User,
    string? AvatarMediaHash,
    bool IsNsfw,
    bool Following);
