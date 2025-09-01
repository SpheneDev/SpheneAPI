using Sphene.API.Data;
using MessagePack;

namespace Sphene.API.Dto.CharaData;

[MessagePackObject(keyAsPropertyName: true)]
public record CharaDataDownloadDto(string Id, UserData Uploader) : CharaDataDto(Id, Uploader)
{
    public string GlamourerData { get; init; } = string.Empty;
    public string CustomizeData { get; init; } = string.Empty;
    public string ManipulationData { get; set; } = string.Empty;
    public string HeelsData { get; init; } = string.Empty;
    public string HonorificData { get; init; } = string.Empty;
    public string MoodlesData { get; init; } = string.Empty;
    public string PetNamesData { get; init; } = string.Empty;
    public List<GamePathEntry> FileGamePaths { get; init; } = [];
    public List<GamePathEntry> FileSwaps { get; init; } = [];
}
