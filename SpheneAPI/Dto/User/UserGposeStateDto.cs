using MessagePack;
using Sphene.API.Data;

namespace Sphene.API.Dto.User;

[MessagePackObject(keyAsPropertyName: true)]
public record UserGposeStateDto(UserData User, bool IsInGpose, DateTime TimestampUtc);

