using MessagePack;
using System;
using System.Collections.Generic;

namespace Sphene.API.Dto.Files;

[MessagePackObject(keyAsPropertyName: true)]
public record PenumbraModBackupCreateResultDto(
    Guid BackupId,
    bool IsComplete,
    List<string> MissingHashes);

