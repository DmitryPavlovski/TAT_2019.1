using System;

namespace Task_DEV_5
{
    /// <summary>
    /// Object with speed from 1 to 20
    /// </summary>
    class Bird : IFlyable
    {
        public Point StartPoint { get; set; }
        public int Speed { get; set; }
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
            this.StartPoint = new Point(x, y, z);
            this.Speed = new Random().Next(1, (int)ObjectSpeed.Bird);
        }

        /// <summary>
        /// method return type object
        /// </summary>
        /// <returns></returns>
        public IFlyable WhoAmI() => this;

        /// <summary>
        /// method return fly time
        /// </summary>
        /// <returns></returns>
        public double GetFlyTime() => this.DistanceTraveled / this.Speed;

        /// <summary>
        /// method for fly from one point to next point
        /// </summary>
        /// <param name="nextPoint"></param>
        public void FlyTo(Point nextPoint)
        {
            this.DistanceTraveled += this.StartPoint.GetDistance(nextPoint);
            ObjectFlyAway?.Invoke(this.WhoAmI(), new ObjectFlyAwayEventArgs(this.GetFlyTime(), this.Speed));
        }
    }
}