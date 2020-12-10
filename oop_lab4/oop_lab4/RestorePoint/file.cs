using System;
using System.Collections.Generic;
using System.IO;


namespace oop_lab4.RestorePoint
{
    public class file
    {
        public string path;
        public long FileSize;
        public file (string Path)
        {
            path = Path;
            FileSize = new FileInfo(Path).Length;
        }
    }
}
