using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSignatures.Helper.Types;
public class OpenXML : FileType
{
	public OpenXML()
	{
		Name = "OpenXML Document";
		Description = "\tMicrosoft Office Open XML Format (OOXML) Document";
		AddExtensions("docx, pptx, xlsx");
		AddSignatures(new byte[] { 0x50, 0x4B, 0x03, 0x04, 0x14, 0x00, 0x06, 0x00 });
    }
}
