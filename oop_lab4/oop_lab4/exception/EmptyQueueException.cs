using System;
using System.Collections.Generic;
using System.Text;

namespace oop_lab4.exception
{
    class EmptyQueueException : Exception
    {
        public EmptyQueueException() : base("count vehicle error")
        {
        }
    }
}
