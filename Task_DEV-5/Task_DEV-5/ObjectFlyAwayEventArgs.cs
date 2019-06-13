using System;

namespace Task_DEV_5
{
    /// <inheritdoc />
    /// <summary>
    /// class for event ObjectFlyAway
    /// </summary>
    public class ObjectFlyAwayEventArgs : EventArgs
    {
        public double Time { get; set; }
        public double Speed { get; set; }

        /// <inheritdoc />
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="time"></param>
        /// <param name="speed"></param>
        public ObjectFlyAwayEventArgs (double time, double speed)
        {
            this.Time = time;
            this.Speed = speed;
        }   
    }
}