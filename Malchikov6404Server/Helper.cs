using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Malchikov6404Server
{
    public static class Helper
    {
        public static void WholeAdding(this List<byte> Bytes, Stream Str)
        {
            int Data = -1;
            while ((Data = Str.ReadByte()) != -1)
            {
                if (Data == -1)
                    break;
                Bytes.Add((byte)Data);
            }
        }
    }
}
