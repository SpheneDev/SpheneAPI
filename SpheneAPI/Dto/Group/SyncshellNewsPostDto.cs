using Sphene.API.Data;
using MessagePack;

namespace Sphene.API.Dto.Group;

[MessagePackObject(keyAsPropertyName: true)]
public record SyncshellNewsPostDto(
    long Id,
    string GroupGID,
    string Title,
    string Body,
    bool IsPinned,
    DateTime PublishedAt,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    bool IsDraft = false,
    /// <summary><see cref="Sphene.API.Data.Enum.ContentPublishStatus"/> as int.</summary>
    int Status = 0,
    string? AuthorUid = null,
    DateTime? ScheduledForUtc = null,
    List<string>? CoAuthorUids = null,
    string? ReviewedByUid = null,
    string? ReviewNote = null,
    /// <summary>Denormalized comment count + thread lock (Phase 4).</summary>
    int CommentCount = 0,
    bool CommentsLocked = false
);

[MessagePackObject(keyAsPropertyName: true)]
public record SyncshellNewsPostUpdateDto(
    long Id,
    GroupData Group,
    string Title,
    string Body,
    bool IsPinned,
    DateTime? PublishedAt,
    bool IsDraft = false,
    /// <summary>Requested intent - submit-for-review vs save-draft vs publish.
    /// The server recomputes the effective status from policy + rights; the
    /// client can never write a status directly.</summary>
    int? StatusIntent = null,
    DateTime? ScheduledForUtc = null,
    List<string>? CoAuthorUids = null
) : GroupDto(Group);
