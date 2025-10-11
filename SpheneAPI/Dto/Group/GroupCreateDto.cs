using MessagePack;

namespace Sphene.API.Dto.Group;

[MessagePackObject(keyAsPropertyName: true)]
public record GroupCreateDto(string? Alias = null);