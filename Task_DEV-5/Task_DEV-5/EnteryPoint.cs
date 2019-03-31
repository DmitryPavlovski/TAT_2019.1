using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_DEV_5
{
    class EnteryPoint
    {
        static void Main()
        {
            try
            {
                var random = new Random();
                var points = new List<Point>();
                var flyables = new List<IFlyable> { new Bird(), new Plane(), new SpaceShip() };

                points.Add(new Point(100, 200, 800));
                for (int i = 1; i < 6; i ++)
                {
                    points.Add(new Point(random.Next(1, 1000), random.Next(1, 1000), random.Next(1, 1000)));
                }
                foreach (var flyable in flyables)
                {
                    flyable.ObjectFlyAway += DisplayTravels;
                    foreach (var point in points)
                    {
                        flyable.FlyTo(point);
                    }
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
