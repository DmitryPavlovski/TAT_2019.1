using System;

namespace TestTask3
{
    /// <summary>
    /// class for equilateral triangle
    /// </summary>
    class EquilateralTriangle : Triangle
    {
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="pointA"></param>
        /// <param name="pointB"></param>
        /// <param name="pointC"></param>
        public EquilateralTriangle(Point pointA, Point pointB, Point pointC) : base(pointA, pointB, pointC)
        {

        }

        /// <summary>
        /// override method get square for equilateral triangle
        /// </summary>
        /// <returns>Value of the square equilateral triangle</returns>
        public override double GetSquare()
        {
            double sizeSideAB = PointA.GetDistance(PointB);

            return sizeSideAB * sizeSideAB * Math.Sqrt(3) / 4;
        }
    }
}