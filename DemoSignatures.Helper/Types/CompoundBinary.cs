using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSignatures.Helper.Types;
public class CompoundBinary : FileType
{
	public CompoundBinary()
	{
		Name = "Workbook";
		Description = "An Object Linking and Embedding (OLE) Compound File (CF) (i.e., OLECF)\r\nfile format, known as Compound Binary File format";
		AddExtensions(".doc, .dot, .pps, .ppt, .xla, .xls, .wiz");
		AddSignatures(new byte[] { 0xD0, 0xCF, 0x11, 0xE0, 0xA1, 0xB1, 0x1A, 0xE1 });
	}
}
