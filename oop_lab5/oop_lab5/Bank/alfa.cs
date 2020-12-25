using System;
using System.Collections.Generic;
using System.Text;
using oop_lab5.Client;
using oop_lab5.Exceptions;
using oop_lab5.BankAccounts;
using oop_lab5.Transaction;
namespace oop_lab5.Bank
{
    class alfa : IBank
    {
        public Guid ID { get; }
        public string adress { get; }
        public string Name { get; }
        protected double ProcentOnModForDebet = 4;
        protected DateTime LimitForDeposit = DateTime.Now.AddDays(40);
        protected double ProcentForDeposit { get; set; }
        protected double CommisionForCredit = 2;
        protected double LimitForCredit = 10000;
        protected double MutnyTipLimit = 1000;
        protected List<ClientC> ClientList { get; set; }
        protected List<CTransaction> TransactionList { get; set; }
        public alfa()
        {
            ID = Guid.NewGuid();
            adress = "kakoi-to adress";
            Name = "alfa";
            ClientList = new List<ClientC>();
            TransactionList = new List<CTransaction>();
        }
        public void AddClient(ClientC person)
        {
            var CheckPerson = ClientList.Find(pers => pers == person);
            if (CheckPerson != null)
                throw new CheckPersonException();
            ClientList.Add(person);
        }
        public Guid AddCreditAccount(ClientC person)
        {
            Guid Id = Guid.NewGuid();
            ClientList[ClientList.FindIndex(pers => pers == person)].AllAccounts.Add(new CreditAccount(Id, LimitForCredit, CommisionForCredit));
            return Id;
        }
        public Guid AddDebetAccount(ClientC person)
        {
            Guid Id = Guid.NewGuid();
            ClientList[ClientList.FindIndex(pers => pers == person)].AllAccounts.Add(new DebetAccount(Id, 0, ProcentOnModForDebet));
            return Id;
        }
        public Guid AddDepositAccount(ClientC person, double money)
        {
            Guid Id = Guid.NewGuid();
            ClientList[ClientList.FindIndex(pers => pers == person)].AllAccounts.Add(new DepositAccount(Id, LimitForDeposit, money, ProcentForDepositM(money)));
            return Id;
        }
        protected double ProcentForDepositM(double money)
        {
            if (money < 50000) return 2;
            if (money < 100000) return 2.5;
            return 3;
        }
        public void AddMoney(Guid Id, ClientC person, double money)
        {
            ClientList[ClientList.FindIndex(pers => pers == person)].AllAccounts.Find(acc => acc.GetID() == Id).AddMoney(money);
        }
        public void SpendMoney(Guid Id, ClientC person, double money)
        {
            if (((ClientList.Find(pers => pers == person).TakeAdress() == "") || (ClientList.Find(pers => pers == person).TakePassport() == -1)) && (money > MutnyTipLimit))
                throw new MutnyTipException();
            ClientList[ClientList.FindIndex(pers => pers == person)].AllAccounts.Find(acc => acc.GetID() == Id).SpendMoney(money);
        }
        public void TransferMoney(Guid Id1, Guid Id2, ClientC person1, ClientC person2, double money)
        {
            if (((ClientList.Find(pers => pers == person1).TakeAdress() == "") || (ClientList.Find(pers => pers == person1).TakePassport() == -1)) && (money > MutnyTipLimit))
                throw new MutnyTipException();
            ClientList[ClientList.FindIndex(pers => pers == person1)].AllAccounts.Find(acc => acc.GetID() == Id1).TransferMoney(money, person2.AllAccounts.Find(acc => acc.GetID() == Id2));
            TransactionList.Add(new CTransaction(money, person1, person2, Id1, Id2));
        }
        public void CancelTransaction(CTransaction trans)
        {
            if (TransactionList.FindIndex(tran => tran == trans) != -1)
                throw new NotFoundTransactionException();
            TransferMoney(trans.TakeSendertId(), trans.TakeRecepientId(), trans.TakeSender(), trans.TakeRecepient(), trans.TakeMoney());
        }
    }
}
