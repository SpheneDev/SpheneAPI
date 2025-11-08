using MessagePack;
using Sphene.API.Data;

namespace Sphene.API.Dto.Visibility;

/// Visibility report from one user about another
[MessagePackObject(keyAsPropertyName: true)]
public record UserVisibilityReportDto(UserData Reporter, UserData Target, bool IsVisible, DateTime TimestampUtc);