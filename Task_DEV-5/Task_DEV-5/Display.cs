using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_DEV_5
{
    /// <summary>
    /// class for display data
    /// </summary>
    class Display
    {
        /// <summary>
        /// Method display time and speed moving
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="arg"></param>
        public static void Travel(object obj, ObjectFlyAwayEventArgs arg)
        {
            Console.Write($"{obj.GetType().Name}'s time is ");
            Console.WriteLine(obj is SpaceShip
                ? $"{Math.Round(arg.Time * 3600, 3)} seconds, reaching {arg.Speed / 3600} km/s"
                : $"{Math.Round(arg.Time, 3)} hours, reaching {arg.Speed} km/h");
        }
    }
}
