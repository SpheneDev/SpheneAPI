namespace Sphene.API.Data.Enum;

/// <summary>
/// Structured, optional travel destination attached to a community event (or to
/// one occurrence exception of a recurring series). On occurrence overrides,
/// <see cref="None"/> doubles as the explicit "no structured destination for
/// this date" sentinel - a missing override means "inherit the series".
/// </summary>
public enum EventDestinationKind
{
    /// <summary>No structured destination (the free-text Location may still exist).</summary>
    None = 0,
    /// <summary>A residential housing address: world + district + ward + plot or apartment.</summary>
    HousingAddress = 1,
    /// <summary>A public, non-housing location - display-first; travel support is limited.</summary>
    PublicLocation = 2,
}
