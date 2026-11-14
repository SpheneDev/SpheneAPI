namespace Sphene.API.Data.Enum;

/// <summary>
/// Kind of an entity reference token inside community markdown bodies.
/// Parsed and resolved server-side with visibility checks.
/// </summary>
public enum EntityRefKind
{
    /// <summary>Unparseable or unsupported token.</summary>
    Unknown = 0,
    /// <summary><c>@uidOrAlias</c> - user profile.</summary>
    User = 1,
    /// <summary><c>#gidOrAlias</c> - syncshell community page.</summary>
    Syncshell = 2,
    /// <summary><c>event:{id}</c> - community event.</summary>
    Event = 3,
    /// <summary><c>post:{id}</c> - syncshell news post.</summary>
    NewsPost = 4,
    /// <summary><c>blog:{uid}:{id}</c> - user profile blog post.</summary>
    BlogPost = 5,
    /// <summary><c>announcement:{id}</c> - platform announcement.</summary>
    Announcement = 6,
}
