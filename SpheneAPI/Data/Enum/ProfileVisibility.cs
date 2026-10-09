namespace Sphene.API.Data.Enum;

/// <summary>
/// Bitmask of profile sections hidden from paired users. Default 0 = fully
/// visible, matching the behavior before per-section visibility existed.
/// </summary>
[Flags]
public enum ProfileVisibility : ushort
{
    None = 0,
    HideProfilePicture = 1 << 0,
    HideBanner = 1 << 1,
    HideDescription = 1 << 2,
    HideStatusMessage = 1 << 3,
    HideTags = 1 << 4,
}
