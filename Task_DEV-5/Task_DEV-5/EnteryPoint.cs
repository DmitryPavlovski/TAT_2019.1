using System;
using System.Collections.Generic;

namespace Task_DEV_5
{
    class EnteryPoint
    {
        static void Main()
        {
            try
            {
                var flyables = new List<IFlyable> { new Bird(), new Plane(), new SpaceShip() };

                foreach (var flyable in flyables)
                {
                    flyable.ObjectFlyAway += DisplayTravels;                    
                    flyable.FlyTo(new Point(100, 200, 800));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                Console.WriteLine($"Stack Trace: {ex.StackTrace}");
            }
        }
        private static void DisplayTravels(object obj, ObjectFlyAwayEventArgs args)
        {
            Console.Write($"{obj.GetType().Name}'s time is ");
            Console.WriteLine(obj is SpaceShip
                ? $"{Math.Round(args.Time * 3600, 3)} seconds, reaching {args.Speed / 3600} km/s"
                : $"{Math.Round(args.Time, 3)} hours, reaching {args.Speed} km/h");
        }
    }
}