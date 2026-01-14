using MessagePack;

namespace Sphene.API.Dto.Files;

[MessagePackObject(keyAsPropertyName: true)]
public record ModUploadHistoryEntryDto(
    string Hash,
    string Name,
    string? Author,
    string? Version,
    string? Description,
    string? Website,
    System.DateTime UploadedDate,
    string? UploaderUID,
    long Size,
    long RawSize);

