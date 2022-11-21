using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSignatures.Helper.Types;
public class M4a : Isobmff
{
	public M4a()
	{
        MediaType = "video/m4a";
        AddExtensions(".m4a");
        AddSignatures(
            new byte[] { 0x66, 0x74, 0x79, 0x70, 0x4D, 0x34, 0x41, 0x20 });
    }
}
