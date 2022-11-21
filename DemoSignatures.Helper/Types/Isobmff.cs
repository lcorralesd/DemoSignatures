using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSignatures.Helper.Types;
public class Isobmff : FileType
{
	public Isobmff()
	{
		Name = "ISOBMFF";
		Description = "ISO/IEC base media file format";
		Offset = 4;
    }
}
