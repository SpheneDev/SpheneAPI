using MessagePack;

namespace Sphene.API.Data;

[MessagePackObject(keyAsPropertyName: true)]
public record UserData(string UID, string? Alias = null, bool IsSupporter = false, string? DisplayName = null)
{
    [IgnoreMember]
    public string AliasOrUID => string.IsNullOrWhiteSpace(Alias) ? UID : Alias;

    [IgnoreMember]
    public string PreferredName => string.IsNullOrWhiteSpace(DisplayName) ? AliasOrUID : DisplayName;
}
