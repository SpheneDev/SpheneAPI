namespace Sphene.API.Data.Enum;

/// <summary>
/// Bridge between the legacy predefined <see cref="ReactionKind"/> writes and
/// the emoji-glyph reaction identity. Post-migration every reaction row is
/// keyed by its emoji glyph; legacy kind writes translate through this map so
/// old and new clients always land on the same row. The glyphs are the
/// chat-emoji catalog entries (atlas keys 1f44d / 2764 / 1f602 / 1f62e /
/// 1f622), so every migrated reaction renders as the emoji a user would
/// have picked from the picker.
/// </summary>
public static class ReactionEmojiMap
{
    /// <summary>The Like glyph - the quick-action reaction in feed rows.</summary>
    public const string ThumbsUp = "👍";

    public static string ForKind(ReactionKind kind) => kind switch
    {
        ReactionKind.Like => "👍",
        ReactionKind.Love => "❤",
        ReactionKind.Laugh => "😂",
        ReactionKind.Wow => "😮",
        ReactionKind.Sad => "😢",
        _ => "👍",
    };

    /// <summary>Reverse lookup for back-compat aggregation: an emoji glyph
    /// that exactly matches a legacy canonical glyph counts toward that
    /// kind in the int-keyed summary old clients read.</summary>
    public static ReactionKind? KindFor(string emoji) => emoji switch
    {
        "👍" => ReactionKind.Like,
        "❤" => ReactionKind.Love,
        "😂" => ReactionKind.Laugh,
        "😮" => ReactionKind.Wow,
        "😢" => ReactionKind.Sad,
        _ => null,
    };
}
