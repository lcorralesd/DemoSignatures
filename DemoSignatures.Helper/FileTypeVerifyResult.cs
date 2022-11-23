using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSignatures.Helper;
public class FileTypeVerifyResult
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string MediaType { get; set; }
    public string Extension { get; set; }
    public bool IsVerified { get; set; }
    public bool IsExtensionMatch { get; set; }
}
