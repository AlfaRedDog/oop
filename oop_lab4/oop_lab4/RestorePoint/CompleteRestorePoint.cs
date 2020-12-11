using System;
using System.Collections.Generic;
using System.Text;
using oop_lab4.BackUp;
namespace oop_lab4.RestorePoint
{
    public class CompleteRestorePoint : RestrorePointInterface
    {
        public long size { get; }
        public List<file> SavedFiles { get; }
        public DateTime CreationTime => DateTime.Now;
        PointType RestrorePointInterface.TypePoint => PointType.Complete;

        public CompleteRestorePoint(BackUp.BackUp backup)
        {
            SavedFiles = new List<file>();
            size = 0;
            foreach(var element in backup.FilesToSave)
            {
                var temp = new file(element);
                SavedFiles.Add(temp);
                size += temp.FileSize;
            }
        }
    }
}
