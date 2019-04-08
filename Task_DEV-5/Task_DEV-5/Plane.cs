using System;

namespace Task_DEV_5
{
    /// <summary>
    /// Object with increasing speed
    /// </summary>
    class Plane : IFlyable
    {
        public Point StartPoint { get; set; }
        public int StartSpeed { get; set; } = 200;
        public double DistanceTraveled { get; set;}

        /// <inheritdoc />
        public event EventHandler<ObjectFlyAwayEventArgs> ObjectFlyAway;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public Plane(int x = 0, int y = 0, int z = 0)
        {
            StartPoint = new Point(x, y, z);
        }

        /// <summary>
        /// method return fly time
        /// </summary>
        /// <returns></returns>
        public double GetFlyTime()
        {
            var finishSpeed = StartSpeed + (int)DistanceTraveled / 10 * 10;
            return (DistanceTraveled * 2) / (finishSpeed + StartSpeed);
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
        /// method for fly from one point to next point
        /// </summary>
        /// <param name="nextPoint"></param>
        public void FlyTo(Point nextPoint)
        {
            DistanceTraveled += StartPoint.GetDistance(nextPoint);
            ObjectFlyAway?.Invoke(WhoAmI(), new ObjectFlyAwayEventArgs(GetFlyTime(), StartSpeed + (int)DistanceTraveled / 10 * 10));
            StartPoint = nextPoint;
        }
    }
}