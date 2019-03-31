using System;

namespace Task_DEV_5
{
    public interface IFlyable
    {        
        void FlyTo(Point nextPoint);

        double GetFlyTime();

        IFlyable WhoAmI();
        event EventHandler<ObjectFlyAwayEventArgs> ObjectFlyAway;
    }
}