using System;
using System.Collections.Generic;
using System.Text;

namespace oop_lab5.Exceptions
{
    class CreditLimitException : Exception
    {
        public CreditLimitException() : base("credit limit exceeded")
        {

        }
    }
}
