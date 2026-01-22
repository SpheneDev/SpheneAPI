using MessagePack;

namespace Sphene.API.Dto.Files;

[MessagePackObject(keyAsPropertyName: true)]
public record PenumbraModBackupEntryDto(
    string Hash,
    string ModFolderName,
    string Name,
    string? Author,
    string? Version,
    string? Description,
    string? Website,
    string? FolderHash = null);

