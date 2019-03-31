using System;

namespace Task_DEV_5
{
    /// <summary>
    /// object with very high speed
    /// </summary>
    class SpaceShip : IFlyable
    {
        public Point StartPoint { get; set; }
        public int Speed { get; set; } = 8000 * 3600; // km/h = km/s * 3600
        public double DistanceTraveled { get; set; }

        public event EventHandler<ObjectFlyAwayEventArgs> ObjectFlyAway;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public SpaceShip(int x = 0, int y = 0, int z = 0)
        {
            StartPoint = new Point(x, y, z);
        }

        /// <summary>
        /// method return fly time
        /// </summary>
        /// <returns></returns>
        public double GetFlyTime()
        {
            return DistanceTraveled / Speed;
        }

        /// <summary>
        /// method return type object
        /// </summary>
        /// <returns></returns>
        public IFlyable WhoAmI()
        {
            return this;
        }

        /// <summary>
        /// method for fly object from one point to next point
        /// </summary>
        /// <param name="nextPoint"></param>
        public void FlyTo(Point nextPoint)
        {
            DistanceTraveled += StartPoint.GetDistance(nextPoint);
            ObjectFlyAway?.Invoke(WhoAmI(), new ObjectFlyAwayEventArgs(GetFlyTime(), Speed));
            StartPoint = nextPoint;
        }
    }
}