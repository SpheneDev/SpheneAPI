using Sphene.API.Data.Enum;
using MessagePack;
using System.Security.Cryptography;

using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Sphene.API.Data;

[MessagePackObject(keyAsPropertyName: true)]
public class CharacterData
{
    public CharacterData()
    {
        DataHash = new(() => ComputeHash(this));
        PenumbraHash = new(() => ComputeHash(new PenumbraHashData(FileReplacements, ManipulationData)));
        GlamourerHash = new(() => ComputeHash(new GlamourerHashData(GlamourerData)));
        RestHash = new(() => ComputeHash(new RestHashData(CustomizePlusData, HeelsData, HonorificData, MoodlesData, PetNamesData)));
    }

    public Dictionary<ObjectKind, string> CustomizePlusData { get; set; } = new();
    [JsonIgnore]
    public Lazy<string> DataHash { get; }
    [JsonIgnore]
    public Lazy<string> PenumbraHash { get; }
    [JsonIgnore]
    public Lazy<string> GlamourerHash { get; }
    [JsonIgnore]
    public Lazy<string> RestHash { get; }

    public Dictionary<ObjectKind, List<FileReplacementData>> FileReplacements { get; set; } = new();
    public Dictionary<ObjectKind, string> GlamourerData { get; set; } = new();
    public string HeelsData { get; set; } = string.Empty;
    public string HonorificData { get; set; } = string.Empty;
    public string ManipulationData { get; set; } = string.Empty;
    public string MoodlesData { get; set; } = string.Empty;
    public string PetNamesData { get; set; } = string.Empty;

    private static string ComputeHash(object data)
    {
        var json = JsonSerializer.Serialize(data);
#pragma warning disable SYSLIB0021 // Type or member is obsolete
        using SHA256CryptoServiceProvider cryptoProvider = new();
#pragma warning restore SYSLIB0021 // Type or member is obsolete
        return BitConverter.ToString(cryptoProvider.ComputeHash(Encoding.UTF8.GetBytes(json))).Replace("-", "", StringComparison.Ordinal);
    }

    private sealed record PenumbraHashData(Dictionary<ObjectKind, List<FileReplacementData>> FileReplacements, string ManipulationData);
    private sealed record GlamourerHashData(Dictionary<ObjectKind, string> GlamourerData);
    private sealed record RestHashData(Dictionary<ObjectKind, string> CustomizePlusData, string HeelsData, string HonorificData, string MoodlesData, string PetNamesData);
}
