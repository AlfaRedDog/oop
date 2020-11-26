using System;
using System.Collections.Generic;
using System.Text;
using oop_lab3.transport;
namespace oop_lab3.transport
{
    public class magic_corvet : AGtransport
    { 
        public override string Name()
        {
            return "magic_carpet";
        }
        protected override double Speed()
        {
            return 10.0;
        }
        public override double RaceTime(int distance)
        {
            double DistanceReducer1 = 1 - 0.03;
            double DistanceReducer2 = 1 - 0.1;
            double DistanceReducer3 = 1 - 0.05;

            if(distance <= 1000)
            {
                return distance / Speed();
            }
            if(distance > 1000 && distance <= 5000)
            {
                return distance * DistanceReducer1 / Speed();
            }
            if(distance > 5000 && distance <= 10000)
            {
                return distance * DistanceReducer2 / Speed();
            }
            return distance * DistanceReducer3 / Speed();
        }
        public override string TypeOfVehicle()
        {
            return "A";
        }
    }
    public class metla : AGtransport
    {
        public override string Name()
        {
            return "metla";
        }

        protected override double Speed()
        {
            return 20.0;
        }
        public override double RaceTime(int distance)
        {
            double DistanceReducer = 0.01;
            int range = 1000;
            return distance * (1.0 - distance / range * DistanceReducer) / Speed();
        }
        public override string TypeOfVehicle()
        {
            return "A";
        }
    }
    public class stupa : AGtransport
    {
        public override string Name()
        {
            return "stupa";
        }

        protected override double Speed()
        {
            return 8.0;
        }
        public override double RaceTime(int distance)
        {
            double DistanceReducer = 0.06;
            return distance * (1.0 - DistanceReducer) / Speed();
        }
        public override string TypeOfVehicle()
        {
            return "A";
        }
    }
}
