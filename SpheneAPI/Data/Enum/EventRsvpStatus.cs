namespace Sphene.API.Data.Enum;

/// <summary>
/// RSVP state of a participant row. <see cref="Waitlist"/> is server-assigned
/// only - clients can never write it directly; the hub coerces
/// <see cref="Attending"/> into a waitlist slot when capacity is exhausted.
/// </summary>
public enum EventRsvpStatus
{
    Attending = 0,
    Interested = 1,
    NotAttending = 2,
    Waitlist = 3,
}
