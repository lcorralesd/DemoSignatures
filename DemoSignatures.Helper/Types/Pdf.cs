using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSignatures.Helper.Types;
public class Pdf : FileType
{
	public Pdf()
	{
		Name = "PDF";
		Description = "PDF File";
		AddExtensions(".pdf");
		AddSignatures(new byte[] { 0x25, 0x50, 0x44, 0x46 });
	}
}
