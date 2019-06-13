using System;

namespace Task_DEV_5
{
    /// <summary>
    /// object with very high speed
    /// </summary>
    class SpaceShip : IFlyable
    {
        public Point StartPoint { get; set; }
        public int Speed { get; set; }
        public double DistanceTraveled { get; set; }

        /// <inheritdoc />
        public event EventHandler<ObjectFlyAwayEventArgs> ObjectFlyAway;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public SpaceShip(int x = 0, int y = 0, int z = 0)
        {
            this.StartPoint = new Point(x, y, z);
            this.Speed = (int)ObjectSpeed.SpaceShip;
        }

        /// <summary>
        /// method return fly time
        /// </summary>
        /// <returns></returns>
        public double GetFlyTime() => this.DistanceTraveled / this.Speed;

        /// <summary>
        /// method return type object
        /// </summary>
        /// <returns></returns>
        public IFlyable WhoAmI() => this;

        /// <summary>
        /// method for fly object from one point to next point
        /// </summary>
        /// <param name="nextPoint"></param>
        public void FlyTo(Point nextPoint)
        {
            this.DistanceTraveled += this.StartPoint.GetDistance(nextPoint);
            ObjectFlyAway?.Invoke(this.WhoAmI(), new ObjectFlyAwayEventArgs(this.GetFlyTime(), this.Speed));
            this.StartPoint = nextPoint;
        }
    }
}