namespace Sphene.API.Data.Enum;

/// <summary>
/// Who may read an event. <see cref="Members"/> restricts to shell members
/// (and staff); <see cref="Public"/> additionally surfaces the event on the
/// shell's publicly listed community page. RSVP stays member-only regardless.
/// </summary>
public enum EventVisibility
{
    Members = 0,
    Public = 1,
}
