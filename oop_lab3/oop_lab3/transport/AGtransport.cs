using System;
using System.Collections.Generic;
using System.Text;

namespace oop_lab3.transport
{
    public interface AGtransport
    {
        string Name { get;  }
        double Speed { get; }
        public double RaceTime(int distance);
        public int TypeOfVehicle();
    }
}
