namespace Sphene.API.Data.Enum;

/// <summary>
/// How a syncshell accepts new members - per-shell setting on
/// <c>Group.JoinPolicy</c>. <see cref="PasswordProtected"/> is the default so
/// every existing shell keeps today's behavior after migration.
/// <c>InvitesEnabled=false</c> on the group still forces the effective policy
/// to <see cref="Closed"/> - legacy locked shells stay locked.
/// </summary>
public enum SyncshellJoinPolicy
{
    /// <summary>Join requires the shell password or a temp invite - original behavior.</summary>
    PasswordProtected = 0,
    /// <summary>Anyone may join directly - no password or invite needed.</summary>
    Public = 1,
    /// <summary>Join goes through a membership application approved by staff.</summary>
    ApprovalRequired = 2,
    /// <summary>Join only via a valid temp invite - the shell password is ignored.</summary>
    InviteOnly = 3,
    /// <summary>No new members are accepted through any path.</summary>
    Closed = 4,
}
