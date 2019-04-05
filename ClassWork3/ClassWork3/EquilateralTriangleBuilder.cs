using System;

namespace TestTask3
{
    class EquilateralTriangleBuilder : TriangleBuilder
    {
        public EquilateralTriangleBuilder(TriangleBuilder successor) : base(successor)
        {

        }
        public override Triangle Build(Point pointA, Point pointB, Point pointC)
        {
            double sideAB = pointA.GetDistance(pointB);
            double sideAC = pointA.GetDistance(pointC);
            double sideBC = pointB.GetDistance(pointC);

            if (Math.Abs(sideAB - sideAC) < eps
                && Math.Abs(sideAB - sideBC) < eps
                && Math.Abs(sideAC - sideBC) < eps)
            {
                return new EquilateralTriangle(pointA, pointB, pointC);
            }

            return Successor?.Build(pointA, pointB, pointC) ?? throw new Exception("Can't build equilateral triangle");
        }
    }
}