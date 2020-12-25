using System;
using System.Collections.Generic;
using System.Text;
using oop_lab5.Exceptions;
using System.Threading.Tasks;
namespace oop_lab5.BankAccounts
{
    class DepositAccount : IAccount
    {
        protected double _Money { get; set; }
        protected DateTime DateCreate => DateTime.Now;
        protected DateTime DepositTime { get; }
        public Guid ID { get; }
        protected double ProcentOnMod { get; set; }
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
        public DepositAccount(Guid Id, DateTime date, double money, double proc)
        {
            _Money = money;
            ID = Id;
            DepositTime = date;
            ProcentOnMod = proc;
            CalculateProcent();
        }
        void IAccount.AddMoney(double money)
        {
            _Money += money;
        }
        void IAccount.SpendMoney(double money)
        {
            if (money > _Money)
                throw new NotEnoughMoneyException();
            if (DateTime.Now < DepositTime)
                throw new NotTimeSonException();
            _Money -= money;
        }
        void IAccount.TransferMoney(double money, IAccount recepient)
        {
            if (money < _Money)
                throw new NotEnoughMoneyException();
            if (DateTime.Now < DepositTime)
                throw new NotTimeSonException();
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
        public async void CalculateProcent()
        {
            await Task.Run(() =>
            {
                while (StopMod)
                {
                    ACalculateProcentPerDay();
                    AddprocentMonth();
                }
            });
        }
    }
}
