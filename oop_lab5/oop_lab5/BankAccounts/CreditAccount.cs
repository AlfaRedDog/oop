using System;
using System.Collections.Generic;
using System.Text;
using oop_lab5.Exceptions;
namespace oop_lab5.BankAccounts
{
    class CreditAccount : IAccount
    {
        protected double _Money { get; set; }
        protected DateTime DateCreate => DateTime.Now;
        protected double CreditLimit { get; }
        protected double CreditComission { get; }
        public Guid ID { get; }
        public double MoneyValue()
        {
            return _Money;
        }

        public CreditAccount(Guid Id, double moneylimit, double comission)
        {
            _Money = 0;
            ID = Id;
            CreditLimit = -1*moneylimit;
            CreditComission = comission;
        }
        void IAccount.AddMoney(double money)
        {
            _Money += money;
        }
        void IAccount.SpendMoney(double money)
        {
            if (_Money - (money + money * CreditComission / 100) < CreditLimit)
                throw new CreditLimitException();
            if (_Money < 0)
                _Money -= money * CreditComission / 100;
            _Money -= money;
        }
        void IAccount.TransferMoney(double money, IAccount recepient)
        {
            if (_Money - (money + money * CreditComission / 100) < CreditLimit)
                throw new CreditLimitException();
            recepient.AddMoney(money);
            if(_Money < 0)
                _Money -= money * CreditComission / 100;
            _Money -= money;
        }

        Guid IAccount.GetID()
        {
            return ID;
        }

        double IAccount.CalculateProcent(DateTime date)
        {
            throw new NotImplementedException();
        }
    }
}
