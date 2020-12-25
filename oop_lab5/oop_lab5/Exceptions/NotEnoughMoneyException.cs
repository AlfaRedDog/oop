using System;
using System.Collections.Generic;
using System.Text;

namespace oop_lab5.Exceptions
{
    class NotEnoughMoneyException : Exception
    {
        public NotEnoughMoneyException() : base("not enough money")
        {

        }
    }
}
