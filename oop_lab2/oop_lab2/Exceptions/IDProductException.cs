using System;
using System.Collections.Generic;
using System.Text;

namespace oop_lab2.Exceptions
{
    class IDProductException : Exception
    {
        public IDProductException() : base("two product have one ID")
        {
        }
    }
}
