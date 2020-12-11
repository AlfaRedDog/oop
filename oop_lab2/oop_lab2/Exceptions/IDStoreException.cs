using System;
using System.Collections.Generic;
using System.Text;

namespace oop_lab2.Exceptions
{
    class IDStoreException : Exception
    {
        public IDStoreException() : base("two stores have one ID")
        {
        }
    }
}
