using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_DEV_5
{
    class Plane : IFlyable
    {
        public event EventHandler<ObjectFlyAwayEventArgs> ObjectFlyAway;
        public Point StartPoint { get; set; }
        public int StartSpeed { get; set; } = 200;
        public double DistanceTraveled { get; set;}
        public Plane(int x = 0, int y = 0, int z = 0)
        {
            StartPoint = new Point(x, y, z);
        }
        public double GetFlyTime()
        {
            var finishSpeed = StartSpeed + (int)DistanceTraveled / 10 * 10;
            return (DistanceTraveled * 2) / (finishSpeed + StartSpeed);
        }
        public IFlyable WhoAmI()
        {
            return this;
        }
        public void FlyTo(Point nextPoint)
        {
            DistanceTraveled += StartPoint.GetDistance(nextPoint);
            ObjectFlyAway?.Invoke(WhoAmI(), new ObjectFlyAwayEventArgs(GetFlyTime(), StartSpeed + (int)DistanceTraveled / 10 * 10));
            StartPoint = nextPoint;
        }
    }
}
