using System;
using System.Collections.Generic;
using System.Text;

namespace oop_lab5.Exceptions
{
    class MutnyTipException : Exception
    {
        public MutnyTipException() : base("put your passport and adress")
        {

        }
    }
}
