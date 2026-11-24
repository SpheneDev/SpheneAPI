using Sphene.API.Data;
using Sphene.API.Data.Enum;
using Sphene.API.Dto;
using Sphene.API.Dto.Announcement;
using Sphene.API.Dto.CharaData;
using Sphene.API.Dto.Group;
using Sphene.API.Dto.User;
using Sphene.API.Dto.Files;

namespace Sphene.API.SignalR;

public interface ISpheneHub
{
    const int ApiVersion = 33;
    const string Path = "/sphene";

    Task<bool> CheckClientHealth();

    Task Client_DownloadReady(Guid requestId);
    Task Client_UserReceiveFileNotification(FileTransferNotificationDto notification);
    Task Client_GroupChangePermissions(GroupPermissionDto groupPermission);
    Task Client_GroupDelete(GroupDto groupDto);
    Task Client_GroupPairChangeUserInfo(GroupPairUserInfoDto userInfo);
    Task Client_GroupPairJoined(GroupPairFullInfoDto groupPairInfoDto);
    Task Client_GroupPairLeft(GroupPairDto groupPairDto);
    Task Client_GroupSendFullInfo(GroupFullInfoDto groupInfo);
    Task Client_GroupSendInfo(GroupInfoDto groupInfo);
    Task Client_ReceiveServerMessage(MessageSeverity messageSeverity, string message);
    Task Client_UpdateSystemInfo(SystemInfoDto systemInfo);
    Task Client_UserAddClientPair(UserPairDto dto);
    Task Client_UserReceiveCharacterData(OnlineUserCharaDataDto dataDto);
    Task Client_UserReceiveChatMessage(ChatMessageDto message);
    /// <summary>Pushed to a sender when the peer's client acknowledged
    /// delivery of their messages (delivery receipt).</summary>
    Task Client_UserChatDelivered(UserDto reader);
    /// <summary>Pushed to a sender when the peer marked their messages read
    /// (read receipt).</summary>
    Task Client_UserChatRead(UserDto reader);
    Task Client_UserReceiveCharacterDataAcknowledgment(CharacterDataAcknowledgmentDto acknowledgmentDto);
    Task Client_UserReceiveCharacterDataAcknowledgmentV2(CharacterDataAcknowledgmentEventDto acknowledgmentEventDto);
    Task Client_UserReceiveUploadStatus(UserUploadStatusDto dto);
    Task Client_UserRemoveClientPair(UserDto dto);
    Task Client_UserSendOffline(UserDto dto);
    Task Client_UserSendOnline(OnlineUserIdentDto dto);
    Task Client_UserUpdateOtherPairPermissions(UserPermissionsDto dto);
    Task Client_UpdateUserIndividualPairStatusDto(UserIndividualPairStatusDto dto);
    Task Client_UserUpdateProfile(UserDto dto);
    Task Client_UserAckYouUpdate(UserPermissionsDto dto);
    Task Client_UserUpdateSelfPairPermissions(UserPermissionsDto dto);
    Task Client_UserUpdateDefaultPermissions(DefaultPermissionsDto dto);
    Task Client_UserPenumbraReceivePreferenceUpdate(UserPenumbraReceivePreferenceDto dto);
    Task Client_UserSupporterStyleUpdate(UserSupporterStyleDto dto);
    Task Client_GroupChangeUserPairPermissions(GroupPairUserPermissionDto dto);
    Task Client_GposeLobbyJoin(UserData userData);
    Task Client_GposeLobbyLeave(UserData userData);
    Task Client_GposeLobbyPushCharacterData(CharaDataDownloadDto charaDownloadDto);
    Task Client_GposeLobbyPushPoseData(UserData userData, PoseData poseData);
    Task Client_GposeLobbyPushWorldData(UserData userData, WorldData worldData);
    Task Client_AreaBoundJoinRequest(AreaBoundJoinRequestDto dto);
    Task Client_AreaBoundJoinResponse(AreaBoundJoinResponseDto dto);
    Task Client_AreaBoundSyncshellBroadcast(AreaBoundBroadcastDto dto);
    Task Client_AreaBoundSyncshellConfigurationUpdate();

    // Mutual visibility status update pushed by server
    Task Client_UserMutualVisibilityUpdate(Sphene.API.Dto.Visibility.MutualVisibilityDto dto);

    Task Client_UserGposeStateUpdate(Sphene.API.Dto.User.UserGposeStateDto dto);

    Task Client_UserReceiveBypassEmote(BypassEmoteUpdateDto dto);
    Task Client_UserCharacterDataRefreshRequested(UserData requester);

    // Supporter status update pushed by server
    Task Client_UserUpdateSupporterStatus(bool isSupporter);

    // Pushed to all clients when a non-draft announcement is first published
    Task Client_AnnouncementPublished(AnnouncementDto dto);

    // Pushed when an announcement is edited or deleted · clients invalidate their cache
    Task Client_AnnouncementsChanged();

    // Pushed to syncshell members when community content changed · clients invalidate the affected shell's cache
    Task Client_CommunityChanged(CommunityChangedDto dto);

    // Pushed to online paired users when a user's alias or display name changed
    Task Client_UserIdentityUpdated(UserDto dto);

    Task<ConnectionDto> GetConnectionDto();

    Task GroupBanUser(GroupPairDto dto, string reason);
    Task GroupChangeGroupPermissionState(GroupPermissionDto dto);
    Task GroupChangeOwnership(GroupPairDto groupPair);
    Task<bool> GroupChangePassword(GroupPasswordDto groupPassword);
    Task GroupClear(GroupDto group);
    Task<GroupJoinDto> GroupCreate(GroupCreateDto? dto = null);
    Task<List<string>> GroupCreateTempInvite(GroupDto group, int amount);
    Task GroupDelete(GroupDto group);
    Task<List<BannedGroupUserDto>> GroupGetBannedUsers(GroupDto group);
    Task<GroupJoinInfoDto> GroupJoin(GroupPasswordDto passwordedGroup);
    Task<bool> GroupJoinFinalize(GroupJoinDto passwordedGroup);
    Task GroupLeave(GroupDto group);

    // Membership & join policy (Phase 1)
    Task<SyncshellJoinPolicy> GroupGetJoinPolicy(GroupDto group);
    Task<bool> GroupSetJoinPolicy(GroupJoinPolicyDto dto);
    Task<bool> GroupApplyForMembership(GroupApplyMembershipDto dto);
    Task<bool> GroupWithdrawMembershipApplication(GroupDto group);
    Task<MembershipApplicationDto?> GroupGetMyMembershipApplication(GroupDto group);
    Task<List<MembershipApplicationDto>> GroupGetMembershipApplications(GroupDto group);
    Task<MembershipApplicationDto?> GroupDecideMembershipApplication(GroupMembershipDecisionDto dto);
    Task GroupRemoveUser(GroupPairDto groupPair);
    Task GroupSetUserInfo(GroupPairUserInfoDto groupPair);
    Task<List<GroupFullInfoDto>> GroupsGetAll();
    Task GroupUnbanUser(GroupPairDto groupPair);
    Task<int> GroupPrune(GroupDto group, int days, bool execute);
    
    Task<bool> GroupSetAreaBinding(AreaBoundSyncshellDto areaBoundSyncshell);
    Task<bool> GroupRemoveAreaBinding(GroupDto group);
    Task<List<AreaBoundSyncshellDto>> GroupGetAreaBoundSyncshells();
    Task<bool> GroupRequestAreaBoundJoin(AreaBoundJoinRequestDto joinRequest);
    Task GroupRespondToAreaBoundJoin(AreaBoundJoinResponseDto joinResponse);
    Task BroadcastAreaBoundSyncshells(LocationInfo userLocation);

    Task UserAddPair(UserDto user);
    Task UserBlock(UserDto user);
    Task UserUnblock(UserDto user);
    Task<List<UserDto>> UserGetBlockedUsers();
    Task UserSendChatMessage(UserDto recipient, string message);
    Task<List<ChatMessageDto>> UserGetChatHistory(UserDto other, int skip = 0, int take = 50);
    Task UserMarkChatRead(UserDto other);
    /// <summary>Marks every incoming message from <paramref name="other"/> as
    /// delivered to this device/account - sent when the client receives or
    /// fetches rows, before they are opened. Read implies delivered.</summary>
    Task UserMarkChatDelivered(UserDto other);
    /// <summary>Unread incoming counts per conversation (paired and
    /// unblocked senders only). Lets a connecting client surface offline
    /// messages without opening every conversation.</summary>
    Task<List<ChatUnreadDto>> UserGetChatUnread();

    /// <summary>Registers/renews the caller's device E2EE public key.
    /// publicKey is the 65-byte uncompressed P-256 point.</summary>
    Task UserPublishChatDeviceKey(string deviceId, byte[] publicKey);
    /// <summary>Revokes one of the caller's own device keys; new messages can
    /// no longer be addressed to it (existing ciphertext stays readable for
    /// that device's private key holder).</summary>
    Task UserRevokeChatDeviceKey(string deviceId);
    /// <summary>Active device keys for the caller plus paired, unblocked UIDs.</summary>
    Task<List<ChatDeviceKeyDto>> UserGetChatDeviceKeys(List<string> uids);
    /// <summary>Sends a sealed message. Copies must address exactly the active
    /// devices of sender and recipient; the server never sees plaintext.
    /// <paramref name="sentAtUtc"/> is the sender's timestamp bound into the
    /// ciphertext's authenticated metadata - stored verbatim so recipients
    /// can verify it (server tolerates small clock skew).</summary>
    Task UserSendSealedChatMessage(UserDto recipient, Guid messageId,
        List<ChatCipherCopyDto> copies, DateTime sentAtUtc);
    /// <summary>Atomically claims a still-plaintext history row and replaces it
    /// with sealed copies produced by the caller. Idempotent.</summary>
    Task<bool> UserMigrateChatMessage(Guid messageId, List<ChatCipherCopyDto> copies);
    /// <summary>Compare-and-swap write of the caller's encrypted chat key
    /// backup: applies only while <paramref name="expectedRevision"/> still
    /// matches the stored revision (0 = create-only-when-absent). Opaque
    /// ciphertext to the server - the wrap key is derived client-side from
    /// the secret key, of which only a hash reaches the server. Conflicts
    /// return the current revision and blob for a merge retry.</summary>
    Task<ChatKeyBackupResult> UserPutChatKeyBackup(byte[] blob,
        long expectedRevision);
    /// <summary>The caller's encrypted chat key backup plus its server
    /// revision; null when none was uploaded yet.</summary>
    Task<ChatKeyBackupDto?> UserGetChatKeyBackup();
    Task<AliasAvailabilityResult> UserCheckAliasAvailability(string alias);
    Task UserDelete();
    Task<List<OnlineUserIdentDto>> UserGetOnlinePairs(CensusDataDto? censusDataDto);
    Task<List<UserFullPairDto>> UserGetPairedClients();
    Task<UserProfileDto> UserGetProfile(UserDto dto);
    /// <summary>Bounded public-profile search over Community-Hub-visible
    /// (opt-in) profiles - matches display name/alias, returns slim rows.</summary>
    Task<List<PublicProfileSummaryDto>> UserSearchPublicProfiles(PublicProfileSearchDto dto);
    /// <summary>Slim public profile view (identity, avatar, banner, bio, tags,
    /// public owned Chronicles). Null when the target is not publicly
    /// available - private, blocked either direction, disabled, flagged.</summary>
    Task<PublicProfileDto?> UserGetPublicProfile(UserDto dto);
    /// <summary>Immediate unilateral follow/unfollow of a public profile.
    /// Idempotent; grants no pair/chat/sync rights. False = rejected
    /// (self-follow or target not currently publicly visible).</summary>
    Task<bool> UserSetProfileFollow(UserProfileFollowDto dto);
    /// <summary>"Following" feed page - public Chronicles of followed,
    /// currently public users. Same keyset cursor contract as the
    /// community feed; the cursor is scoped to this query.</summary>
    Task<SyncshellCommunityFeedPageDto> UserGetFollowingFeed(FeedPageRequestDto dto);
    /// <summary>"For You" digest - a server-ranked top-N slice across the
    /// caller's community content and followed authors. Score = engagement
    /// (reactions/comments/views) times recency decay; followed authors get
    /// a boost. Ranked, not paged: <c>NextCursor</c> is always null.</summary>
    Task<SyncshellCommunityFeedPageDto> UserGetForYouFeed(FeedPageRequestDto dto);

    /// <summary>Activates the one-time 24h supporter trial - idempotent for
    /// supporters and already-used trials; returns the stamped start.</summary>
    Task<DateTime?> UserActivateSupporterTrial();
    Task UserPushData(UserCharaDataMessageDto dto);
    Task UserRequestCharacterDataRefresh(UserDto userDto);
    Task UserSendCharacterDataAcknowledgmentV2(CharacterDataAcknowledgmentEventDto acknowledgmentEventDto);
    Task UserRemovePair(UserDto userDto);
    Task<SetAliasResult> UserRenameAlias(string newAlias);
    Task<SetAliasResult> UserSetAlias(string alias);
    Task UserSetDisplayName(string? displayName);
    Task UserSetProfile(UserProfileDto userDescription);
    Task UserUpdateDefaultPermissions(DefaultPermissionsDto defaultPermissionsDto);
    Task SetBulkPermissions(BulkPermissionsDto dto);

    Task<CharaDataFullDto?> CharaDataCreate();
    Task<CharaDataFullDto?> CharaDataUpdate(CharaDataUpdateDto updateDto);
    Task<bool> CharaDataDelete(string id);
    Task<CharaDataMetaInfoDto?> CharaDataGetMetainfo(string id);
    Task<CharaDataDownloadDto?> CharaDataDownload(string id);
    Task<List<CharaDataFullDto>> CharaDataGetOwn();
    Task<List<CharaDataMetaInfoDto>> CharaDataGetShared();
    Task<CharaDataFullDto?> CharaDataAttemptRestore(string id);

    Task<string> GposeLobbyCreate();
    Task<List<UserData>> GposeLobbyJoin(string lobbyId);
    Task<bool> GposeLobbyLeave();
    Task GposeLobbyPushCharacterData(CharaDataDownloadDto charaDownloadDto);
    Task GposeLobbyPushPoseData(PoseData poseData);
    Task GposeLobbyPushWorldData(WorldData worldData);

    Task UserUpdateAckYou(bool ackYou);
    Task UserUpdatePenumbraReceivePreference(bool allowMods);
    Task UserUpdateSupporterStyle(SupporterStyleDto? style);
    Task<List<SupporterIconInfoDto>> SupporterGetIcons();
    Task<byte[]?> SupporterGetIconFile(string iconId);

    Task UserUpdateGposeState(bool isInGpose);
    
    Task<List<UserHousingPropertyDto>> UserGetHousingProperties();
    Task<UserHousingPropertyDto?> UserSetHousingProperty(UserHousingPropertyUpdateDto dto);
    Task<bool> UserDeleteHousingProperty(LocationInfo location);

    Task<List<AnnouncementDto>> GetAnnouncements(int skip = 0, int take = 20);
    Task<List<AnnouncementDto>> AdminGetAnnouncements(int skip = 0, int take = 50);
    Task<long?> AdminCreateAnnouncement(AnnouncementUpsertDto dto);
    Task<bool> AdminUpdateAnnouncement(AnnouncementUpsertDto dto);
    Task<bool> AdminDeleteAnnouncement(long id);

    // Pushed to a recipient when a durable notification was created for them
    Task Client_UserNotification(UserNotificationDto dto);

    Task<List<UserNotificationDto>> UserGetNotifications(int take = 50);
    Task UserMarkNotificationsRead(List<long> ids);
    Task UserClearNotifications();

    // Phase 2 - publishing pipeline
    Task<SyncshellPublishingPolicyDto> GroupGetPublishingPolicy(GroupDto dto);
    Task<bool> GroupSetPublishingPolicy(SyncshellPublishingPolicyDto dto);
    Task<SyncshellNewsPostDto?> GroupSubmitCommunityNews(SyncshellNewsPostUpdateDto dto);
    Task<bool> GroupDecideCommunityNews(CommunityReviewDecisionDto dto);
    Task<CommunityReviewQueueDto> GroupGetCommunityReviewQueue(GroupDto dto);
    Task<SyncshellGalleryImageDto?> GroupSubmitCommunityGalleryImage(SyncshellGalleryImageUpdateDto dto);
    Task<bool> GroupDecideCommunityGalleryImage(CommunityReviewDecisionDto dto);
    Task<List<EntityCardDto>> EntityResolveReferences(List<string> tokens);
    Task<CommunityMediaUploadInfoDto> GroupGetCommunityMediaUploadInfo(GroupDto dto);

    // Phase 3 - events: RSVP, participants, calendar, member submission
    Task<SyncshellEventDto?> GroupSubmitCommunityEvent(SyncshellEventUpdateDto dto);
    Task<bool> GroupDecideCommunityEvent(CommunityReviewDecisionDto dto);
    Task<EventParticipantsDto> GroupSetEventRsvp(EventRsvpDto dto);
    Task<EventParticipantsDto> GroupGetEventParticipants(EventRsvpDto dto);
    Task<EventParticipantsDto> GroupUpdateEventParticipant(EventRsvpDto dto);
    Task<List<SyncshellEventOccurrenceDto>> GroupGetEventCalendar(SyncshellEventCalendarRequestDto dto);
    Task<bool> GroupUpsertEventException(SyncshellEventExceptionDto dto);

    // Phase 4 - comments: paginated read + upsert/delete + moderation
    Task<CommentPageDto> GetComments(CommentPageRequestDto dto);
    Task<CommentPageDto> GetCommentReplies(CommentPageRequestDto dto);
    Task<CommunityCommentDto?> UpsertComment(CommentUpsertDto dto);
    Task<bool> DeleteComment(CommentUpsertDto dto);
    Task<CommunityCommentDto?> SetCommentModeration(CommentModerationDto dto);

    // Phase 4 - reactions: state-based writes + aggregate/who-read
    Task<ReactionSummaryDto> SetReaction(ReactionSetDto dto);
    Task<ReactionSummaryDto> GetReactionSummary(ReactionSetDto dto);
    Task<ReactionUsersDto> GetReactionUsers(ReactionUsersRequestDto dto);

    // Phase 4 - reports + moderation queues (community + platform)
    Task<bool> ReportContent(ReportCreateDto dto);
    Task<ModerationQueueDto> GetModerationQueue(GroupDto dto);
    Task<bool> ResolveReport(ReportDecisionDto dto);
    Task<PlatformReportQueueDto> GetPlatformReportQueue();
    Task<bool> ResolvePlatformReport(ReportDecisionDto dto);

    // Phase 4 - user-facing notification mute controls
    Task<bool> UserSetNotificationMutes(long disabledKindsMask);

    /// <summary>Marks one Chronicle as seen by the caller - deduplicated per
    /// (post, viewer), self-views and posts outside the caller's visibility
    /// scope never count.</summary>
    Task UserMarkBlogPostViewed(long postId);

    // Phase 5 - community experience: keyset-paged feed v2 (opaque cursor).
    // GroupGetCommunityFeed was already callable by name since v1.1.29;
    // v39 formalizes it in the interface (no wire change).
    Task<SyncshellCommunityFeedDto> GroupGetCommunityFeed();
    Task<SyncshellCommunityFeedPageDto> GroupGetCommunityFeedPage(FeedPageRequestDto dto);
    // Earliest eligible upcoming community event for the "Upcoming event"
    // highlight tile - resolved server-side so feed paging can't hide it.
    // Null when the caller has no eligible future event.
    Task<SyncshellCommunityFeedItemDto?> GroupGetNextCommunityEvent();

    // GroupGetCommunityProfile is deliberately name-invoked like
    // GroupGetCommunity - a slim profile read for list/card surfaces.

    // Phase 5 - read path for the v38 mute setter
    Task<long> UserGetNotificationMutes();

    // Phase 5 - profile activity tab: narrow target-uid request; the server
    // loads the profile, gates ProfileVisibility + UserBlock (both ways) and
    // applies per-target ACL to every row. Inaccessible profile and empty
    // activity degrade to the same empty page - no existence disclosure.
    Task<SyncshellCommunityFeedPageDto> UserGetProfileActivity(string targetUid, FeedPageRequestDto dto);
}
