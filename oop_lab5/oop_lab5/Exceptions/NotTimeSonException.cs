using System;
using System.Collections.Generic;
using System.Text;

namespace oop_lab5.Exceptions
{
    class NotTimeSonException : Exception
    {
        public NotTimeSonException() : base ("you can't work with this account now")
        {

        }
    }
}
