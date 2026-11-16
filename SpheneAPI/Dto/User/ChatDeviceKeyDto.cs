using MessagePack;

namespace Sphene.API.Dto.User;

/// <summary>Public E2EE device key of a user. The private key never leaves
/// the client installation that generated it.</summary>
[MessagePackObject(keyAsPropertyName: true)]
public record ChatDeviceKeyDto(string Uid, string DeviceId, byte[] PublicKey,
    DateTime PublishedAtUtc);
