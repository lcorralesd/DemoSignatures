using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSignatures.Helper.Interfaces;

public interface IFileFormatReader
{
    IDisposable? Read(Stream stream);
    bool IsMatch(IDisposable? file);
}
