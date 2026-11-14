namespace Sphene.API.Data.Enum;

[Flags]
public enum GroupPairUserInfo
{
    None = 0x0,
    IsModerator = 0x2,
    IsPinned = 0x4,
    /// <summary>Holds at least one community staff-role assignment in this
    /// shell - an administrative affiliation, independent of moderator/pinned
    /// pair flags and of current area presence.</summary>
    IsStaff = 0x8
}
