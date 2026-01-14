using Sphene.API.Data;
using Sphene.API.Data.Enum;
using MessagePack;

namespace Sphene.API.Dto.User;

[MessagePackObject(keyAsPropertyName: true)]
public record UserFullPairDto(UserData User, IndividualPairStatus IndividualPairStatus, List<string> Groups, UserPermissions OwnPermissions, UserPermissions OtherPermissions, bool OtherAllowsReceivingPenumbraMods = true) : UserDto(User)
{
    public UserPermissions OwnPermissions { get; set; } = OwnPermissions;
    public UserPermissions OtherPermissions { get; set; } = OtherPermissions;
    public IndividualPairStatus IndividualPairStatus { get; set; } = IndividualPairStatus;
    public bool OtherAllowsReceivingPenumbraMods { get; set; } = OtherAllowsReceivingPenumbraMods;
}

[MessagePackObject(keyAsPropertyName: true)]
public record UserPenumbraReceivePreferenceDto(UserData User, bool AllowReceivingPenumbraMods);

[MessagePackObject(keyAsPropertyName: true)]
public record UserPairDto(UserData User, IndividualPairStatus IndividualPairStatus, UserPermissions OwnPermissions, UserPermissions OtherPermissions) : UserDto(User)
{
    public UserPermissions OwnPermissions { get; set; } = OwnPermissions;
    public UserPermissions OtherPermissions { get; set; } = OtherPermissions;
    public IndividualPairStatus IndividualPairStatus { get; set; } = IndividualPairStatus;
}
