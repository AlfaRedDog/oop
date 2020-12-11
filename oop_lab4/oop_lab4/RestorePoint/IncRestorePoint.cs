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
            if (backup.LastPoint.TypePoint == PointType.Inc)
                throw new CreateIncPointException();
            SavedFiles = new List<file>();
            size = 0;
            foreach (var element in backup.FilesToSave)
            {
                //Console.WriteLine(backup.LastPoint.SavedFiles.Find(x => x.path.Contains(element)).FileSize);
                //Console.WriteLine(new file(element).FileSize);
                if ((backup.LastPoint.SavedFiles.IndexOf(new file(element)) <= 0) && 
                    (backup.LastPoint.SavedFiles.Find(x => x.path.Contains(element)).FileSize < new file(element).FileSize))
                {
                    backup.CreateSuccesful = true;
                    var temp = new file(element);
                    temp.FileSize -= backup.LastPoint.SavedFiles.Find(x => x.path.Contains(element)).FileSize;
                    SavedFiles.Add(temp);
                    size += temp.FileSize;
                }
            }
        }
    }
}
