using System;
using System.Collections.Generic;
using System.Text;

namespace oop_lab4.exception
{
    class CreateIncPointException : Exception
    {

        public CreateIncPointException() : base("Inc point cannot create")
        {
        }
    }
}
