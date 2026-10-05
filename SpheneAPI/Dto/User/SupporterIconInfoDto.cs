using MessagePack;

namespace Sphene.API.Dto.User;

[MessagePackObject(keyAsPropertyName: true)]
public class SupporterIconInfoDto
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public bool Animated { get; set; }
}
