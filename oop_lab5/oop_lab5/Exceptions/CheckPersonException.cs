using System;
using System.Collections.Generic;
using System.Text;

namespace oop_lab5.Exceptions
{
    class CheckPersonException : Exception
    {
        public CheckPersonException() : base("this person can not exist again")
        {
        }
    }
}
