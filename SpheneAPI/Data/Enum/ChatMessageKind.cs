namespace Sphene.API.Data.Enum;

/// <summary>
/// Storage/wire state of a chat message body.
/// Plaintext rows are pre-E2EE history or messages sent before the sender had
/// encryption capability - they are NOT cryptographically protected.
/// SealedMigrated marks legacy plaintext that was re-sealed after the fact:
/// it protects stored content going forward but cannot retroactively provide
/// historical forward secrecy or native sender authenticity.
/// </summary>
public enum ChatMessageKind : byte
{
    Plaintext = 0,
    SealedNative = 1,
    SealedMigrated = 2
}
