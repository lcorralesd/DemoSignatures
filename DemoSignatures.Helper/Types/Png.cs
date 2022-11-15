using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSignatures.Helper.Types;
public class Png : FileType
{
	public Png()
	{
		Name = "PNG";
		Description = "PNG Image";
		AddExtensions("png");
		AddSignatures(new byte[] { 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A });

	}
}
