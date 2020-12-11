using NUnit.Framework;
using oop_lab4.BackUp;
using System;
using oop_lab4.RestorePoint;
using System.Threading;
using oop_lab4.exception;
using System.IO;
namespace oop_lab4.Tests
{
    [TestFixture]
    public class Tests
    {
        public string path1 = "/Users/mikhail/source/repos/oop_lab4/files/test1.txt";
        public string path2 = "/Users/mikhail/source/repos/oop_lab4/files/test2.txt";
        public string Largepath1 = "/Users/mikhail/source/repos/oop_lab4/files/largefile1.txt";
        public string Largepath2 = "/Users/mikhail/source/repos/oop_lab4/files/largefile2.txt";
        public string Changepath1 = "/Users/mikhail/source/repos/oop_lab4/files/test13.txt";
        public string Changepath2 = "/Users/mikhail/source/repos/oop_lab4/files/test23.txt";
        [Test]
        public void UsualCase()
        {
            //int Id, bool TypeOfStorage, CleanerType TypeClean, GibridType TypeGibrid, DateTime time
            BackUp.BackUp a = new BackUp.BackUp(15, true);
            a.AddFile(path1);
            a.AddFile(path2);
            //a.RemoveFile("/Users/mikhail/source/repos/oop_lab4/files/test2.txt");
            a.CreateCompletePoint();
            Console.WriteLine(a.Points.Peek().SavedFiles.Count);
            //Thread.Sleep(70000);
            a.CreateCompletePoint();
            a.CountCleaner(1);
            Console.WriteLine(a.Points.Count);
        }
        [Test]
        public void LargeCase()
        {
            BackUp.BackUp a = new BackUp.BackUp(15, true);
            a.AddFile(Largepath1);
            a.AddFile(Largepath2);
            a.CreateCompletePoint();
            a.CreateCompletePoint();
            Console.WriteLine(a.Points.Count);
            Console.WriteLine(a.BackUpSize);
            a.SizeCleaner(200000000);
            Console.WriteLine(a.Points.Count);
            Console.WriteLine(a.BackUpSize);
        }
        [Test]
        public void IncCase()
        {
            BackUp.BackUp a = new BackUp.BackUp(15, true);
            a.AddFile(Changepath1);
            a.AddFile(Changepath2);
            a.CreateCompletePoint();
            using (StreamWriter sw = new StreamWriter(Changepath1, true, System.Text.Encoding.Default))
            {
                sw.WriteLine("snidd");
            }
            a.CreateIncPoint();
            using (StreamWriter sw = new StreamWriter(Changepath1, true, System.Text.Encoding.Default))
            {
                sw.WriteLine("snidd");
            }
            a.CreateCompletePoint();
            a.CreateIncPoint();
            Console.WriteLine(a.Points.Count);
            Console.WriteLine(a.BackUpSize);
        }
        [Test]
        public void GibridCase1()
        {
            BackUp.BackUp a = new BackUp.BackUp(15, true);
            a.AddFile(path1);
            a.AddFile(path2);
            a.CreateCompletePoint();
            a.CreateCompletePoint();
            a.CreateCompletePoint();
            a.CountAndSizeCleaner(3, 21, GibridType.OrGibrid);
            Console.WriteLine(a.Points.Count);
            Console.WriteLine(a.BackUpSize);
        }
        [Test]
        public void GibridCase2()
        {
            BackUp.BackUp a = new BackUp.BackUp(15, false);
            a.AddFile(path1);
            a.AddFile(path2);
            a.CreateCompletePoint();
            a.CreateCompletePoint();
            a.CreateCompletePoint();
            a.CountAndTimeCleaner(3, DateTime.Now.AddSeconds(3), GibridType.AndGibrid);
            Thread
            a.CreateCompletePoint();
            Console.WriteLine(a.Points.Count);
            Console.WriteLine(a.BackUpSize);
        }
    }
}