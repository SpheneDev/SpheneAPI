namespace Sphene.API.Dto.Status;

public class OnlineStatusDto
{
    public uint StatusId { get; set; }
    public string StatusName { get; set; } = string.Empty;
}

public class SetOnlineStatusDto
{
    public uint StatusId { get; set; }
}

public class OnlineStatusResponseDto
{
    public bool Success { get; set; }
    public string Message { get; set; } = string.Empty;
    public uint? CurrentStatusId { get; set; }
    public string? CurrentStatusName { get; set; }
}

public class AvailableStatusesDto
{
    public Dictionary<uint, string> AvailableStatuses { get; set; } = new();
}