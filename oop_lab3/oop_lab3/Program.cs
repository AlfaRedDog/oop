using System;
using oop_lab3.transport;
using oop_lab3.race;
using static System.Console;
namespace oop_lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // 1 - Air race, 2 - Ground race, 0 - all vechicle race
                Race race = new Race(0, 1000);
                race.AddVechicle(new magic_corvet());
                race.AddVechicle(new metla());
                race.AddVechicle(new stupa());
                race.AddVechicle(new TwoHumpedCamel());
                race.AddVechicle(new CamelFastwalker());
                race.AddVechicle(new AllTerrainBoots());
                race.AddVechicle(new centaur());
                Tuple<AGtransport, double> b = race.Start();
                //AGtransport a = new TwoHumpedCamel();
                //Console.WriteLine(a.RaceTime(1000));
                Console.WriteLine(b.Item1.Name);
                Console.WriteLine(b.Item2);
                Race raceGround = new Race(1, 1000);
                //raceGround.AddVechicle(new TwoHumpedCamel());
                //raceGround.AddVechicle(new CamelFastwalker());
                //raceGround.AddVechicle(new centaur());
                //raceGround.AddVechicle(new AllTerrainBoots());
                raceGround.AddVechicle(new magic_corvet());
                raceGround.AddVechicle(new metla());
                raceGround.AddVechicle(new stupa());
                b = raceGround.Start();
                //Console.WriteLine(raceGround.Res[0].Item1.Name());
                //Console.WriteLine(raceGround.Res[0].Item2);
                //Console.WriteLine(raceGround.Res[1].Item1.Name());
                //Console.WriteLine(raceGround.Res[1].Item2);
                //Console.WriteLine(raceGround.Res[2].Item1.Name());
                //Console.WriteLine(raceGround.Res[2].Item2);
                //Console.WriteLine(raceGround.Res[3].Item1.Name());
                //Console.WriteLine(raceGround.Res[3].Item2);
                Console.WriteLine(b.Item1.Name);
                Console.WriteLine(b.Item2);
            }
            catch (Exception e)
            {
                Error.WriteLine(e.Message);
            }
        }
    }
}
