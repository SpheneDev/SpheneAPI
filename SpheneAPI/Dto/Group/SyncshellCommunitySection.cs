using MessagePack;

namespace Sphene.API.Dto.Group;

/// <summary>Toggleable content blocks on a syncshell community page.</summary>
public enum SyncshellCommunitySection
{
    About = 0,
    Rules = 1,
    Links = 2,
    News = 3,
    Events = 4,
    Gallery = 5,
    Staff = 6,
}
