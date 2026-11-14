using MessagePack;
using Sphene.API.Data;

namespace Sphene.API.Dto.User;

[MessagePackObject(keyAsPropertyName: true)]
public record ChatMessageDto(Guid Id, UserData Sender, UserData Recipient,
    string Message, DateTime SentAt, bool Read);
