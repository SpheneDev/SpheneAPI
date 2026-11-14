namespace Sphene.API.Data.Enum;

/// <summary>Visibility state of a community comment.</summary>
public enum CommentState
{
    /// <summary>Normally readable.</summary>
    Visible = 0,
    /// <summary>Author removed their own comment - tombstone keeps the thread shape.</summary>
    AuthorDeleted = 1,
    /// <summary>Hidden by a moderator - reversible; members see a tombstone.</summary>
    ModeratorHidden = 2,
    /// <summary>Removed by a moderator - terminal; body is never served again.</summary>
    ModeratorRemoved = 3,
}
