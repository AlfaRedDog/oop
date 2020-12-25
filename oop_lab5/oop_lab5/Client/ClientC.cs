using System;
using System.Collections.Generic;
using System.Text;
using oop_lab5.BankAccounts;
namespace oop_lab5.Client
{
    class ClientC
    {
        public string _Name { get; }
        protected string _SurName { get; }
        protected string _adress { get; set; }
        protected int _Passport { get; set; }
        public List<IAccount> AllAccounts { get; set; }
        public ClientC(string name, string surname)
        {
            _Name = name;
            _SurName = surname;
            _adress = "";
            _Passport = -1;
            AllAccounts = new List<IAccount>();
        }
        public void AddAdress(string adres) => _adress = adres;
        public string TakeAdress()
        {
            return _adress;
        }
        public void AddPassport(int numbers) => _Passport = numbers;
        public int TakePassport()
        {
            return _Passport;
        }
    }
}
