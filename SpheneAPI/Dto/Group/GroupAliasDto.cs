using Sphene.API.Data;
using MessagePack;

namespace Sphene.API.Dto.Group;

[MessagePackObject(keyAsPropertyName: true)]
public record GroupAliasDto(GroupData Group, string? Alias) : GroupDto(Group);