using System;
using System.Collections.Generic;
using System.Text;
using oop_lab5.Client;
namespace oop_lab5.Bank
{
    interface IBank
    {
        public string adress { get; }
        public string Name { get; }
        public Guid ID { get; }
    }
}
