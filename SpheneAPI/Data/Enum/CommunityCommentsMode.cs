namespace Sphene.API.Data.Enum;

/// <summary>Per-shell comment policy - who may write comments on community
/// content. Comment reads follow content visibility independently.</summary>
public enum CommunityCommentsMode
{
    /// <summary>All members may comment.</summary>
    Open = 0,
    /// <summary>Members may comment; same as Open today - reserved for future guest tiers.</summary>
    MembersOnly = 1,
    /// <summary>Only staff (owner/moderator/roles) may write comments.</summary>
    StaffOnly = 2,
    /// <summary>Comment writing disabled shell-wide.</summary>
    Disabled = 3,
}
