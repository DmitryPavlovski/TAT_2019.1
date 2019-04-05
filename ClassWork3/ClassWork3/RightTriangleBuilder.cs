using System;

namespace TestTask3
{
    /// <summary>
    /// class for right triangle builder
    /// </summary>
    class RightTriangleBuilder : TriangleBuilder
    {
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="successor"></param>
        public RightTriangleBuilder(TriangleBuilder successor) : base(successor)
        {

        }

        /// <summary>
        /// override method for build right triangle on three point
        /// </summary>
        /// <param name="pointA"></param>
        /// <param name="pointB"></param>
        /// <param name="pointC"></param>
        /// <returns>New right triangle </returns>
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