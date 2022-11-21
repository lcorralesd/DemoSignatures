using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSignatures.Helper.Types;
public class Odt : FileType
{
	public Odt()
	{
        Name = "Odt";
        Description = "Odt File";
        AddExtensions(".odt");
        AddSignatures(new byte[] { 0x50, 0x4B, 0x03, 0x04, 0x14, 0x00, 0x00, 0x08 });
    }
}
