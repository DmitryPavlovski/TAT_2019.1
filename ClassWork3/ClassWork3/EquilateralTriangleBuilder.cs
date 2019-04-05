using System;

namespace TestTask3
{
    /// <summary>
    /// class for equilateral triangle builder
    /// </summary>
    class EquilateralTriangleBuilder : TriangleBuilder
    {
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="successor"></param>
        public EquilateralTriangleBuilder(TriangleBuilder successor) : base(successor)
        {

        }

        /// <summary>
        /// override method for build equilateral triangle on three point
        /// </summary>
        /// <param name="pointA"></param>
        /// <param name="pointB"></param>
        /// <param name="pointC"></param>
        /// <returns>New equilateral triangle </returns>
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