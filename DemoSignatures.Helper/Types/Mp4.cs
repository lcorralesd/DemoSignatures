using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSignatures.Helper.Types;
public class Mp4 : Isobmff
{
	public Mp4()
	{
        MediaType = "video/mp4";
        AddExtensions(".mp4");
        AddSignatures(
            new byte[] { 0x66, 0x74, 0x79, 0x70, 0x69, 0x73, 0x6F, 0x6D });
    }
}
