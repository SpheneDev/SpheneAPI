using MessagePack;
using System;

namespace Sphene.API.Dto.Files;

[MessagePackObject(keyAsPropertyName: true)]
public record PenumbraModBackupSummaryDto(
    Guid BackupId,
    string BackupName,
    DateTime CreatedAt,
    int ModCount,
    bool IsComplete);

