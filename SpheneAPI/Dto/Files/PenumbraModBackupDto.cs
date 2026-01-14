using MessagePack;
using System;
using System.Collections.Generic;

namespace Sphene.API.Dto.Files;

[MessagePackObject(keyAsPropertyName: true)]
public record PenumbraModBackupDto(
    Guid BackupId,
    string BackupName,
    DateTime CreatedAt,
    bool IsComplete,
    List<PenumbraModBackupEntryDto> Mods);

