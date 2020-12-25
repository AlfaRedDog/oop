using System;
using oop_lab5.Bank;
using oop_lab5.BankAccounts;
using oop_lab5.Client;
using oop_lab5.Exceptions;
using oop_lab5.Transaction;
using static System.Console;
using System.Threading;
namespace oop_lab5
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var bank1 = new Sber();
                var person1 = new ClientC("mikhail", "chesnokov");
                var person2 = new ClientC("mikhail2", "chesnokov");
                person1.AddAdress("fsdf");
                person1.AddPassport(1233);
                bank1.AddClient(person1);
                bank1.AddClient(person2);
                Guid Id1 = bank1.AddCreditAccount(person1);
                Guid Id2 = bank1.AddDebetAccount(person2);
                Guid Id3 = bank1.AddDepositAccount(person2, 200000);
                bank1.AddMoney(Id1, person1, 100);
                bank1.AddMoney(Id2, person2, 150);
                bank1.AddMoney(Id3, person2, 190);
                Console.WriteLine(bank1.ClientList[bank1.ClientList.FindIndex(pers => pers == person1)].AllAccounts.Find(acc => acc.GetID() == Id1).MoneyValue());
                Console.WriteLine(bank1.ClientList[bank1.ClientList.FindIndex(pers => pers == person2)].AllAccounts.Find(acc => acc.GetID() == Id2).MoneyValue());
                Console.WriteLine(bank1.ClientList[bank1.ClientList.FindIndex(pers => pers == person2)].AllAccounts.Find(acc => acc.GetID() == Id3).MoneyValue());
                bank1.SpendMoney(Id2, person2, 12);
                bank1.SpendMoney(Id1, person1, 15);
                //bank1.SpendMoney(Id3, person2, 16);
                Console.WriteLine(bank1.ClientList[bank1.ClientList.FindIndex(pers => pers == person1)].AllAccounts.Find(acc => acc.GetID() == Id1).MoneyValue());
                Console.WriteLine(bank1.ClientList[bank1.ClientList.FindIndex(pers => pers == person2)].AllAccounts.Find(acc => acc.GetID() == Id2).MoneyValue());
                Console.WriteLine(bank1.ClientList[bank1.ClientList.FindIndex(pers => pers == person2)].AllAccounts.Find(acc => acc.GetID() == Id3).MoneyValue());
                bank1.TransferMoney(Id1, Id2, person1, person2, 110);
                Console.WriteLine(bank1.ClientList[bank1.ClientList.FindIndex(pers => pers == person1)].AllAccounts.Find(acc => acc.GetID() == Id1).MoneyValue());
                Console.WriteLine(bank1.ClientList[bank1.ClientList.FindIndex(pers => pers == person2)].AllAccounts.Find(acc => acc.GetID() == Id2).MoneyValue());
                bank1.TransferMoney(Id2, Id1, person2, person1, 20);
                Console.WriteLine(bank1.ClientList[bank1.ClientList.FindIndex(pers => pers == person1)].AllAccounts.Find(acc => acc.GetID() == Id1).MoneyValue());
                Console.WriteLine(bank1.ClientList[bank1.ClientList.FindIndex(pers => pers == person2)].AllAccounts.Find(acc => acc.GetID() == Id2).MoneyValue());
                //-25 - 1 - comission
                bank1.CancelTransaction(new CTransaction(20, person2, person1, Id2, Id1));
                Console.WriteLine(bank1.ClientList[bank1.ClientList.FindIndex(pers => pers == person1)].AllAccounts.Find(acc => acc.GetID() == Id1).MoneyValue());
                Console.WriteLine(bank1.ClientList[bank1.ClientList.FindIndex(pers => pers == person2)].AllAccounts.Find(acc => acc.GetID() == Id2).MoneyValue());
                bank1.AddMoney(Id3, person2, 0);
                Console.WriteLine(bank1.ClientList[bank1.ClientList.FindIndex(pers => pers == person2)].AllAccounts.Find(acc => acc.GetID() == Id3).MoneyValue());
                Thread.Sleep(41000);
                Console.WriteLine(bank1.ClientList[bank1.ClientList.FindIndex(pers => pers == person2)].AllAccounts.Find(acc => acc.GetID() == Id3).MoneyValue());
                bank1.SpendMoney(Id3, person2, 14);
            }
            catch(Exception e)
            {
                Error.WriteLine(e.Message);
            }
        }
    }
}
