﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSignatures.Helper.Types;
public  class Jpeg : FileType
{
    public Jpeg()
    {
        Name = "JPEG";
        Description = "JPEG IMAGE";
        MediaType = "image/jpeg";
        AddExtensions("jpeg", "jpg");
        AddSignatures(
            new byte[] { 0xFF, 0xD8, 0xFF, 0xE0 },
            new byte[] { 0xFF, 0xD8, 0xFF, 0xE1 },
            new byte[] { 0xFF, 0xD8, 0xFF, 0xE2 },
            new byte[] { 0xFF, 0xD8, 0xFF, 0xE3 }
        );
    }
}

