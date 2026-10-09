using Sphene.API.Data;
using MessagePack;

namespace Sphene.API.Dto.User;

[MessagePackObject(keyAsPropertyName: true)]
public class SupporterStyleDto
{
    public bool IndicatorsEnabled { get; set; } = true;
    public string SymbolChar { get; set; } = string.Empty;
    public int SymbolPosition { get; set; }
    public bool TextEnabled { get; set; }
    public string LabelText { get; set; } = string.Empty;
    public int LabelOrder { get; set; }
    public int SymbolColorKey { get; set; } = 43;
    public int LabelColorKey { get; set; } = 43;
    public bool SymbolGlowEnabled { get; set; }
    public int SymbolGlowKey { get; set; }
    public bool LabelGlowEnabled { get; set; }
    public int LabelGlowKey { get; set; }
    public bool IconEnabled { get; set; } = true;
    public string IconId { get; set; } = string.Empty;
    public bool IconLabelEnabled { get; set; }
    public string IconLabelText { get; set; } = string.Empty;
    public uint IconLabelColor { get; set; } = 0xFFFFFFFFu;
}

[MessagePackObject(keyAsPropertyName: true)]
public record UserSupporterStyleDto(UserData User, SupporterStyleDto? Style) : UserDto(User);
