using MessagePack;

namespace Sphene.API.Dto.Group;

[MessagePackObject(keyAsPropertyName: true)]
public record AreaBoundSyncshellConsentDto
{
    public long Id { get; set; }
    public string UserUID { get; set; } = string.Empty;
    public string SyncshellGID { get; set; } = string.Empty;
    public bool HasAccepted { get; set; }
    public DateTime ConsentGivenAt { get; set; }
    public DateTime? LastRulesAcceptedAt { get; set; }
    public int AcceptedRulesVersion { get; set; }
}

[MessagePackObject(keyAsPropertyName: true)]
public record AreaBoundJoinConsentRequestDto
{
    public string SyncshellGID { get; set; } = string.Empty;
    public bool AcceptJoin { get; set; }
    public bool AcceptRules { get; set; }
    public int RulesVersion { get; set; }
}