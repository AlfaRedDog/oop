using System;
using System.Collections.Generic;
using System.Text;

namespace oop_lab3.transport
{
    public abstract class AGtransport
    {
        public abstract string Name();
        protected abstract double Speed();
        public abstract double RaceTime(int distance);
        public abstract string TypeOfVehicle();
    }
}
