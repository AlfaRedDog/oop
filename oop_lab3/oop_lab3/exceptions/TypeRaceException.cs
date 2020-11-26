using System;
using System.Collections.Generic;
using System.Text;

namespace oop_lab3.exceptions
{
    class TypeRaceException : Exception
    {
        public TypeRaceException() : base("type race error")
        {
        }
    }
}
