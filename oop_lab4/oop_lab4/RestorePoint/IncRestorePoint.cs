using System;
using System.Collections.Generic;
using System.Text;
using oop_lab4.exception;
namespace oop_lab4.RestorePoint
{
    class IncRestorePoint : RestrorePointInterface
    {
        public long size { get; }
        public List<file> SavedFiles { get; }
        public DateTime CreationTime => DateTime.Now;
        PointType RestrorePointInterface.TypePoint { get => PointType.Inc; }

        public IncRestorePoint (BackUp.BackUp backup)
        {
            SavedFiles = new List<file>();
            size = 0;
            foreach (var element in backup.LastPoint.SavedFiles)
            {
                //Console.WriteLine(backup.LastPoint.SavedFiles.Find(x => x.path.Contains(element)).FileSize);
                Console.WriteLine(element.path);
                //Console.WriteLine(backup.LastPoint.SavedFiles.IndexOf(element));
                //Console.WriteLine(new file(element).FileSize);
                if (element.FileSize < new file(element.path).FileSize)
                {
                    backup.CreateSuccesful = true;
                    var temp = new file(element.path);
                    temp.FileSize -= backup.LastPoint.SavedFiles.Find(x => x == element).FileSize;
                    SavedFiles.Add(temp);
                    size += temp.FileSize;
                }
            }
        }
    }
}
