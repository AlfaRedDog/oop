using System;
using System.Collections.Generic;
using System.Text;

namespace oop_lab2.Exceptions
{
    class BuyItemException : Exception
    {
        public BuyItemException() : base("impossible to buy so many products")
        {
        }
    }
}
