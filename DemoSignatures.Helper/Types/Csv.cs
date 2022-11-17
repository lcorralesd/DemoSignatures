using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSignatures.Helper.Types;
public class Csv : FileType
{
	public Csv()
	{
		Name = "CSV";
		Description = "CSV file type";
		AddExtensions("csv");
		AddSignatures(new byte[] { 0xEF, 0xBB, 0xBF });
	}
}
