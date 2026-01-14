using MessagePack;

namespace Sphene.API.Dto.Files;

[MessagePackObject(keyAsPropertyName: true)]
public record ModDownloadHistoryEntryDto(
    string Hash,
    string Name,
    string? Author,
    string? Version,
    string? Description,
    string? Website,
    System.DateTime DownloadedAt,
    long Size,
    long RawSize);

