using MessagePack;

namespace Sphene.API.Dto.User;

/// <summary>
/// The caller's encrypted chat key backup as stored server-side. Opaque
/// ciphertext to the server; <see cref="Revision"/> is the server's
/// monotonically increasing version counter used for compare-and-swap
/// writes - a put only applies while the expected revision still matches.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record ChatKeyBackupDto(byte[] Blob, long Revision);

/// <summary>
/// Result of a compare-and-swap backup write. On success <see cref="Revision"/>
/// carries the newly assigned revision. On conflict it carries the CURRENT
/// server revision and <see cref="Blob"/> the current ciphertext, so the
/// client can re-decrypt, merge and retry without a second round trip.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record ChatKeyBackupResult(bool Success, long Revision, byte[]? Blob);
