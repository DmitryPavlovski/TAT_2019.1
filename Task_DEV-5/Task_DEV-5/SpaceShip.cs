using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_DEV_5
{
    class SpaceShip : IFlyable
    {
        public event EventHandler<ObjectFlyAwayEventArgs> ObjectFlyAway;
        public Point StartPoint { get; set; }
        public int Speed { get; set; } = 8000 * 3600; // km/h = km/s * 3600
        public double DistanceTraveled { get; set; }
        public SpaceShip(int x = 0, int y = 0, int z = 0)
        {
            StartPoint = new Point(x, y, z);
        }
        public double GetFlyTime()
        {
            return DistanceTraveled / Speed;
        }
        public IFlyable WhoAmI()
        {
            return this;
        }
        public void FlyTo(Point nextPoint)
        {
            DistanceTraveled += StartPoint.GetDistance(nextPoint);
            ObjectFlyAway?.Invoke(WhoAmI(), new ObjectFlyAwayEventArgs(GetFlyTime(), Speed));
            StartPoint = nextPoint;
        }
    }
}
