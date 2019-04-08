using System;

namespace Task_DEV_5
{
    /// <summary>
    /// Object with speed from 1 to 20
    /// </summary>
    class Bird : IFlyable
    {
        public Point StartPoint { get; set; }
        public int Speed { get; set; } = new Random().Next(1, 21); //Km/h
        public double DistanceTraveled { get; set; }

        /// <inheritdoc />
        public event EventHandler<ObjectFlyAwayEventArgs> ObjectFlyAway;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public Bird(int x = 0, int y = 0, int z = 0)
        {
            StartPoint = new Point(x, y, z);
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
        /// method return fly time
        /// </summary>
        /// <returns></returns>
        public double GetFlyTime()
        {
            return DistanceTraveled / Speed;
        }

        /// <summary>
        /// method for fly from one point to next point
        /// </summary>
        /// <param name="nextPoint"></param>
        public void FlyTo(Point nextPoint)
        {
            DistanceTraveled += StartPoint.GetDistance(nextPoint);
            ObjectFlyAway?.Invoke(WhoAmI(), new ObjectFlyAwayEventArgs(GetFlyTime(), Speed));
        }
    }
}