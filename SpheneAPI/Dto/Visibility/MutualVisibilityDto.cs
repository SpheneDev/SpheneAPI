using MessagePack;
using Sphene.API.Data;

namespace Sphene.API.Dto.Visibility;

/// Mutual visibility status between two users
[MessagePackObject(keyAsPropertyName: true)]
public record MutualVisibilityDto(UserData UserA, UserData UserB, bool IsMutuallyVisible, DateTime TimestampUtc);