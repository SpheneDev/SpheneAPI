using Sphene.API.Data;
using MessagePack;

namespace Sphene.API.Dto.Files;

[MessagePackObject(keyAsPropertyName: true)]
public record FileTransferNotificationDto
{
    public UserData Sender { get; init; } = new(string.Empty);
    public UserData Recipient { get; init; } = new(string.Empty);
    public string Hash { get; init; } = string.Empty;
    public string FileName { get; init; } = string.Empty;
    public string? ModFolderName { get; init; }
    public string? Description { get; init; }
    public List<ModInfoDto>? ModInfo { get; init; }
}

