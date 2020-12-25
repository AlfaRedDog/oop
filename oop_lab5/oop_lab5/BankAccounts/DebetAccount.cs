using System;
using System.Collections.Generic;
using System.Text;
using oop_lab5.Bank;
using oop_lab5.Exceptions;
using System.Threading.Tasks;
namespace oop_lab5.BankAccounts
{
    class DebetAccount : IAccount
    {
        protected double _Money { get; set; }
        protected DateTime DateCreate => DateTime.Now;
        public Guid ID { get; }
        protected double ProcentOnMod { get; }
        protected double ProcentPerMonth { get; set; }
        public bool StopMod = true;
        protected DateTime LastDayAddProcent = DateTime.Now;
        protected DateTime FirstDayOfMonth = DateTime.Now;
        public double MoneyValue()
        {
            return _Money;
        }
        Guid IAccount.GetID()
        {
            return ID;
        }
        public void StopAddPercent()
        {
            StopMod = false;
        }
        public DebetAccount(Guid Id, double money, double proc)
        {
            ID = Id;
            _Money = money;
            ProcentPerMonth = 0;
            ProcentOnMod = proc;
        }
        void IAccount.AddMoney(double money)
        {
            _Money += money;
        }
        void IAccount.SpendMoney(double money)
        {
            if (money > _Money)
                throw new NotEnoughMoneyException();
            _Money -= money;
        }
        void IAccount.TransferMoney(double money, IAccount recepient)
        {
            if (money > _Money)
                throw new NotEnoughMoneyException();
            recepient.AddMoney(money);
            _Money -= money;
        }
        public void ACalculateProcentPerDay()
        {
            //if ((DateTime.Now - LastDayAddProcent).Days == 0) return; // full version
            if ((DateTime.Now - LastDayAddProcent).Seconds == 0) return; // time machine version
            //Console.WriteLine(ProcentPerMonth);
            //Console.WriteLine(ProcentOnMod);
            //Console.WriteLine(100.0 / 365.0);
            ProcentPerMonth += _Money * (ProcentOnMod / 100.0 / 365.0);
            LastDayAddProcent = DateTime.Now;
        }
        public void AddprocentMonth()
        {
            //if ((DateTime.Now - FirstDayOfMonth).Days < 30) return; // full version
            if ((DateTime.Now - FirstDayOfMonth).Seconds < 30) return; // time machine version
            _Money += ProcentPerMonth;
            ProcentPerMonth = 0;
            FirstDayOfMonth = DateTime.Now;
            LastDayAddProcent = DateTime.Now;
        }
        public double CalculateProcent(DateTime date)
        {
            if (date >= DateCreate)
                _Money += _Money * ((date - DateTime.Now).Days % 30 * ProcentOnMod / 100.0 / 12.0);
            return _Money;
        }
    }
}
