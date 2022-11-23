using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSignatures.Helper.Types;
public class Mz : FileType
{
	public Mz()
	{
		Name = "Executable";
		Description = "COM, DLL, DRV, EXE, PIF, QTS, QTX, SYS";
		AddExtensions(".com, .dll, .drv, .exe, .pif, .qts, .qtx, .sys");
		AddSignatures(new byte[] { 0x4D, 0x5A });

	}
}
