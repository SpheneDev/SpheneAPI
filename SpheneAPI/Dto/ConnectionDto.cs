using Sphene.API.Data;
using MessagePack;

namespace Sphene.API.Dto;

[MessagePackObject(keyAsPropertyName: true)]
public record ConnectionDto(UserData User)
{
    public Version CurrentClientVersion { get; set; } = new(0, 0, 0);
    public int ServerVersion { get; set; }
    public bool IsAdmin { get; set; }
    public bool IsModerator { get; set; }
    public bool IsSupporter { get; set; }

    /// <summary>Server-stamped start of the one-time 24h supporter trial -
    /// non-null once used; the client derives active/expired from it.</summary>
    public DateTime? SupporterTrialStartUtc { get; set; }

    public bool RequiresAliasSetup { get; set; }
    public DateTime? AliasChangeAvailableAt { get; set; }
    public ServerInfo ServerInfo { get; set; } = new();
    public DefaultPermissionsDto DefaultPreferredPermissions { get; set; } = new();
}

[MessagePackObject(keyAsPropertyName: true)]
public record ServerInfo
{
    public string ShardName { get; set; } = string.Empty;
    public int MaxGroupUserCount { get; set; }
    public int MaxGroupsCreatedByUser { get; set; }
    public int MaxGroupsJoinedByUser { get; set; }
    public Uri FileServerAddress { get; set; } = new Uri("http://nonemptyuri");
    public Uri? FileServerFallbackAddress { get; set; } = null;
    public int MaxCharaData { get; set; }
    public int MaxCharaDataVanity { get; set; }
    public bool SupporterFeaturesEnabled { get; set; }

    /// <summary>Whether this user may use the private-chat GIF feature:
    /// server GIF service enabled AND (public release enabled OR the user's
    /// gif_beta_enabled flag). Stamped per connection.</summary>
    public bool GifEnabled { get; set; }

    /// <summary>Optional operator-published GIF-provider API key for
    /// client-side GIF search (empty = GIF search unavailable). Plain key,
    /// not a secret - but only shipped to clients with
    /// <see cref="GifEnabled"/>; the sealed message payload identifies
    /// which provider the key is for.</summary>
    public string GifApiKey { get; set; } = string.Empty;

    /// <summary>Operator-configured assumed request budget per hour for the
    /// GIF API key, surfaced in client diagnostics as a local estimate only
    /// (KLIPY test keys cap at 100/hour; 0 = no estimate shown).</summary>
    public int GifTestKeyLimit { get; set; }

    /// <summary>Public profiles/follow capability: the hub exposes
    /// UserSearchPublicProfiles/UserGetPublicProfile/UserSetProfileFollow/
    /// UserGetFollowingFeed. Additive contract - the hub ApiVersion stays
    /// unchanged, older servers report false and clients gate the UI.</summary>
    public bool PublicProfilesEnabled { get; set; }
}
