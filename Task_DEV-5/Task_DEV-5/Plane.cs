using System;

namespace Task_DEV_5
{
    /// <summary>
    /// Object with increasing speed
    /// </summary>
    class Plane : IFlyable
    {
        public Point StartPoint { get; set; }
        public int StartSpeed { get; set; }
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
            this.StartPoint = new Point(x, y, z);
            this.StartSpeed = (int)ObjectSpeed.Plane;
        }

        /// <summary>
        /// method return fly time
        /// </summary>
        /// <returns></returns>
        public double GetFlyTime()
        {
            var finishSpeed = this.StartSpeed + (int)this.DistanceTraveled / 10 * 10;
            return (this.DistanceTraveled * 2) / (finishSpeed + this.StartSpeed);
        }

        /// <summary>
        /// method return type object
        /// </summary>
        /// <returns></returns>
        public IFlyable WhoAmI() => this;

        /// <summary>
        /// method for fly from one point to next point
        /// </summary>
        /// <param name="nextPoint"></param>
        public void FlyTo(Point nextPoint)
        {
            this.DistanceTraveled += this.StartPoint.GetDistance(nextPoint);
            ObjectFlyAway?.Invoke(this.WhoAmI(), new ObjectFlyAwayEventArgs(this.GetFlyTime(), this.StartSpeed + (int)this.DistanceTraveled / 10 * 10));
            this.StartPoint = nextPoint;
        }
    }
}