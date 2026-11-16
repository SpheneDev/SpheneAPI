using MessagePack;
using Sphene.API.Data;

namespace Sphene.API.Dto.User;

/// <summary>Unread counters for one conversation, keyed by the other
/// participant. Server-side read state (<c>ReadAt</c>) is authoritative -
/// the client reconciles its local unread flags against this on connect so
/// messages delivered while offline still surface their indicators.</summary>
[MessagePackObject(keyAsPropertyName: true)]
public record ChatUnreadDto(UserData User, int Count);
