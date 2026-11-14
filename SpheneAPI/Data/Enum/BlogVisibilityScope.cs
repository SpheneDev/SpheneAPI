namespace Sphene.API.Data.Enum;

/// <summary>
/// Who may read a user profile blog post - layered under the profile's
/// <c>ProfileVisibility.HideBlog</c> switch (that still wins outright).
/// </summary>
public enum BlogVisibilityScope
{
    /// <summary>Anyone who may view the profile.</summary>
    Public = 0,
    /// <summary>Paired users only.</summary>
    Pairs = 1,
    /// <summary>The author only (private journal).</summary>
    Private = 2,
}
