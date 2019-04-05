using System;

namespace TestTask3
{
    class EquilateralTriangle : Triangle
    {
        public EquilateralTriangle(Point pointA, Point pointB, Point pointC) : base(pointA, pointB, pointC)
        {

        }
        public override double GetSquare()
        {
            double sizeSideAB = PointA.GetDistance(PointB);

            return sizeSideAB * sizeSideAB * Math.Sqrt(3) / 4;
        }
    }
}