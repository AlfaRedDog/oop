using System;
using System.Collections.Generic;
using System.Text;

namespace oop_lab3.exceptions
{
    class TypeTransportException : Exception
    {
        public TypeTransportException() : base ("type transport error")
        {
        }
    }
}
