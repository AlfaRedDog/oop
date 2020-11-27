using System;
using System.Collections.Generic;
using System.Text;
using oop_lab3.transport;
using oop_lab3.exceptions;
namespace oop_lab3.race
{
    [Flags]
    enum TypeRace
    {
        AG = 0,
        AIR = 1,
        GROUND = 2
    }
    public class Race
    {
        private int TypeOfRace;
        public int Distance;
        private List<AGtransport> VehicleOnRace = new List<AGtransport>();
        public List<Tuple<AGtransport, double>> Res = new List<Tuple<AGtransport, double>>();
        public Race(int type, int distance)
        {
            if (distance < 0)
                throw new DistanceException();
            if (! Enum.IsDefined(typeof(TypeRace), type))
                throw new TypeRaceException();
            Distance = distance;
            TypeOfRace = type;
        }
        public void AddVechicle(AGtransport a)
        {
            if ((a.TypeOfVehicle() != TypeOfRace) && (TypeOfRace != 0))
                throw new TypeTransportException();
            VehicleOnRace.Add(a);
        }
        public Tuple<AGtransport, double> Start()
        {
            if (VehicleOnRace.Count  < 2)
                throw new CountException();
            double min = 0;
            AGtransport minVehicle = VehicleOnRace[0];
            var result = new List<Tuple<AGtransport, double>>();
            foreach (var element in VehicleOnRace)
            {
                result.Add(new Tuple<AGtransport, double>(element, element.RaceTime(Distance)));
                if((element.RaceTime(Distance) < min) || (min == 0))
                {
                    minVehicle = element;
                    min = element.RaceTime(Distance);
                }
            }
            Tuple<AGtransport, double> Vech = new Tuple<AGtransport, double>(minVehicle, min);
            Res = result;
            VehicleOnRace.Clear();
            return Vech;
        }
    }
}
