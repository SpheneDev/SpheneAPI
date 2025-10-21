namespace Sphene.API.Routes;

public class SpheneStatus
{
    public const string Status = "/status";
    public const string Status_GetCurrentOnlineStatus = "getCurrentOnlineStatus";
    public const string Status_SetOnlineStatus = "setOnlineStatus";
    public const string Status_GetAvailableStatuses = "getAvailableStatuses";
    public const string Status_GetCurrentStatusName = "getCurrentStatusName";
    
    public static Uri GetCurrentOnlineStatusFullPath(Uri baseUri) => new Uri(baseUri, Status + "/" + Status_GetCurrentOnlineStatus);
    public static Uri SetOnlineStatusFullPath(Uri baseUri) => new Uri(baseUri, Status + "/" + Status_SetOnlineStatus);
    public static Uri GetAvailableStatusesFullPath(Uri baseUri) => new Uri(baseUri, Status + "/" + Status_GetAvailableStatuses);
    public static Uri GetCurrentStatusNameFullPath(Uri baseUri) => new Uri(baseUri, Status + "/" + Status_GetCurrentStatusName);
}