using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSignatures.Helper.Types;
public class Bmp : FileType
{
	public Bmp()
	{
		Name = "BMP";
		Description = "BMP Image";
		AddExtensions("bmp");
		AddSignatures(new byte[] { 0x42, 0x4D });
	}
}
