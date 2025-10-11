using Sphene.API.Data;
using Sphene.API.Data.Enum;
using Sphene.API.Dto.CharaData;
using MessagePack;

namespace Sphene.API.Dto.Group;

[MessagePackObject(keyAsPropertyName: true)]
public record AreaBoundLocationDto
{
    public int Id { get; set; }
    public LocationInfo Location { get; set; } = new();
    public AreaMatchingMode MatchingMode { get; set; } = AreaMatchingMode.ExactMatch;
    public string? LocationName { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}

[MessagePackObject(keyAsPropertyName: true)]
public record AreaBoundSyncshellDto(GroupData Group, List<AreaBoundLocationDto> BoundAreas) : GroupDto(Group)
{
    public List<AreaBoundLocationDto> BoundAreas { get; set; } = BoundAreas;
    public bool IsAreaBound { get; set; } = true;
    public AreaBoundSettings Settings { get; set; } = new();
}

[MessagePackObject(keyAsPropertyName: true)]
public record AreaBoundSettings
{
    public bool AutoBroadcastEnabled { get; set; } = true;
    public bool RequireOwnerPresence { get; set; } = false;
    public int MaxAutoJoinUsers { get; set; } = 50;
    public bool NotifyOnUserEnter { get; set; } = true;
    public bool NotifyOnUserLeave { get; set; } = true;
    public string? CustomJoinMessage { get; set; }
    
    // Rules and consent system
    public string? JoinRules { get; set; }
    public int RulesVersion { get; set; } = 1;
    public bool RequireRulesAcceptance { get; set; } = false;
}

public enum AreaMatchingMode
{
    ExactMatch = 0,        // Exact territory, map, server match
    TerritoryOnly = 1,     // Only territory must match
    ServerAndTerritory = 2, // Server and territory must match
    HousingWardOnly = 3,   // For housing areas, only ward must match
    HousingPlotOnly = 4,   // For housing areas, only specific plot (both indoor and outdoor)
    HousingPlotOutdoor = 5, // For housing areas, only outdoor plot area
    HousingPlotIndoor = 6   // For housing areas, only indoor house area
}

[MessagePackObject(keyAsPropertyName: true)]
public record AreaBoundJoinRequestDto(GroupData Group, UserData User, LocationInfo UserLocation) : GroupPairDto(Group, User)
{
    public LocationInfo UserLocation { get; set; } = UserLocation;
    public DateTime RequestTime { get; set; } = DateTime.UtcNow;
}

[MessagePackObject(keyAsPropertyName: true)]
public record AreaBoundJoinResponseDto(GroupData Group, UserData User, bool Accepted, string? Reason = null) : GroupPairDto(Group, User)
{
    public bool Accepted { get; set; } = Accepted;
    public string? Reason { get; set; } = Reason;
}

[MessagePackObject(keyAsPropertyName: true)]
public record AreaBoundBroadcastDto(GroupData Group, LocationInfo Area, List<UserData> UsersInArea) : GroupDto(Group)
{
    public LocationInfo Area { get; set; } = Area;
    public List<UserData> UsersInArea { get; set; } = UsersInArea;
    public DateTime BroadcastTime { get; set; } = DateTime.UtcNow;
}