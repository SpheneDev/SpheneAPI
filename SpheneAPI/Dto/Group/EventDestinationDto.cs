using Sphene.API.Data.Enum;
using MessagePack;

namespace Sphene.API.Dto.Group;

/// <summary>
/// A normalized, travel-ready residential housing address resolved from an
/// <see cref="EventDestinationDto"/> of kind <see cref="EventDestinationKind.HousingAddress"/>.
/// Ward is 1-based (1-30); Plot is 1-based (1-60, values &gt;30 being the
/// subdivision side); <see cref="Room"/> is the apartment room number when
/// <see cref="IsApartment"/> is set, otherwise an interior room number that
/// travel providers may treat as display-only.
/// </summary>
public readonly record struct HousingDestinationAddress(
    ResidentialDistrict District,
    uint WorldId,
    int Ward,
    bool IsApartment,
    int Plot,
    int Room,
    bool ApartmentSubdivision);

/// <summary>
/// Optional structured travel destination on a community event (or an
/// occurrence exception). Stored server-side as a JSON snapshot - always
/// validated through <see cref="EventDestinationValidator"/> before use.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record EventDestinationDto
{
    /// <summary><see cref="EventDestinationKind"/> as int.</summary>
    public int Kind { get; set; } = (int)EventDestinationKind.None;

    /// <summary>World sheet row id of the property (housing addresses).</summary>
    public uint WorldId { get; set; }

    /// <summary>District territory id - one of 339/340/341/641/979.</summary>
    public uint DistrictTerritoryId { get; set; }

    /// <summary>Ward number, 1-based (1-30).</summary>
    public int Ward { get; set; }

    /// <summary>True when the address targets an apartment unit.</summary>
    public bool IsApartment { get; set; }

    /// <summary>Plot number, 1-based (1-60); unused when <see cref="IsApartment"/>.</summary>
    public int Plot { get; set; }

    /// <summary>Apartment room number (apartments) or interior room number of
    /// a house (display-only, e.g. FC chambers); 0 = none.</summary>
    public int Room { get; set; }

    /// <summary>Apartment subdivision wing (apartments only).</summary>
    public bool ApartmentSubdivision { get; set; }

    /// <summary>Target territory for <see cref="EventDestinationKind.PublicLocation"/>.</summary>
    public uint TerritoryId { get; set; }

    /// <summary>Nearest aetheryte sheet row id, when known (0 = none).</summary>
    public uint AetheryteId { get; set; }

    /// <summary>Optional map coordinates for display (0 = unset).</summary>
    public float MapX { get; set; }
    public float MapY { get; set; }

    /// <summary>Optional human-readable label (≤200 chars).</summary>
    public string? DisplayLabel { get; set; }
}

/// <summary>
/// Shared destination validation + normalization - used by the server when
/// persisting and by the client before presenting or traveling. Never guesses
/// missing values: unmapped districts, out-of-range fields and incomplete
/// addresses fail closed.
/// </summary>
public static class EventDestinationValidator
{
    public const int MinWard = 1;
    public const int MaxWard = 30;
    public const int MinPlot = 1;
    public const int MaxPlot = 60;
    public const int MinRoom = 1;
    public const int MaxRoom = 999;
    public const int MaxDisplayLabelLength = 200;

    /// <summary>Returns the <see cref="ResidentialDistrict"/> for a housing
    /// territory id, or <see cref="ResidentialDistrict.Unknown"/> for anything
    /// else (non-housing territories, future districts not yet mapped).</summary>
    public static ResidentialDistrict DistrictFromTerritoryId(uint territoryId) => territoryId switch
    {
        339u => ResidentialDistrict.Mist,
        340u => ResidentialDistrict.LavenderBeds,
        341u => ResidentialDistrict.Goblet,
        641u => ResidentialDistrict.Shirogane,
        979u => ResidentialDistrict.Empyreum,
        _ => ResidentialDistrict.Unknown,
    };

    /// <summary>
    /// Normalizes a destination for storage/use - returns null when the input
    /// is null, has an undefined <see cref="EventDestinationDto.Kind"/>, or is
    /// <see cref="EventDestinationKind.None"/>. Irrelevant fields are zeroed so
    /// snapshots stay canonical; out-of-range required fields reject the DTO.
    /// </summary>
    public static EventDestinationDto? Sanitize(EventDestinationDto? dto)
    {
        if (dto == null || !System.Enum.IsDefined((EventDestinationKind)dto.Kind)
            || (EventDestinationKind)dto.Kind == EventDestinationKind.None)
        {
            return null;
        }

        var label = string.IsNullOrWhiteSpace(dto.DisplayLabel)
            ? null
            : dto.DisplayLabel.Trim();
        if (label != null && label.Length > MaxDisplayLabelLength)
        {
            label = label[..MaxDisplayLabelLength];
        }

        if ((EventDestinationKind)dto.Kind == EventDestinationKind.HousingAddress)
        {
            if (dto.WorldId == 0 || dto.WorldId > ushort.MaxValue) return null;
            if (DistrictFromTerritoryId(dto.DistrictTerritoryId) == ResidentialDistrict.Unknown) return null;
            if (dto.Ward is < MinWard or > MaxWard) return null;
            if (dto.IsApartment)
            {
                if (dto.Room is < MinRoom or > MaxRoom) return null;
                return new EventDestinationDto
                {
                    Kind = dto.Kind,
                    WorldId = dto.WorldId,
                    DistrictTerritoryId = dto.DistrictTerritoryId,
                    Ward = dto.Ward,
                    IsApartment = true,
                    Room = dto.Room,
                    ApartmentSubdivision = dto.ApartmentSubdivision,
                    DisplayLabel = label,
                };
            }
            if (dto.Plot is < MinPlot or > MaxPlot) return null;
            if (dto.Room is < 0 or > MaxRoom) return null;
            return new EventDestinationDto
            {
                Kind = dto.Kind,
                WorldId = dto.WorldId,
                DistrictTerritoryId = dto.DistrictTerritoryId,
                Ward = dto.Ward,
                Plot = dto.Plot,
                Room = dto.Room,
                DisplayLabel = label,
            };
        }

        if (dto.TerritoryId == 0 || dto.TerritoryId > uint.MaxValue) return null;
        return new EventDestinationDto
        {
            Kind = dto.Kind,
            TerritoryId = dto.TerritoryId,
            AetheryteId = dto.AetheryteId,
            MapX = dto.MapX,
            MapY = dto.MapY,
            DisplayLabel = label,
        };
    }

    /// <summary>
    /// Resolves a destination to a normalized <see cref="HousingDestinationAddress"/>
    /// for travel adapters - false for non-housing kinds or invalid data.
    /// </summary>
    public static bool TryResolveHousingAddress(EventDestinationDto? dto,
        out HousingDestinationAddress address)
    {
        address = default;
        var clean = Sanitize(dto);
        if (clean == null || (EventDestinationKind)clean.Kind != EventDestinationKind.HousingAddress)
        {
            return false;
        }
        address = new HousingDestinationAddress(
            DistrictFromTerritoryId(clean.DistrictTerritoryId),
            clean.WorldId, clean.Ward, clean.IsApartment, clean.Plot,
            clean.Room, clean.ApartmentSubdivision);
        return true;
    }
}
