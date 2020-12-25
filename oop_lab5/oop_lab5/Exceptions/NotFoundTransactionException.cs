using System;
using System.Collections.Generic;
using System.Text;

namespace oop_lab5.Exceptions
{
    class NotFoundTransactionException : Exception
    {
        public NotFoundTransactionException() : base("transaction not found")
        {

        }
    }
}
