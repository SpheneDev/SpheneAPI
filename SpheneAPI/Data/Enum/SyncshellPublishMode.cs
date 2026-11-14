namespace Sphene.API.Data.Enum;

/// <summary>
/// How a syncshell handles new content of a given kind - configured per
/// content type in the shell's <see cref="Sphene.API.Dto.Group.SyncshellPublishingPolicyDto"/>.
/// </summary>
public enum SyncshellPublishMode
{
    /// <summary>Members publish straight to live.</summary>
    Direct = 0,
    /// <summary>Members submit; staff decide in the review queue.</summary>
    ApprovalRequired = 1,
    /// <summary>Only staff-bit holders may write at all.</summary>
    StaffOnly = 2,
}
