using System;
using System.Collections.Generic;
using System.Text;

namespace oop_lab3.transport
{
    public class TwoHumpedCamel : AGtransport
    {
        string AGtransport.Name => "TwoHumpedCamel";
        double AGtransport.Speed => 10.0;
        public double RaceTime(int distance)
        {
            int RestInterval = 30;
            int RestDuration1 = 5;
            int RestDuration2 = 8;
            int RestCount = (int)(distance / 10.0) / RestInterval;
            if (RestCount >= 1)
            {
                return distance / 10.0 + RestDuration1 + (RestCount - 1) * RestDuration2;
            }
            return distance / 10.0;
        }

        public int TypeOfVehicle()
        {
            return 2;
        }
    }


    public class CamelFastwalker : AGtransport
    {
        string AGtransport.Name => "Camel fastwalker";
        double AGtransport.Speed => 40.0;
        public double RaceTime(int distance)
        {
            int RestInterval = 10;
            int RestDuration1 = 5;
            int RestDuration2 = 6;
            int RestDuration3 = 8;
            int RestCount = (int)(distance / 40.0) / RestInterval;
            if(RestCount > 2)
            {
                return distance / 40.0 + RestDuration1 + RestDuration2 + (RestCount - 1) * RestDuration3;
            }
            if (RestCount == 2)
            {
                return distance / 40.0 + RestDuration1 + RestDuration2;
            }
            if(RestCount == 1)
            {
                return distance / 40.0 + RestDuration1;
            }
            return distance / 40.0;
        }

        public int TypeOfVehicle()
        {
            return 2;
        }
    }

    public class centaur : AGtransport
    {
        string AGtransport.Name => "centaur";
        double AGtransport.Speed => 15.0;
        public double RaceTime(int distance)
        {
            int RestInterval = 8;
            int RestDuration1 = 2;
            int RestCount = (int)(distance / 15.0) / RestInterval;
            return distance / 15.0 + RestCount * RestDuration1;
        }

        public int TypeOfVehicle()
        {
            return 2;
        }
    }

    public class AllTerrainBoots : AGtransport
    {
        string AGtransport.Name => "allterrarian boots";
        double AGtransport.Speed => 6.0;
        public double RaceTime(int distance)
        {
            int RestInterval = 60;
            int RestDuration1 = 10;
            int RestDuration2 = 5;
            int RestCount = (int)(distance / 6.0) / RestInterval;
            if (RestCount >= 1)
            {
                return distance / 6.0 + RestDuration1 + (RestCount - 1) * RestDuration2;
            }
            return distance / 6.0;
        }

        public int TypeOfVehicle()
        {
            return 2;
        }
    }
}
