using System;

namespace TestTask3
{
    class SimpleTriangleBilder : TriangleBuilder
    {
        public SimpleTriangleBilder(TriangleBuilder successor) : base(successor)
        {

        }
        public override Triangle Build(Point pointA, Point pointB, Point pointC)
        {
            double[] sizeSiseTriangle = new double[3]
            { pointA.GetDistance(pointB), pointA.GetDistance(pointC), pointB.GetDistance(pointC) };
            Array.Sort(sizeSiseTriangle);
            if (!(Math.Abs(sizeSiseTriangle[0] + sizeSiseTriangle[1] - sizeSiseTriangle[2]) < eps))
            {
                return new SimpleTriangle(pointA, pointB, pointC);
            }

            return Successor?.Build(pointA, pointB, pointC) ?? throw new Exception("Can't build simple triangle");

        }
    }
}