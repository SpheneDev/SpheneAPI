using MessagePack;
using Sphene.API.Data;
using Sphene.API.Data.Enum;

namespace Sphene.API.Dto.User;

[MessagePackObject(keyAsPropertyName: true)]
public record ChatMessageDto(Guid Id, UserData Sender, UserData Recipient,
    string Message, DateTime SentAt, bool Read)
{
    /// <summary>Plaintext/SealedNative/SealedMigrated. For sealed kinds
    /// <see cref="Message"/> is empty and <see cref="Copies"/> carries the
    /// caller-addressed cipher copies.</summary>
    public ChatMessageKind Kind { get; set; } = ChatMessageKind.Plaintext;

    /// <summary>Only the copies addressed to the requesting caller's active
    /// devices - never the other participant's copies.</summary>
    public List<ChatCipherCopyDto> Copies { get; set; } = [];

    /// <summary>Present only on migrated rows: the UID that performed the
    /// migration, so clients can surface non-native provenance.</summary>
    public string? MigratedByUid { get; set; }
}
