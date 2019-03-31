using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_DEV_5
{
    public class ObjectFlyAwayEventArgs : EventArgs
    {
        public double Time { get; set; }
        public double Speed { get; set; }
        public ObjectFlyAwayEventArgs (double time, double speed)
        {
            Time = time;
            Speed = speed;
        }   
    }
}
