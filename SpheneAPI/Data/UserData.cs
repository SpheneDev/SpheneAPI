using MessagePack;

namespace Sphene.API.Data;

[MessagePackObject(keyAsPropertyName: true)]
public record UserData(string UID, string? Alias = null, bool IsSupporter = false)
{
    [IgnoreMember]
    public string AliasOrUID => string.IsNullOrWhiteSpace(Alias) ? UID : Alias;
}
