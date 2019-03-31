using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_DEV_5
{
   // public delegate void AccountStateHandler(IFlyable obj, ObjectFlyAwayEventArgs e);
    public interface IFlyable
    {        
        void FlyTo(Point nextPoint);
        double GetFlyTime();
        IFlyable WhoAmI();
        event EventHandler<ObjectFlyAwayEventArgs> ObjectFlyAway;
    }
}
