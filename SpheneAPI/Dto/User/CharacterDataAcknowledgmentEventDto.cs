using MessagePack;

namespace Sphene.API.Dto.User;

[MessagePackObject(keyAsPropertyName: true)]
public record CharacterDataAcknowledgmentEventDto(CharacterDataAcknowledgmentDto Acknowledgment)
{
    public int ContractVersion { get; init; } = 1;
    public DateTime SentAt { get; init; } = DateTime.UtcNow;
}
