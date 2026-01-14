using MessagePack;

namespace Sphene.API.Dto.Files;

[MessagePackObject(keyAsPropertyName: true)]
public record ModShareHistoryEntryDto(
    string Hash,
    string Name,
    string? Author,
    string? Version,
    string? Description,
    string? Website,
    System.DateTime SharedAt,
    string RecipientUID,
    string? RecipientAlias,
    long Size,
    long RawSize);
