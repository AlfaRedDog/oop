using System;
using System.Collections.Generic;
using System.Text;
using oop_lab4.RestorePoint;
using oop_lab4.exception;
namespace oop_lab4.BackUp
{
    [Flags]
    public enum CleanerType 
    { 
        CountCleaner = 1,
        SizeCleaner = 2,
        TimeCleaner = 4,
        AllTypeCleaner = 7
    }
    public enum GibridType
    {
        OrGibrid = 0,
        AndGibrid = 1
    }
    public class BackUp
    {
        private int ID { get; }
        private DateTime CreationTIme;
        private double BackUpSize { get; set; }
        protected internal List<string> FilesToSave { get; set; }
        protected internal Queue<RestrorePointInterface> Points { get; set; }
        protected internal RestrorePointInterface LastPoint { get; set; }
        private bool isFolder { get; }
        private CleanerType TypeOfCleaner { get; set; }
        private GibridType TypeOfGibrid { get; set; }
        private  CleanerConfiguration ConfigurationOfCleaner { get; set; }
        protected internal bool CreateSuccesful { get; set; }

        public BackUp(int Id, bool TypeOfStorage, CleanerConfiguration Conf)
        {
            FilesToSave = new List<string>();
            Points = new Queue<RestrorePointInterface>();
            CreationTIme = DateTime.Now;
            ID = Id;
            isFolder = TypeOfStorage;
            TypeOfCleaner = Conf.CleanerT;
            TypeOfGibrid = Conf.Gibrid;
            ConfigurationOfCleaner = Conf;
            CreateSuccesful = false;
        }
        public BackUp()
        {
            CreationTIme = DateTime.Now;
            Random rnd = new Random();
            ID = rnd.Next();
            FilesToSave = new List<string>();
            Points = new Queue<RestrorePointInterface>();
            isFolder = true;
            TypeOfCleaner = new CleanerConfiguration().CleanerT;
            TypeOfGibrid = new CleanerConfiguration().Gibrid;
            CreateSuccesful = false;
        }
        public void AddFile(string path)
        {
            FilesToSave.Add(path);
        }
        public void RemoveFile(string path)
        {
            FilesToSave.Remove(path);
        }

        public double WriteBackUpSize()
        {
            return (BackUpSize);
        }
        public int Count(BackUp a)
        {
            return a.Points.Count;
        }
        public void CreateCompletePoint()
        {
            CompleteRestorePoint temp = new CompleteRestorePoint(this);
            LastPoint = temp;
            Points.Enqueue(temp);
            BackUpSize += Points.Peek().size;
            //Cleaner();
        }
        public void CreateIncPoint()
        {
            IncRestorePoint temp = new IncRestorePoint(this);
            //Console.WriteLine(CreateSuccesful);
            if (CreateSuccesful == true)
            {
                LastPoint = temp;
                Points.Enqueue(temp);
                BackUpSize += temp.size;
            }
            //Cleaner();
        }
        public void CleanerConfigurator(CleanerConfiguration conf)
        {
            ConfigurationOfCleaner = conf;
            TypeOfCleaner = conf.CleanerT;
            TypeOfGibrid = conf.Gibrid;
            Cleaner();
        }

        private bool CountCleanerChecker()
        {
            if (Points.Count > ConfigurationOfCleaner.count)
                return true;
            return false;
        }
        private bool SizeCleanerChecker()
        {
            if ((BackUpSize > ConfigurationOfCleaner.size))
                return true;
            return false;
        }
        private bool TimeCleanerChecker()
        {
            if ((Points.Peek().CreationTime.CompareTo(ConfigurationOfCleaner.Deadlne) < 0))
                return true;
            return false;
        }

        private void PointDeleter()
        {
            BackUpSize -= Points.Peek().size;
            Points.Dequeue();
            Cleaner();
        }
        private delegate void CleanerMetod();
        Dictionary<CleanerType, CleanerMetod> handler = new Dictionary<CleanerType, CleanerMetod>();

        private void CreateHandler()
        {
            handler.Add(CleanerType.CountCleaner, CountCleaner);
            handler.Add(CleanerType.SizeCleaner, SizeCleaner);
            handler.Add(CleanerType.TimeCleaner, TimeCleaner);
            handler.Add(CleanerType.CountCleaner | CleanerType.SizeCleaner, CountSizeCleaner);
            handler.Add(CleanerType.CountCleaner | CleanerType.TimeCleaner, CountTimeCleaner);
            handler.Add(CleanerType.SizeCleaner | CleanerType.TimeCleaner, SizeTimeCleaner);
            handler.Add(CleanerType.AllTypeCleaner, AllCleaner);
        }

        private void CountCleaner()
        {
            if (CountCleanerChecker())
                PointDeleter();
        }
        private void SizeCleaner()
        {
            if (SizeCleanerChecker())
                PointDeleter();
        }
        private void TimeCleaner()
        {
            if (TimeCleanerChecker())
                PointDeleter();
        }

        private void CountSizeCleaner()
        {
            if (TypeOfGibrid == GibridType.OrGibrid)
            {
                if (CountCleanerChecker() || SizeCleanerChecker())
                    PointDeleter();
            }
            else
            {
                if (CountCleanerChecker() && SizeCleanerChecker())
                    PointDeleter();
            }
        }
        private void CountTimeCleaner()
        {
            if (TypeOfGibrid == GibridType.OrGibrid)
            {
                if (CountCleanerChecker() || TimeCleanerChecker())
                    PointDeleter();
            }
            else
            {
                if (TypeOfGibrid == GibridType.AndGibrid)
                    if (CountCleanerChecker() && TimeCleanerChecker())
                        PointDeleter();
            }
        }
        private void SizeTimeCleaner()
        {
            if (TypeOfGibrid == GibridType.OrGibrid)
            {
                if (SizeCleanerChecker() || TimeCleanerChecker())
                    PointDeleter();
            }
            else
            {
                if (SizeCleanerChecker() && TimeCleanerChecker())
                        PointDeleter();
            }
        }
        private void AllCleaner()
        {
            
            if (TypeOfGibrid == GibridType.OrGibrid)
            {
                if (CountCleanerChecker() || SizeCleanerChecker() || TimeCleanerChecker())
                    PointDeleter();
            }
            else
            {
                if (CountCleanerChecker() && SizeCleanerChecker() && TimeCleanerChecker())
                {
                    PointDeleter();
                }
            }
        }
        private void Cleaner()
        {
            handler.Clear();
            CreateHandler();
            //Console.WriteLine(Points.Count);
            if (Points.Count != 0)
            {
                CleanerMetod met = handler[TypeOfCleaner];
                met();
                while ((Points.Count != 0) && (Points.Peek().TypePoint == PointType.Inc))
                { 
                        PointDeleter();
                    if (Points.Count == 0)
                        break;
                }
                //Cleaner();
            }
        }
    }
}
