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
        int ID { get; }
        public DateTime CreationTIme;
        public double BackUpSize { get; set; }
        public List<string> FilesToSave { get; set; }
        protected internal Queue<RestrorePointInterface> Points { get; set; }
        protected internal RestrorePointInterface LastPoint { get; set; }
        public bool isFolder { get; }
        public CleanerType TypeOfCleaner { get; set; }
        public GibridType TypeOfGibrid { get; set; }
        public CleanerConfiguration ConfigurationOfCleaner { get; set; }
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
            if (CreateSuccesful == true)
            {
                LastPoint = temp;
                Points.Enqueue(temp);
                BackUpSize += temp.size;
            }
            //Cleaner();
        }
        private void Cleaner()
        {
            if (Points.Count != 0)
            {
                switch (TypeOfCleaner)
                {
                    case CleanerType.CountCleaner:
                        if (Points.Count > ConfigurationOfCleaner.count)
                        {
                            BackUpSize -= Points.Peek().size;
                            Points.Dequeue();
                        }
                        break;

                    case CleanerType.SizeCleaner:
                        if ((BackUpSize > ConfigurationOfCleaner.size))
                        {
                            BackUpSize -= Points.Peek().size;
                            Points.Dequeue();
                            Cleaner();
                        }
                        break;

                    case CleanerType.TimeCleaner:
                        if ((Points.Peek().CreationTime.CompareTo(ConfigurationOfCleaner.Deadlne) < 0))
                        {
                            BackUpSize -= Points.Peek().size;
                            Points.Dequeue();
                            Console.WriteLine("time complete");
                            Cleaner();
                        }
                        break;

                    case CleanerType.CountCleaner | CleanerType.SizeCleaner:
                        if (TypeOfGibrid == GibridType.OrGibrid)
                        {
                            if ((Points.Count > ConfigurationOfCleaner.count) || (BackUpSize > ConfigurationOfCleaner.size))
                            {
                                BackUpSize -= Points.Peek().size;
                                Points.Dequeue();
                                Cleaner();
                            }
                        }
                        else
                        {
                            if(TypeOfGibrid == GibridType.AndGibrid)
                                if ((Points.Count > ConfigurationOfCleaner.count) && (BackUpSize > ConfigurationOfCleaner.size))
                                {
                                    BackUpSize -= Points.Peek().size;
                                    Points.Dequeue();
                                    Cleaner();
                                }
                        }
                        break;

                    case CleanerType.CountCleaner | CleanerType.TimeCleaner:
                        if (TypeOfGibrid == GibridType.OrGibrid)
                        {
                            if ((Points.Count > ConfigurationOfCleaner.count) || (Points.Peek().CreationTime.CompareTo(ConfigurationOfCleaner.Deadlne) < 0))
                            {
                                BackUpSize -= Points.Peek().size;
                                Points.Dequeue();
                                Cleaner();
                            }
                        }
                        else
                        {
                            if (TypeOfGibrid == GibridType.AndGibrid)
                                if ((Points.Count > ConfigurationOfCleaner.count) && (Points.Peek().CreationTime.CompareTo(ConfigurationOfCleaner.Deadlne) < 0))
                                {
                                    BackUpSize -= Points.Peek().size;
                                    Points.Dequeue();
                                    Cleaner();
                                }
                        }
                        break;

                    case CleanerType.SizeCleaner | CleanerType.TimeCleaner:
                        if (TypeOfGibrid == GibridType.OrGibrid)
                        {
                            if ((BackUpSize > ConfigurationOfCleaner.size) || (Points.Peek().CreationTime.CompareTo(ConfigurationOfCleaner.Deadlne) < 0))
                            {
                                BackUpSize -= Points.Peek().size;
                                Points.Dequeue();
                                Cleaner();
                            }
                        }
                        else
                        {
                            if (TypeOfGibrid == GibridType.AndGibrid)
                                if ((BackUpSize > ConfigurationOfCleaner.size) && (Points.Peek().CreationTime.CompareTo(ConfigurationOfCleaner.Deadlne) < 0))
                                {
                                    BackUpSize -= Points.Peek().size;
                                    Points.Dequeue();
                                   Cleaner();
                                }
                        }
                        break;

                    case CleanerType.AllTypeCleaner:
                        if (TypeOfGibrid == GibridType.OrGibrid)
                        {
                            if ((BackUpSize > ConfigurationOfCleaner.size) || (Points.Peek().CreationTime.CompareTo(ConfigurationOfCleaner.Deadlne) < 0) || (Points.Count > ConfigurationOfCleaner.count))
                            {
                                BackUpSize -= Points.Peek().size;
                                Points.Dequeue();
                                Cleaner();
                            }
                        }
                        else
                        {
                            if (TypeOfGibrid == GibridType.AndGibrid)
                                if ((BackUpSize > ConfigurationOfCleaner.size) && (Points.Peek().CreationTime.CompareTo(ConfigurationOfCleaner.Deadlne) < 0) && (Points.Count > ConfigurationOfCleaner.count))
                                {
                                    BackUpSize -= Points.Peek().size;
                                    Points.Dequeue();
                                    Cleaner();
                                }
                        }
                        break;
                }
            }
        }
        public void CleanerConfigurator(CleanerConfiguration conf)
        {
            ConfigurationOfCleaner = conf;
            TypeOfCleaner = conf.CleanerT;
            TypeOfGibrid = conf.Gibrid;
            Cleaner();
        }
        public int Count(BackUp a)
        {
            return a.Points.Count;
        }
    }
}
