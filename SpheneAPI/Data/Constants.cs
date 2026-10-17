namespace Sphene.API.Data;

public class Constants
{
    public const string IndividualKeyword = "//SPHENE//DIRECT";

    public const int AliasMinLength = 5;
    public const int AliasMaxLength = 15;
    public const int DisplayNameMaxLength = 64;
    public const int AliasRenameCooldownDays = 30;
    public const string AliasValidationPattern = @"^[A-Za-z0-9_.\-]{5,15}$";
}
