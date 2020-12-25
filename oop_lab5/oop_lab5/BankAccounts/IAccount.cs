using System;
using System.Collections.Generic;
using System.Text;
using oop_lab5.Client;
namespace oop_lab5.BankAccounts
{
    interface IAccount
    {
        //public Guid ID { get; }
        public Guid GetID();
        public double MoneyValue();
        public void AddMoney(double money);
        public void SpendMoney(double money);
        public void TransferMoney(double money, IAccount recepient);
    }
}
