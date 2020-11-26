using System;
using System.Collections.Generic;
using System.Text;

namespace oop_lab3.transport
{
    public class TwoHumpedCamel : AGtransport
    {
        public override string Name()
        {
            return "two-humped camel";
        }
        protected override double Speed()
        {
            return 10.0;
        }
        public override double RaceTime(int distance)
        {
            int RestInterval = 30;
            int RestDuration1 = 5;
            int RestDuration2 = 8;
            int RestCount = (int)(distance / Speed()) / RestInterval;
            if (RestCount >= 1)
            {
                return distance / Speed() + RestDuration1 + (RestCount - 1) * RestDuration2;
            }
            return distance / Speed();
        }

        public override string TypeOfVehicle()
        {
            return "G";
        }
    }


    public class CamelFastwalker : AGtransport
    {
        public override string Name()
        {
            return "camelfastwalker";
        }
        protected override double Speed()
        {
            return 40.0;
        }
        public override double RaceTime(int distance)
        {
            int RestInterval = 10;
            int RestDuration1 = 5;
            int RestDuration2 = 6;
            int RestDuration3 = 8;
            int RestCount = (int)(distance / Speed()) / RestInterval;
            if(RestCount > 2)
            {
                return distance / Speed() + RestDuration1 + RestDuration2 + (RestCount - 1) * RestDuration3;
            }
            if (RestCount == 2)
            {
                return distance / Speed() + RestDuration1 + RestDuration2;
            }
            if(RestCount == 1)
            {
                return distance / Speed() + RestDuration1;
            }
            return distance / Speed();
        }

        public override string TypeOfVehicle()
        {
            return "G";
        }
    }

    public class centaur : AGtransport
    {
        public override string Name()
        {
            return "centaur";
        }
        protected override double Speed()
        {
            return 15.0;
        }
        public override double RaceTime(int distance)
        {
            int RestInterval = 8;
            int RestDuration1 = 2;
            int RestCount = (int)(distance / Speed()) / RestInterval;
            return distance / Speed() + RestCount * RestDuration1;
        }

        public override string TypeOfVehicle()
        {
            return "G";
        }
    }

    public class AllTerrainBoots : AGtransport
    {
        public override string Name()
        {
            return "all-terrain boots";
        }
        protected override double Speed()
        {
            return 6.0;
        }
        public override double RaceTime(int distance)
        {
            int RestInterval = 60;
            int RestDuration1 = 10;
            int RestDuration2 = 5;
            int RestCount = (int)(distance / Speed()) / RestInterval;
            if (RestCount >= 1)
            {
                return distance / Speed() + RestDuration1 + (RestCount - 1) * RestDuration2;
            }
            return distance / Speed();
        }

        public override string TypeOfVehicle()
        {
            return "G";
        }
    }
}
