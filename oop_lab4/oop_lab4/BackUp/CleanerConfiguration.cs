using System;
using System.Collections.Generic;
using System.Text;

namespace oop_lab4.BackUp
{
    public class CleanerConfiguration
    {
        public int count;
        public int size;
        public DateTime Deadlne;
        public GibridType Gibrid;
        public CleanerType CleanerT;
        public CleanerConfiguration(int Count, int Size, DateTime time, GibridType g, CleanerType c)
        {
            count = Count;
            size = Size;
            Deadlne = time;
            Gibrid = g;
            CleanerT = c;
        }
        public CleanerConfiguration()
        {
            count = 2;
            size = 30;
            Deadlne = DateTime.Now.AddSeconds(15);
            Gibrid = GibridType.OrGibrid;
            CleanerT = CleanerType.AllTypeCleaner;
        }
    }
}
