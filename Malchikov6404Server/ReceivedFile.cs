using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Malchikov6404Server
{
    public class ReceivedFile
    {
        public string FileName { get; set; }

        public string FileSize { get; set; }

        public byte[] FileContent { get; set; } //раньше был string
    }
}
