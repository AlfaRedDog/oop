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
        CountCleaner = 10,
        SizeCleaner = 11,
        TimeCleaner = 12,
        CountAndSizeCleaner = 201,
        CountAndTimeCleaner = 202,
        SizeAndTimeCleaner = 212,
        AllTypeCleaner = 3012
    }
    [Flags]
    public enum GibridType
    {
        nonGibrid = 2,
        OrGibrid = 0,
        AndGibrid = 1
    }
    public class BackUp
    {
        int ID { get; }
        public DateTime CreationTIme;
        public double BackUpSize { get; set; }
        public List<string> FilesToSave { get; set; }
        public Queue<RestrorePointInterface> Points { get; set; }
        public RestrorePointInterface LastPoint { get; set; }
        public bool isFolder { get; }
        public CleanerType TypeOfCleaner { get; set; }
        public GibridType TypeOfGibrid { get; set; }
        public DateTime DeadLineTime { get; set; }
        public bool CreateSuccesful { get; set; }
        public int CountPointLimit { get; set; }
        public int SizeBackUpLimit { get; set; }

        public BackUp(int Id, bool TypeOfStorage)
        {
            FilesToSave = new List<string>();
            Points = new Queue<RestrorePointInterface>();
            CreationTIme = DateTime.Now;
            ID = Id;
            isFolder = TypeOfStorage;
            TypeOfCleaner = new CleanerType();
            TypeOfGibrid = new GibridType();
            DeadLineTime = DateTime.Now;
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
            TypeOfCleaner = new CleanerType();
            TypeOfGibrid = new GibridType();
            DeadLineTime = DateTime.Now.AddMinutes(1);
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
            Cleaner();
        }
        public void CreateIncPoint()
        {
            IncRestorePoint temp = new IncRestorePoint(this);
            if (CreateSuccesful == true)
            {
                //Console.WriteLine(temp.size);
                LastPoint = temp;
                Points.Enqueue(temp);
                //Console.WriteLine(Points.Peek().size);
                BackUpSize += temp.size;
            }
            Cleaner();
        }
        private void Cleaner()
        {
            if (Points.Count != 0)
            {
                switch (TypeOfCleaner)
                {
                    case CleanerType.CountCleaner:
                        if (Points.Count > CountPointLimit)
                        {
                            BackUpSize -= Points.Peek().size;
                            Points.Dequeue();
                        }
                        break;

                    case CleanerType.SizeCleaner:
                        if ((BackUpSize > SizeBackUpLimit))
                        {
                            BackUpSize -= Points.Peek().size;
                            Points.Dequeue();
                            Cleaner();
                        }
                        break;

                    case CleanerType.TimeCleaner:
                        if ((Points.Peek().CreationTime.CompareTo(DeadLineTime) < 0))
                        {
                            BackUpSize -= Points.Peek().size;
                            Points.Dequeue();
                            Console.WriteLine("time complete");
                            Cleaner();
                        }
                        break;

                    case CleanerType.CountAndSizeCleaner:
                        if (TypeOfGibrid == GibridType.OrGibrid)
                        {
                            if ((Points.Count > CountPointLimit) || (BackUpSize > SizeBackUpLimit))
                            {
                                BackUpSize -= Points.Peek().size;
                                Points.Dequeue();
                                Cleaner();
                            }
                        }
                        else
                        {
                            if(TypeOfGibrid == GibridType.AndGibrid)
                                if ((Points.Count > CountPointLimit) && (BackUpSize > SizeBackUpLimit))
                                {
                                    BackUpSize -= Points.Peek().size;
                                    Points.Dequeue();
                                    Cleaner();
                                }
                        }
                        break;

                    case CleanerType.CountAndTimeCleaner:
                        if (TypeOfGibrid == GibridType.OrGibrid)
                        {
                            if ((Points.Count > CountPointLimit) || (Points.Peek().CreationTime.CompareTo(DeadLineTime) < 0))
                            {
                                BackUpSize -= Points.Peek().size;
                                Points.Dequeue();
                                Cleaner();
                            }
                        }
                        else
                        {
                            if (TypeOfGibrid == GibridType.AndGibrid)
                                if ((Points.Count > CountPointLimit) && (Points.Peek().CreationTime.CompareTo(DeadLineTime) < 0))
                                {
                                    BackUpSize -= Points.Peek().size;
                                    Points.Dequeue();
                                    Cleaner();
                                }
                        }
                        break;

                    case CleanerType.SizeAndTimeCleaner:
                        if (TypeOfGibrid == GibridType.OrGibrid)
                        {
                            if ((BackUpSize > SizeBackUpLimit) || (Points.Peek().CreationTime.CompareTo(DeadLineTime) < 0))
                            {
                                BackUpSize -= Points.Peek().size;
                                Points.Dequeue();
                                Cleaner();
                            }
                        }
                        else
                        {
                            if (TypeOfGibrid == GibridType.AndGibrid)
                                if ((BackUpSize > SizeBackUpLimit) && (Points.Peek().CreationTime.CompareTo(DeadLineTime) < 0))
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
                            if ((BackUpSize > SizeBackUpLimit) || (Points.Peek().CreationTime.CompareTo(DeadLineTime) < 0) || (Points.Count > CountPointLimit))
                            {
                                BackUpSize -= Points.Peek().size;
                                Points.Dequeue();
                                Cleaner();
                            }
                        }
                        else
                        {
                            if (TypeOfGibrid == GibridType.AndGibrid)
                                if ((BackUpSize > SizeBackUpLimit) && (Points.Peek().CreationTime.CompareTo(DeadLineTime) < 0) && (Points.Count > CountPointLimit))
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
        public void CountCleaner(int Value)
        {
            CountPointLimit = Value;
            TypeOfGibrid = GibridType.nonGibrid;
            TypeOfCleaner = CleanerType.CountCleaner;
            Cleaner();
        }
        public void SizeCleaner(int Value)
        {
            SizeBackUpLimit = Value;
            TypeOfGibrid = GibridType.nonGibrid;
            TypeOfCleaner = CleanerType.CountCleaner;
            Cleaner();
        }
        public void TimeCleaner(DateTime Value)
        {
            DeadLineTime = Value;
            TypeOfGibrid = GibridType.nonGibrid;
            TypeOfCleaner = CleanerType.CountCleaner;
            Cleaner();
        }
        public void CountAndSizeCleaner(int Value, int size, GibridType gib )
        {
            CountPointLimit = Value;
            SizeBackUpLimit = size;
            TypeOfGibrid = gib;
            TypeOfCleaner = CleanerType.CountAndSizeCleaner;
            Cleaner();
        }
        public void CountAndTimeCleaner(int Value, DateTime time, GibridType gib)
        {
            CountPointLimit = Value;
            DeadLineTime = time;
            TypeOfGibrid = gib;
            TypeOfCleaner = CleanerType.CountAndTimeCleaner;
            Cleaner();
        }
        public void SizeAndTimeCleaner(int size, DateTime time, GibridType gib)
        {
            SizeBackUpLimit = size;
            DeadLineTime = time;
            TypeOfGibrid = gib;
            TypeOfCleaner = CleanerType.SizeAndTimeCleaner;
            Cleaner();
        }
        public void AllCleaner(int size, DateTime time, int value, GibridType gib)
        {
            SizeBackUpLimit = size;
            DeadLineTime = time;
            CountPointLimit = value;
            TypeOfGibrid = gib;
            TypeOfCleaner = CleanerType.AllTypeCleaner;
            Cleaner();
        }

    }
}
