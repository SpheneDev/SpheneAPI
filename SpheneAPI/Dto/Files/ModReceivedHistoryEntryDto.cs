using MessagePack;

namespace Sphene.API.Dto.Files;

[MessagePackObject(keyAsPropertyName: true)]
public record ModReceivedHistoryEntryDto(
    string Hash,
    string Name,
    string? Author,
    string? Version,
    string? Description,
    string? Website,
    System.DateTime ReceivedAt,
    string SenderUID,
    string? SenderAlias,
    long Size,
    long RawSize);

