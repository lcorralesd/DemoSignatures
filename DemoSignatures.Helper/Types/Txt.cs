using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSignatures.Helper.Types;
public class Txt : FileType
{
	public Txt()
	{
		Name = "TXT";
		Description = "TXT File Txt";
		AddExtensions("txt");
		AddSignatures(
            new byte[] { 0xFF, 0xFE },
            new byte[] { 0xFF, 0xFF },
			new byte[] { 0xEF, 0xBB, 0xBF },
            new byte[] { 0xFF, 0xFE, 0x00, 0x00 },
            new byte[] { 0x00, 0x00, 0xFE, 0xFF }
            );
	}
}
