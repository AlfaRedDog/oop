using System;
using System.Collections.Generic;
using System.Text;
using oop_lab3.transport;
namespace oop_lab3.transport
{
    public class magic_corvet : AGtransport
    {
        string AGtransport.Name => "magic carpet";
        double AGtransport.Speed => 10.0;
        public double RaceTime(int distance)
        {
            double DistanceReducer1 = 1 - 0.03;
            double DistanceReducer2 = 1 - 0.1;
            double DistanceReducer3 = 1 - 0.05;

            if(distance <= 1000)
            {
                return distance / 10.0;
            }
            if(distance > 1000 && distance <= 5000)
            {
                return distance * DistanceReducer1 / 10.0;
            }
            if(distance > 5000 && distance <= 10000)
            {
                return distance * DistanceReducer2 / 10.0;
            }
            return distance * DistanceReducer3 / 10.0;
        }
        public int TypeOfVehicle()
        {
            return 1;
        }
    }
    public class metla : AGtransport
    {
        string AGtransport.Name => "metla";
        double AGtransport.Speed => 20.0;
        public double RaceTime(int distance)
        {
            double DistanceReducer = 0.01;
            int range = 1000;
            return distance * (1.0 - distance / range * DistanceReducer) / 20.0;
        }
        public int TypeOfVehicle()
        {
            return 1;
        }
    }
    public class stupa : AGtransport
    {
        string AGtransport.Name => "stupa";
        double AGtransport.Speed => 8.0;

        public double RaceTime(int distance)
        {
            double DistanceReducer = 0.06;
            return distance * (1.0 - DistanceReducer) / 8.0;
        }
        public int TypeOfVehicle()
        {
            return 1;
        }
    }
}
