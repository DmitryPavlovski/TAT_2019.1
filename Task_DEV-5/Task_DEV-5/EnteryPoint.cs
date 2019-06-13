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
                    flyable.ObjectFlyAway += Display.Travel;                    
                    flyable.FlyTo(new Point(100, 200, 800));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                Console.WriteLine($"Stack Trace: {ex.StackTrace}");
            }
        }
    }
}