using System;

namespace Task_DEV_5
{
    /// <summary>
    /// Interface for flyable objects
    /// </summary>
    public interface IFlyable
    {
        /// <summary>
        /// Event which crashes every time an object changes location
        /// </summary>
        event EventHandler<ObjectFlyAwayEventArgs> ObjectFlyAway;

        /// <summary>
        /// Method for fly from one point to next point
        /// </summary>
        /// <param name="nextPoint"></param>
        void FlyTo(Point nextPoint);

        /// <summary>
        /// Method return fly time
        /// </summary>
        /// <returns></returns>
        double GetFlyTime();

        /// <summary>
        /// Method return type object
        /// </summary>
        /// <returns></returns>
        IFlyable WhoAmI();
    }
}