using MessagePack;

namespace Sphene.API.Dto.User;

/// <summary>
/// One device-addressed copy of a sealed chat message. The envelope blob is
/// opaque to the server (HPKE v1: version byte || DHKEM enc || AEAD ct||tag);
/// metadata stays visible so the server can route, authorize and filter the
/// copy and so the recipient can pick the right key material to open it.
/// SealerPublicKey is pinned server-side to the key the sealer had published
/// when the message was accepted.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record ChatCipherCopyDto
{
    /// <summary>Conversation participant this copy decrypts for (sender or recipient).</summary>
    public string ForUid { get; set; } = string.Empty;

    /// <summary>Device of ForUid this copy is addressed to.</summary>
    public string ForDeviceId { get; set; } = string.Empty;

    /// <summary>Installation that produced the seal (author or migrator).</summary>
    public string SealerUid { get; set; } = string.Empty;
    public string SealerDeviceId { get; set; } = string.Empty;

    /// <summary>Uncompressed P-256 public key the recipient authenticates against.</summary>
    public byte[] SealerPublicKey { get; set; } = [];
    public byte[] Blob { get; set; } = [];
}
