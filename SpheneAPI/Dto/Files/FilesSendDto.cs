using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sphene.API.Dto.Files;

public class FilesSendDto
{
    public List<string> FileHashes { get; set; } = new();
    public List<string> UIDs { get; set; } = new();
    public Dictionary<string, string>? ModFolderNames { get; set; }
    public List<ModInfoDto>? ModInfo { get; set; }
}
