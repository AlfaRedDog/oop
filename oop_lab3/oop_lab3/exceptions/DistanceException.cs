using System;
using System.Collections.Generic;
using System.Text;

namespace oop_lab3.exceptions
{
    class DistanceException : Exception
    {
        public DistanceException() : base("value distance error")
        {
        }
    }
}
