using MessagePack;
using System.Collections.Generic;

namespace Sphene.API.Dto.Files;

[MessagePackObject(keyAsPropertyName: true)]
public record PenumbraModBackupCreateDto(
    string BackupName,
    List<PenumbraModBackupEntryDto> Mods);

