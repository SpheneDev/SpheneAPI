namespace Sphene.API.Data.Enum;

/// <summary>
/// FFXIV residential districts as a Sphene-side contract. Derived from the
/// housing territory id stored in <c>LocationInfo.TerritoryId</c> /
/// <see cref="Dto.Group.EventDestinationDto.DistrictTerritoryId"/> - never
/// guessed: unmapped territories resolve to <see cref="Unknown"/> and fail closed.
/// </summary>
public enum ResidentialDistrict
{
    Unknown = 0,
    /// <summary>Mist - housing territory 339.</summary>
    Mist = 1,
    /// <summary>The Lavender Beds - housing territory 340.</summary>
    LavenderBeds = 2,
    /// <summary>The Goblet - housing territory 341.</summary>
    Goblet = 3,
    /// <summary>Shirogane - housing territory 641.</summary>
    Shirogane = 4,
    /// <summary>Empyreum - housing territory 979.</summary>
    Empyreum = 5,
}
