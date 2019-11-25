using System;

namespace TestTask3
{
    /// <summary>
    /// class for simple triangle
    /// </summary>
    class SimpleTriangle : Triangle
    {
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="pointA"></param>
        /// <param name="pointB"></param>
        /// <param name="pointC"></param>
        public SimpleTriangle(Point pointA, Point pointB, Point pointC) : base(pointA, pointB, pointC)
        {

        }

        /// <summary>
        /// override method get square for simple triangle
        /// </summary>
        /// <returns>Value of the square simple triangle</returns>
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