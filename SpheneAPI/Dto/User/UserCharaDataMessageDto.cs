using Sphene.API.Data;
using MessagePack;

namespace Sphene.API.Dto.User;

[MessagePackObject(keyAsPropertyName: true)]
public sealed class UserCharaDataMessageDto
{
    public List<UserData> Recipients { get; init; } = [];
    public CharacterData CharaData { get; init; } = null!;
    public CensusDataDto? CensusDataDto { get; init; }
    public bool RequiresAcknowledgment { get; init; } = true;

    public UserCharaDataMessageDto()
    {
    }

    public UserCharaDataMessageDto(List<UserData> recipients, CharacterData charaData, CensusDataDto? censusDataDto, bool requiresAcknowledgment = true)
    {
        Recipients = recipients;
        CharaData = charaData;
        CensusDataDto = censusDataDto;
        RequiresAcknowledgment = requiresAcknowledgment;
    }
}
