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
        [Test]
        public void Case1()
        {
            //int Id, bool TypeOfStorage, CleanerType TypeClean, GibridType TypeGibrid, DateTime time
            BackUp.BackUp a = new BackUp.BackUp(15, true);
            a.AddFile("/Users/mikhail/source/repos/oop_lab4/files/test1.txt");
            a.AddFile("/Users/mikhail/source/repos/oop_lab4/files/test2.txt");
            //a.RemoveFile("/Users/mikhail/source/repos/oop_lab4/files/test2.txt");
            a.CreateCompletePoint();
            Console.WriteLine(a.Points.Peek().SavedFiles.Count);
            //Thread.Sleep(70000);
            a.CreateCompletePoint();
            a.CountCleaner(1);
            Console.WriteLine(a.Points.Count);
        }
        [Test]
        public void Case2()
        {
            BackUp.BackUp a = new BackUp.BackUp(15, true);
            a.AddFile("/Users/mikhail/source/repos/oop_lab4/files/largefile1.txt");
            a.AddFile("/Users/mikhail/source/repos/oop_lab4/files/largefile2.txt");
            a.CreateCompletePoint();
            a.CreateCompletePoint();
            Console.WriteLine(a.Points.Count);
            Console.WriteLine(a.BackUpSize);
            a.SizeCleaner(200000000);
            Console.WriteLine(a.Points.Count);
            Console.WriteLine(a.BackUpSize);
        }
        [Test]
        public void Case3()
        {
            BackUp.BackUp a = new BackUp.BackUp(15, true);
            a.AddFile("/Users/mikhail/source/repos/oop_lab4/files/test13.txt");
            a.AddFile("/Users/mikhail/source/repos/oop_lab4/files/test23.txt");
            a.CreateCompletePoint();
            using (StreamWriter sw = new StreamWriter("/Users/mikhail/source/repos/oop_lab4/files/test13.txt", true, System.Text.Encoding.Default))
            {
                sw.WriteLine("snidd");
            }
            a.CreateIncPoint();
            Console.WriteLine(a.Points.Count);
            Console.WriteLine(a.BackUpSize);
        }
        [Test]
        public void Case4()
        {
            BackUp.BackUp a = new BackUp.BackUp(15, true);
            a.AddFile("/Users/mikhail/source/repos/oop_lab4/files/test1.txt");
            a.AddFile("/Users/mikhail/source/repos/oop_lab4/files/test2.txt");
            a.CreateCompletePoint();
            a.CreateCompletePoint();
            a.CreateCompletePoint();
            a.CountAndSizeCleaner(3, 21, GibridType.OrGibrid);
            Console.WriteLine(a.Points.Count);
            Console.WriteLine(a.BackUpSize);
        }
    }
}