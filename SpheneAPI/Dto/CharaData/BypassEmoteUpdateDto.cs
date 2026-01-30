using MessagePack;
using Sphene.API.Data;
using Sphene.API.Dto.User;

namespace Sphene.API.Dto.CharaData;

[MessagePackObject(keyAsPropertyName: true)]
public record BypassEmoteUpdateDto(string Id, string BypassEmoteData, List<UserData>? Recipients = null, UserData? Sender = null);
