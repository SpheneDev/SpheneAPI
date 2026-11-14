namespace Sphene.API.Data.Enum;

/// <summary>
/// Lifecycle of a <c>GroupMembershipApplication</c>. Values are stable -
/// persisted in the entity's Status column.
/// </summary>
public enum MembershipApplicationStatus
{
    Pending = 0,
    Approved = 1,
    Rejected = 2,
    Withdrawn = 3,
}
