using System;

namespace TestTask3
{
    class SimpleTriangle : Triangle
    {
        public SimpleTriangle(Point pointA, Point pointB, Point pointC) : base(pointA, pointB, pointC)
        {

        }
        public override double GetSquare()
        {
            double sizeSideAB = PointA.GetDistance(PointB);
            double sizeSideAC = PointA.GetDistance(PointC);
            double sizeSideBC = PointB.GetDistance(PointC);
            double poluPim = (sizeSideAB + sizeSideAC + sizeSideBC) / 2;

            return Math.Sqrt(poluPim * (poluPim - sizeSideAB) * (poluPim - sizeSideAC) * (poluPim - sizeSideBC));

        }
    }
}