using System;
using System.Collections.Generic;
using System.Text;

namespace oop_lab2.Exceptions
{
    class CountException : Exception
    {
        public CountException() : base("you can't add this count products")
        {
        }
    }
}
