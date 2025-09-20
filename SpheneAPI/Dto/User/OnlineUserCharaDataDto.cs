using Sphene.API.Data;
using MessagePack;

namespace Sphene.API.Dto.User;

[MessagePackObject(keyAsPropertyName: true)]
public record OnlineUserCharaDataDto(UserData User, CharacterData CharaData) : UserDto(User)
{
    public string DataHash { get; init; } = string.Empty;
    public bool RequiresAcknowledgment { get; init; } = true;
    public long SequenceNumber { get; set; } = 0;
}
