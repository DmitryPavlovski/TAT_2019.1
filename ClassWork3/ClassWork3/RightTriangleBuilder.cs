using System;

namespace TestTask3
{
    class RightTriangleBuilder : TriangleBuilder
    {
        public RightTriangleBuilder(TriangleBuilder successor) : base(successor)
        {

        }
        public override Triangle Build(Point pointA, Point pointB, Point pointC)
        {
            Point vectorAB = new Point(pointB.X - pointA.X, pointB.Y - pointA.Y);
            Point vectorAC = new Point(pointC.X - pointA.X, pointC.Y - pointA.Y);
            Point vectorBC = new Point(pointC.X - pointB.X, pointC.Y - pointB.Y);

            if (Math.Abs(vectorAB.X * vectorAC.X + vectorAB.Y * vectorAC.Y) < eps
                || Math.Abs(vectorAB.X * vectorBC.X + vectorAB.Y * vectorBC.Y) < eps
                || Math.Abs(vectorAC.X * vectorBC.X + vectorAC.Y * vectorBC.Y) < eps)
            {
                return new RightTriangle(pointA, pointB, pointC);
            }

            return Successor?.Build(pointA, pointB, pointC) ?? throw new Exception("Can't build right triangle");
        }
    }
}