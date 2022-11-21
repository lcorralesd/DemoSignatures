using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSignatures.Helper.Types;
public class Zip : FileType
{
	public Zip()
	{
		Name = "ZIP";
		Description = "ZIP File";
		AddExtensions(".zip");
		AddSignatures(new byte[] { 0x50, 0x4B, 0x03, 0x04 });
	}
}
