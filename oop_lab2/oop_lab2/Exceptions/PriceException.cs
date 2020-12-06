using System;
using System.Collections.Generic;
using System.Text;

namespace oop_lab2.Exceptions
{
    class PriceException : Exception
    {
        public PriceException() : base("product can't cost that much")
        {
        }
    }
}
