using System;
using System.Collections.Generic;
using System.Text;
namespace oop_lab4.RestorePoint
{
    public enum PointType
    {
        Inc = 0,
        Complete = 1
    }
    public interface RestrorePointInterface
    {
        public long size { get; }
        public List<file> SavedFiles { get; }
        public DateTime CreationTime { get; }
        public PointType TypePoint {get; }
    }
}
