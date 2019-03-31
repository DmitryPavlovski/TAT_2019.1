using System;

namespace Task_DEV_5
{
    class Bird : IFlyable
    {
        public Point StartPoint { get; set; }
        public int Speed { get; set; } = new Random().Next(1, 21); //Km/h
        public double DistanceTraveled { get; set; }

        public event EventHandler<ObjectFlyAwayEventArgs> ObjectFlyAway;

        public Bird(int x = 0, int y = 0, int z = 0)
        {
            StartPoint = new Point(x, y, z);
        }

        public IFlyable WhoAmI()
        {
            return this;
        }

        public double GetFlyTime()
        {
            return DistanceTraveled / Speed;
        }

        public void FlyTo(Point nextPoint)
        {
            DistanceTraveled += StartPoint.GetDistance(nextPoint);
            ObjectFlyAway?.Invoke(WhoAmI(), new ObjectFlyAwayEventArgs(GetFlyTime(), Speed));
        }
    }
}