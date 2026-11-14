namespace Sphene.API.Data.Enum;

/// <summary>
/// Per-job capability flags for syncshell staff roles. The owner implicitly
/// holds all of them; moderators keep their built-in powers separately.
/// <see cref="ManageRoles"/> is the one that lets non-owners delegate.
/// </summary>
[Flags]
public enum SyncshellStaffPermission : long
{
    None = 0,
    /// <summary>Edit the community page itself (sections, texts, branding).</summary>
    ManagePage = 1L << 0,
    /// <summary>Create, edit and delete community events.</summary>
    ManageEvents = 1L << 1,
    /// <summary>Create, edit and delete community news posts.</summary>
    ManageNews = 1L << 2,
    /// <summary>Manage gallery images and albums, approve submissions.</summary>
    ManageGallery = 1L << 3,
    /// <summary>Edit staff roles and assign them to members.</summary>
    ManageRoles = 1L << 4,
    /// <summary>Gate for internal staff-only pages and tooling.</summary>
    AccessStaffArea = 1L << 5,
    /// <summary>Review and decide membership applications · grants no other admin power.</summary>
    ManageMembership = 1L << 6,
    /// <summary>Hide/restore/remove comments, lock threads, resolve reports - community-scoped only.</summary>
    ModerateContent = 1L << 7,
    /// <summary>Pin members and remove non-staff members from the shell.</summary>
    ManageMembers = 1L << 8,
    /// <summary>Ban and unban members.</summary>
    ManageBans = 1L << 9,
    /// <summary>Create one-time invites for the shell.</summary>
    ManageInvites = 1L << 10,
    /// <summary>Join policy, publishing policy and shell-level toggles.</summary>
    ManageSettings = 1L << 11,
}
