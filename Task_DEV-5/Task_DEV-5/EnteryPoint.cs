using System;
using System.Collections.Generic;

namespace Task_DEV_5
{
    /// <summary>
    /// Entery point class
    /// </summary>
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
        /// <summary>
        /// Method 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="arg"></param>
        private static void DisplayTravels(object obj, ObjectFlyAwayEventArgs arg)
        {
            Console.Write($"{obj.GetType().Name}'s time is ");
            Console.WriteLine(obj is SpaceShip
                ? $"{Math.Round(arg.Time * 3600, 3)} seconds, reaching {arg.Speed / 3600} km/s"
                : $"{Math.Round(arg.Time, 3)} hours, reaching {arg.Speed} km/h");
        }
    }
}