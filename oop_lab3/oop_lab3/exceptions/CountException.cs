using System;
using System.Collections.Generic;
using System.Text;

namespace oop_lab3.exceptions
{
    class CountException : Exception
    {
        public CountException() : base("count vehicle error")
        {
        }
    }
}
