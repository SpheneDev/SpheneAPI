using Sphene.API.Dto.CharaData;
using MessagePack;

namespace Sphene.API.Dto.User;

[MessagePackObject]
public record UserHousingPropertyDto
{
    [Key(0)] public required long Id { get; set; }
    [Key(1)] public required LocationInfo Location { get; set; }
    [Key(2)] public required bool AllowOutdoor { get; set; }
    [Key(3)] public required bool AllowIndoor { get; set; }
    [Key(4)] public required bool PreferOutdoorSyncshells { get; set; }
    [Key(5)] public required bool PreferIndoorSyncshells { get; set; }
    [Key(6)] public required DateTime CreatedAt { get; set; }
    [Key(7)] public required DateTime UpdatedAt { get; set; }
}

[MessagePackObject]
public record UserHousingPropertyUpdateDto
{
    [Key(0)] public required LocationInfo Location { get; set; }
    [Key(1)] public required bool AllowOutdoor { get; set; }
    [Key(2)] public required bool AllowIndoor { get; set; }
    [Key(3)] public required bool PreferOutdoorSyncshells { get; set; }
    [Key(4)] public required bool PreferIndoorSyncshells { get; set; }
}